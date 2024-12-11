namespace WebApplication1
{
    // LoginController.cs
    using Microsoft.AspNetCore.Mvc;

    public class LoginController : Controller
    {
        private static readonly List<User> Users = new()
    {
        new User { Username = "admin", Password = "admin123" },
        new User { Username = "user", Password = "user123" }
          };

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Validate(string username, string password)
        {
            var user = Users.FirstOrDefault(u =>
                u.Username == username && u.Password == password);

            if (user != null)
            {
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }

    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
