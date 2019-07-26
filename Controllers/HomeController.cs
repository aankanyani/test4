using test4.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Net;

namespace test4.Controllers
{
    public class HomeController : Controller
    {
        string constr = ConfigurationManager.ConnectionStrings["Constring"].ConnectionString;
        string query;
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            List<ViewData> viewData = new List<Models.ViewData>();
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    query = "SELECT * FROM TestNetAmu";
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        con.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    ViewData view = new ViewData();
                                    view.id = reader[0].ToString();
                                    view.name = reader[1].ToString();
                                    view.surname = reader[2].ToString();
                                    viewData.Add(view);
                                }
                            }
                        }

                    }

                }

            }
            catch (Exception ex)
            {

                throw;
            }

            return View(viewData);
        }

        [HttpPost]
        public ActionResult Index(SaveDataRequest player)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                query = "INSERT INTO TestNetAmu(name, surname) VALUES(@name, @surname)";
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

        // GET: /Edit/5
        public ActionResult Edit(int? id)
        {
            ViewData view = new ViewData();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (SqlConnection con = new SqlConnection(constr))
            {

                query = "SELECT * FROM TestNetAmu WHERE id = '" + id + "'";
                using (SqlCommand cmd = new SqlCommand(query))
                {

                    cmd.Connection = con;
                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {

                                view.id = reader[0].ToString();
                                view.name = reader[1].ToString();
                                view.surname = reader[2].ToString();
                            }
                        }
                    }
                }

            }
            return View(view);
        }

        // POST: TestNetAmus/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,surname")] ViewData ViewData)
        {
            ViewData view = new ViewData();
            using (SqlConnection con = new SqlConnection(constr))
            {

                query = "UPDATE TestNetAmu SET name = '" + ViewData.name + "', surname = '" + ViewData.surname + "' WHERE id = '" + ViewData.id + "'";
                using (SqlCommand cmd = new SqlCommand(query))
                {

                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return RedirectToAction("About");
                }

            }
        }

        // GET: /Delete/5
        public ActionResult Delete(int? id)
        {
            ViewData view = new ViewData();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (SqlConnection con = new SqlConnection(constr))
            {
                
                query = "SELECT * FROM TestNetAmu WHERE id = '" + id + "'";
                using (SqlCommand cmd = new SqlCommand(query))
                {

                    cmd.Connection = con;
                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {

                                view.id = reader[0].ToString();
                                view.name = reader[1].ToString();
                                view.surname = reader[2].ToString();
                            }
                        }
                    }
                }

            }
            return View(view);
        }

        // POST: /Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                query = "DELETE FROM TestNetAmu WHERE id = '" + id + "'";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                }

            }
            return RedirectToAction("About");
        }
    }
}