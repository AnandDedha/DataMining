using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Data_Visualization.Models
{
    [Serializable()]
    public class station
    {
        [System.Xml.Serialization.XmlElement("id")]
        public int id { get; set; }

        [System.Xml.Serialization.XmlElement("name")]
        public string name { get; set; }

        [System.Xml.Serialization.XmlElement("terminalName")]
        public string terminalName { get; set; }

        [System.Xml.Serialization.XmlElement("lastCommWithServer")]
        public string lastCommWithServer { get; set; }

        [System.Xml.Serialization.XmlElement("lat")]
        public string latitude { get; set; }

        [System.Xml.Serialization.XmlElement("long")]
        public string longitude { get; set; }

        [System.Xml.Serialization.XmlElement("installed")]
        public string installed { get; set; }

        [System.Xml.Serialization.XmlElement("locked")]
        public string locked { get; set; }

        [System.Xml.Serialization.XmlElement("installDate")]
        public string installDate { get; set; }

        [System.Xml.Serialization.XmlElement("removalDate")]
        public string removalDate { get; set; }

        [System.Xml.Serialization.XmlElement("temporary")]
        public string temporary { get; set; }

        [System.Xml.Serialization.XmlElement("public")]
        public string isPublic { get; set; }

        [System.Xml.Serialization.XmlElement("nbBikes")]
        public int nbBikes { get; set; }

        [System.Xml.Serialization.XmlElement("nbEmptyDocks")]
        public int nbEmptyDocks { get; set; }

        [System.Xml.Serialization.XmlElement("latestUpdateTime")]
        public string latestUpdateTime { get; set; }
    }


    [Serializable()]
    [System.Xml.Serialization.XmlRoot("stationData")]
    public class stationData
    {
        [XmlArray("stations")]
        [XmlArrayItem("station", typeof(station))]
        public station[] station { get; set; }
    }

}