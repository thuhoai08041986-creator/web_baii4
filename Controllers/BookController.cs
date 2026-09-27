using Microsoft.AspNetCore.Mvc;
using WebProgramming.Models;

namespace WebProgramming.Controllers
{
    public class BookController : Controller
    {
        // Danh sách sách mẫu
        private static List<Book> books = new List<Book>
        {
            new Book
            {
                Id = 1,
                Name = "Lap trinh C#",
                Price = 20
            },

            new Book
            {
                Id = 2,
                Name = "lap trinh Web",
                Price = 15
            },

            new Book
            {
                Id = 3,
                Name = "Co so du lieu",
                Price = 25
            }
        };


        // ====================================
        // BÀI 2 - DANH SÁCH SÁCH
        // URL: /Book/Index
        // ====================================

        [HttpGet]
        public IActionResult Index()
        {
            return View(books);
        }


        // ====================================
        // BÀI 2 - CHI TIẾT SÁCH
        // URL: /Book/Detail/1
        // ====================================

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }


        // ====================================
        // BÀI 2 - FORM THÊM SÁCH
        // URL: /Book/Create
        // ====================================

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        // ====================================
        // BÀI 2 + BÀI 3
        // THÊM SÁCH + VALIDATION
        // URL: /Book/Create
        // ====================================

        [HttpPost]
        public IActionResult Create(Book book)
        {
            // Kiểm tra validation
            if (!ModelState.IsValid)
            {
                return View(book);
            }

            // Tạo ID mới
            if (books.Count > 0)
            {
                book.Id = books.Max(b => b.Id) + 1;
            }
            else
            {
                book.Id = 1;
            }

            // Thêm sách
            books.Add(book);

            // Thông báo
            ViewBag.Message = "Thêm sách thành công!";

            return View(book);
        }
    }
}