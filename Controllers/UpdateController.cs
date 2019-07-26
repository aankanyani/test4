using test4.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;
using System;

namespace test4.Controllers
{
    public class UpdateController : Controller
    {
        // GET: Home
        public ActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Update(PlayersModel player)
        {
            string constr = ConfigurationManager.ConnectionStrings["Constring"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "INSERT INTO players(name, surname, email, date) VALUES(@Name, @Surname, @Email, @date)";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.Parameters.AddWithValue("@Name", player.name);
                    cmd.Parameters.AddWithValue("@Surname", player.surname);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            return View(player);
        }
    }
}