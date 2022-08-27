using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace WEB.Areas.Admin.Controllers;
[Area("Admin")]
public class TaiKhoanController : Controller
{

    public IActionResult DangNhap()
    {
        return View();
    }

    [Authorize]
    public IActionResult Test() => View();
}
