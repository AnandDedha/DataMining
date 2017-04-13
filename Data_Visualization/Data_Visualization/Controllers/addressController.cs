using DataVisualization.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Serialization;

namespace Data_Visualization.Controllers
{
    public class addressController : Controller
    {
        public ActionResult Index()
        {
            SOLARHOTWATER ROWSET = null;

            string path = "C:\\Users\\DSD-PC2\\Desktop\\Big Data Analytics- 2nd Semester\\Social Data Mining Techniques\\Assignments\\2nd_assignment\\Data_Visualization\\Data_Visualization\\App_Data\\solarhotwater.xml";

            XmlSerializer serializer = new XmlSerializer(typeof(SOLARHOTWATER));

            StreamReader reader = new StreamReader(path);
            ROWSET = (SOLARHOTWATER)serializer.Deserialize(reader);
            reader.Close();

            return View(ROWSET.ROW.ToList());

        }
    }
}