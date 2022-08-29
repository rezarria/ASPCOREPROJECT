using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WEB.ETC;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace WEB.Areas.Admin.Controllers;
[Area("Admin")]
public class TaiKhoanController : Controller
{
    private readonly Models.WebContext _database;

    public TaiKhoanController(Models.WebContext database)
    {
        _database = database;
    }

    [HttpGet]
    public IActionResult DangNhap()
    {
        return View();
    }

    public class ThongTinDangNhap
    {
        public ThongTinDangNhap() { }

        public string Email { get; set; } = null!;
        public string MatKhau { get; set; } = null!;
    }

    [HttpPost]
    public IActionResult DangNhapJson([FromBody] ThongTinDangNhap tt)
     => DangNhap(tt.Email, tt.MatKhau);

    [HttpPost]
    public IActionResult DangNhap(string email, string matKhau)
    {
        try
        {
            if (!User.Identity?.IsAuthenticated ?? true)
            {
                var a = _database.TblTaiKhoans.Where(x => x.Email == email).Select(x => new { x.Email, x.MatKhau }).First();
                Models.TblTaiKhoan taiKhoan = new() { Email = a.Email, MatKhau = a.MatKhau };
                var matKhauMaHoa = Convert.FromBase64String(taiKhoan.MatKhau ?? throw new Exception());
                if (MatKhau.XacThucMatKhau(matKhauMaHoa, matKhau))
                    return SignIn(DangNhap(taiKhoan));
            }
            throw new Exception();
        }
        catch (System.Exception)
        {
            return new NoContentResult();
        }
    }

    [Authorize]
    public IActionResult Test() => View();

    private ClaimsPrincipal DangNhap(Models.TblTaiKhoan taiKhoan)
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
        return new(claimsIdentity);
    }
}
