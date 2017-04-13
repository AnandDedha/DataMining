using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace DataVisualization.Models
{
    [Serializable()]
    public class ROW
    {
        [System.Xml.Serialization.XmlElement("PERMIT_NUM")]
        public string PERMIT_NUM { get; set; }

        [System.Xml.Serialization.XmlElement("REVISION_NUM")]
        public string REVISION_NUM { get; set; }

        [System.Xml.Serialization.XmlElement("PERMIT_TYPE")]
        public string PERMIT_TYPE { get; set; }

        [System.Xml.Serialization.XmlElement("STRUCTURE_TYPE")]
        public string STRUCTURE_TYPE { get; set; }

        [System.Xml.Serialization.XmlElement("WORK")]
        public string WORK { get; set; }

        [System.Xml.Serialization.XmlElement("STREET_NUM")]
        public string STREET_NUM { get; set; }

        [System.Xml.Serialization.XmlElement("STREET_NAME")]
        public string STREET_NAME { get; set; }

        [System.Xml.Serialization.XmlElement("STREET_TYPE")]
        public string STREET_TYPE { get; set; }

        [System.Xml.Serialization.XmlElement("STREET_DIRECTION")]
        public string STREET_DIRECTION { get; set; }

        [System.Xml.Serialization.XmlElement("POSTAL")]
        public string POSTAL { get; set; }

        [System.Xml.Serialization.XmlElement("APPLICATION_DATE")]
        public string APPLICATION_DATE { get; set; }

        [System.Xml.Serialization.XmlElement("ISSUED_DATE")]
        public string ISSUED_DATE { get; set; }

        [System.Xml.Serialization.XmlElement("COMPLETED_DATE")]
        public string COMPLETED_DATE { get; set; }

        [System.Xml.Serialization.XmlElement("STATUS")]
        public string STATUS { get; set; }

        [System.Xml.Serialization.XmlElement("DESCRIPTION")]
        public string DESCRIPTION { get; set; }
    }


    [Serializable()]
    [System.Xml.Serialization.XmlRoot("SOLARHOTWATER")]
    public class SOLARHOTWATER
    {
        [XmlArray("ROWSET")]
        [XmlArrayItem("ROW", typeof(ROW))]
        public ROW[] ROW { get; set; }
    }

}