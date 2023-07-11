using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace WebApplication1.Controllers
{
    public class RegisterController : Controller
    {
        // GET: HomeController1
        public IActionResult Index()
        {
            ErrorViewModel evm = new();
            return View(evm);
        }

        [HttpPost]
        public void RegisterUser(IFormCollection form)
        {
            Console.Write("*************In the Register Controller***************");
            User user = new User();
            string fname = form["fname"].ToString().Trim();
            string lname = form["lname"].ToString().Trim();
            string email = form["roll"].ToString().Trim().ToLower();
            string password = form["password"].ToString().Trim();
            string password1 = form["password1"].ToString().Trim();
            string joinas = form["joinas"].ToString().Trim();

            email = email.ToLower() + "@pucit.edu.pk";
            char is_admin = 'N';
            if (joinas == "Admin") // if user request as registeration as Admin, set it to 'R' request, that'll either be approved or user will set to a normal user by the admin
                is_admin = 'R';
            user.Fname = fname;
            user.Lname = lname;
            user.Email = email;
            user.Password = password;
            user.IsAdmin = is_admin.ToString();
            CmsContext cx = new CmsContext();
            cx.Users.Add(user);
            cx.SaveChanges();
            Console.Write("*************Saved in DataBase i.e. User Registered***************");
            Response.Redirect("/Login");
        }
    }
}
