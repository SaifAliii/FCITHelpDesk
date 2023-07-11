using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using System.Data;
using Microsoft.Data.SqlClient;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        
        public List<User> Get_all_users_from_db()
        {
            SqlConnection conn = new(Helper.connectionString);
            try
            {
                CmsContext cx = new CmsContext();
                List<User> users = cx.Users.ToList();
                for(int i = 0; i < users.Count; i++)
                {
                    User user = new()
                    {
                        Id = Convert.ToInt32(users[i].Id),
                        Fname = users[i].Fname.ToString().Trim(),
                        Lname = users[i].Lname.ToString().Trim(),
                        Email = users[i].Email.ToString().Trim(),
                        Password = users[i].Password.ToString().Trim(),
                        IsAdmin = users[i].IsAdmin.ToString().Trim()
                    };
                }
                return users;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }
        public IActionResult Index()
        {
            List<User> all_users_in_db = this.Get_all_users_from_db();
            return View(all_users_in_db);
        }

        // verify the login using data from the form...
        [HttpPost]
        public void VerifyLogin(IFormCollection form)
        {
            List<User> users = Get_all_users_from_db();
            string email = form["loginid"].ToString().Trim() + "@pucit.edu.pk";
            email = email.ToLower();
            String password = form["password"].ToString().Trim();

            Console.WriteLine(users.Count());

            foreach (User user in users)
            {
                Console.WriteLine(user.Email);
                Console.WriteLine(user.Password);
                if (email.Equals(user.Email) && password.Equals(user.Password))
                {
                    Helper.loggedInUser = user;
                    Console.WriteLine("Authenticated: " + user.Lname);
                    Response.Redirect("/Home");
                    return;
                }
            }
           Response.Redirect("/Login");
        }
    }
}
