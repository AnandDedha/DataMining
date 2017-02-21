using MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Odbc;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class ArchivesController : Controller
    {
        private DataContext db = new DataContext();
        // GET: Archives
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ArchiveStudentCountsCourse()
        {
            return View();
        }

        public ActionResult ArchiveCourseCounts()
        {
            return View();
        }
        public JsonResult ArchiveStudentCounts()
        {
            List<ArchiveStudentCount> items = new List<ArchiveStudentCount>();

            items.Add(new ArchiveStudentCount { Year = "2014", Count = 120 });
            items.Add(new ArchiveStudentCount { Year = "2015", Count = 130 });
            items.Add(new ArchiveStudentCount { Year = "2016", Count = 140 });
            items.Add(new ArchiveStudentCount { Year = "2017", Count = 202 });

            return (Json(items,JsonRequestBehavior.AllowGet));
        }

        public JsonResult ArchiveStudentCountsFromFile()
        {
            List<ArchiveStudentCount> items = new List<ArchiveStudentCount>();
            String filepath = Server.MapPath("~/App_Data/ArchiveStudentCounts.csv");
            var reader = new StreamReader(filepath);
            int index = 0;
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');
                if (index > 0)
                {
                    items.Add(new ArchiveStudentCount { Year = values[0], Count = Convert.ToInt32(values[1]) });
                }
                index++;
            }
            reader.Close();
            
            return (Json(items, JsonRequestBehavior.AllowGet));
        }

        public JsonResult ArchiveStudentCountsCoursefunction()
        {

            var viewStudentsInCourses = db.viewStudentsInCourses;

            return (Json(viewStudentsInCourses, JsonRequestBehavior.AllowGet));

        }
        public JsonResult ArchiveCourseCountsfunction()
        {

            var viewStudentsEnrolled = db.viewStudentsEnrolled;

            return (Json(viewStudentsEnrolled, JsonRequestBehavior.AllowGet));

        }
        public ViewResult Hive()
        {
            List<Student> items = new List<Student>();

            String ConnectionString = @"dsn=IBMHive;UID=a2003563;PWD=Rsd@12345";
            //String ConnectionString = String.Format("DSN=IBM Hive;UID={0};PWD={1}",Security.UserName, Security.Password);
            using (OdbcConnection conn =
             new OdbcConnection(ConnectionString))

            {
                conn.Open();
                OdbcCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM students;";
                DbDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    items.Add(new Student {
                        StudentId = Convert.ToInt32(dr["StudentId"].ToString()),
                        FirstName = dr["FirstName"].ToString(),
                        LastName = dr["LastName"].ToString(),
                        DateOfBirth= DateTime.Parse(dr["DateOfBirth"].ToString()),
                        Email = dr["Email"].ToString(),
                        Gender = dr["Gender"].ToString(),
                        CreateDate= DateTime.Parse(dr["CreateDate"].ToString()),
                        EditDate= DateTime.Parse(dr["EditDate"].ToString())
                         });
                }
                conn.Close();
            }
            return (View(items));
        }

    }
}