using Microsoft.AspNetCore.Mvc;
using WebProgramming.Models;

namespace WebProgramming.Controllers
{
    public class AccountController : Controller
    {
        // GET: /Account/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            // Kiểm tra tài khoản
            if (model.Username == "admin" && model.Password == "123")
            {
                // Đăng nhập đúng → chuyển sang Bài 2
                return RedirectToAction("Index", "Book");
            }
            else
            {
                // Đăng nhập sai → ở lại trang Login
                ViewBag.Message = "Login failed";
                ViewBag.MessageType = "error";

                return View(model);
            }
        }
    }
}