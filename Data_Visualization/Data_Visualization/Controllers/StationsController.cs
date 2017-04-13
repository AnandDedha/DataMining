using Data_Visualization.Models;
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
    public class StationsController : Controller
    {
        public ActionResult Index()
        {
            stationData stations = null;

            string path = "C:\\Users\\DSD-PC2\\Desktop\\Big Data Analytics- 2nd Semester\\Social Data Mining Techniques\\Assignments\\2nd_assignment\\Data_Visualization\\Data_Visualization\\App_Data\\stations.xml";

            XmlSerializer serializer = new XmlSerializer(typeof(stationData));

            StreamReader reader = new StreamReader(path);
            stations = (stationData)serializer.Deserialize(reader);
            reader.Close();

            return View(stations.station.ToList());

        }
    }
}