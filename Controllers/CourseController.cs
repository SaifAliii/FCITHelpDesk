using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace WebApplication1.Controllers
{
    public class CourseController : Controller
    {
        [NonAction]
        public List<Contribution> getContribs(int id)
        {
            List<Contribution> contributions = new List<Contribution>();
            
            SqlConnection conn = new(Helper.connectionString);
            try
            {
                conn.Open();


                String query = @"SELECT * FROM contribution where course=@course";
                SqlCommand cmd = new(query, conn);

                cmd.Parameters.AddWithValue("@course", Helper.Courses[id]);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Contribution contribution = new Contribution();
                    contribution.ContribId = reader.GetInt32(0);
                    contribution.Fname = reader.GetString(1);
                    contribution.Lname = reader.GetString(2);
                    contribution.Title = reader.GetString(3);
                    contribution.Path = reader.GetString(4);
                    contribution.Course = reader.GetString(5);
                    contribution.Type = reader.GetString(6);
                    contribution.Link = reader.GetString(7);
                    contribution.Date = reader.GetDateTime(8);
                    contributions.Add(contribution);
                }
                return contributions;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }

        }

        public IActionResult Index(int courseId)
        {
            if (Helper.loggedInUser == null)
                return View("Views/Welcome/Index.cshtml");

            ViewBag.contribs = getContribs(courseId);
            ViewBag.courseName = CoursesController.getCourses()[courseId];
            ViewBag.user = Helper.loggedInUser;
            return View();
        }

        public FileResult ShowMedia(string? path)
        {
            return File("~/Data/" + path, "*/*");
        }
        public FileResult DownloadMedia(string? path)
        {
            return File("~/Data/" + path, "*/*", path);
        }
    }
}
