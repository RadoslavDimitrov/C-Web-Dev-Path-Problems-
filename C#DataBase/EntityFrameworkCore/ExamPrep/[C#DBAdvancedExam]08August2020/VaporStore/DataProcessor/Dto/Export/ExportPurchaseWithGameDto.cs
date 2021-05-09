using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace VaporStore.DataProcessor.Dto.Export
{
    [XmlType("Purchase")]
    public class ExportPurchaseWithGameDto
    {
        [XmlElement("Card")]
        public string CardNumber { get; set; }
        [XmlElement("Cvc")]
        public string Cvc { get; set; }
        [XmlElement("Date")]
        public string Date { get; set; }

        public ExportGameDto Game { get; set; }
    }
}

//< Purchase >

//        < Card > 7991 7779 5123 9211 </ Card >
   

//           < Cvc > 340 </ Cvc >
   

//           < Date > 2017 - 08 - 31 17:09 </ Date >
          

//                  < Game
