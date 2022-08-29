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

    public class ThongTinDangNhap
    {
        public string Email { get; set; } = null!;
        public string MatKhau { get; set; } = null!;

        public ThongTinDangNhap() { }
        public ThongTinDangNhap(Models.TblTaiKhoan tk) => (Email, MatKhau) = (tk?.Email ?? String.Empty, String.Empty);
    }

    [HttpPost("dangnhap")]
    public IActionResult DangNhap(ThongTinDangNhap tt)
    {
        try
        {
            if (User.Identity?.IsAuthenticated ?? false) throw new Exception();
            var taiKhoan = _database.TblTaiKhoans.Single(x => x.Email == tt.Email);
            if (taiKhoan.MatKhau is null)
                throw new NullReferenceException();
            if (MatKhau.XacThucMatKhau(Convert.FromBase64String(taiKhoan.MatKhau), tt.MatKhau))
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
    public async Task<IResult> TaoTaiKhoan(ThongTinDangNhap tt)
    {
        try
        {
            if (_database.TblTaiKhoans.Count(x => x.Email == tt.Email) == 0)
            {
                using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
                {
                    var taiKhoan = new Models.TblTaiKhoan()
                    {
                        Email = tt.Email,
                        MatKhau = Convert.ToBase64String(MatKhau.MaHoaMatKhau(tt.MatKhau, rng))
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