using Microsoft.AspNetCore.Mvc;
using WEB.ETC;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Authentication;

namespace WEB.Areas.Api.Controllers;

[Area("Api")]
[ApiController]
[Route("/api/taikhoan")]
public class TaiKhoanController : ControllerBase
{
    private readonly Models.WebContext _database;

    public TaiKhoanController(Models.WebContext database)
    {
        _database = database;
    }

    [HttpPost("dangnhap")]
    public IActionResult DangNhap(string email, string matKhau)
    {
        try
        {
            if (User.Identity?.IsAuthenticated ?? false) throw new Exception();
            var taiKhoan = _database.TblTaiKhoans.Single(x => x.Email == email);
            if (taiKhoan.MatKhau is null)
                throw new NullReferenceException();
            if (MatKhau.XacThucMatKhau(Convert.FromBase64String(taiKhoan.MatKhau), matKhau))
            {
                var authProperties = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    IsPersistent = true,
                    ExpiresUtc = DateTime.UtcNow.AddDays(1),
                    IssuedUtc = DateTime.UtcNow.AddDays(1)
                };

                ClaimsIdentity claimsIdentity = new(new Claim[] {
                    new(ClaimTypes.Email, taiKhoan.Email ?? throw new Exception()),
                    new(ClaimTypes.Name, taiKhoan.HoVaTen ?? String.Empty),
                    new("Avatar", taiKhoan.HinhAnh ?? String.Empty)
                }, CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal claimsPrincipal = new(claimsIdentity);
                return SignIn(claimsPrincipal);
            }
            return NotFound();
        }
        catch (Exception)
        {
            return NotFound();
        }
    }

    [HttpPost("taotaikhoan")]
    public async Task<IResult> TaoTaiKhoan(string email, string matKhau)
    {
        try
        {
            if (_database.TblTaiKhoans.Count(x => x.Email == email) == 0)
            {
                using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
                {
                    var taiKhoan = new Models.TblTaiKhoan()
                    {
                        Email = email,
                        MatKhau = Convert.ToBase64String(MatKhau.MaHoaMatKhau(matKhau, rng))
                    };
                    _database.Add(taiKhoan);
                };
                await _database.SaveChangesAsync();
                return Results.Ok();
            }
            else return Results.Conflict();
        }
        catch (Exception)
        {
            return Results.BadRequest();
        }
    }
}