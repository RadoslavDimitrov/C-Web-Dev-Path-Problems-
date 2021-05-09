using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace VaporStore.DataProcessor.Dto.Export
{
    [XmlType("User")]
    public class ExportUserDto
    {
        [XmlAttribute("username")]
        public string Username { get; set; }
        [XmlElement("Purchases")]
        public ExportPurchaseWithGameDto[] Purchases { get; set; }
        [XmlElement("TotalSpent")]
        public decimal TotalSpent { get; set; }
    }
}

//< User username = "mgraveson" >
 

//     < Purchases >
//     </ Purchases >

//    < TotalSpent > 72.48 </ TotalSpent > 