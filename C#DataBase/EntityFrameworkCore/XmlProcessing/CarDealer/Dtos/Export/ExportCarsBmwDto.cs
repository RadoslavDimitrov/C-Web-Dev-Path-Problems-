using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.Dtos.Export
{
    [XmlType("car")]
    public class ExportCarsBmwDto
    {
        [XmlAttribute("id")]
        public string Id { get; set; }
        [XmlAttribute("model")]
        public string Model { get; set; }
        [XmlAttribute("travelled-distance")]
        public string TravelledDistance { get; set; }
    }
}

//< car id = "7" model = "1M Coupe" travelled - distance = "39826890" /> 