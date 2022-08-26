using Microsoft.AspNetCore.Mvc;

namespace WEB.Areas.Admin.Controllers; 
[Area("Admin")]
public class TaiKhoanController : Controller {
    
    public IActionResult DangNhap()
    {
        return View();
    }
}
