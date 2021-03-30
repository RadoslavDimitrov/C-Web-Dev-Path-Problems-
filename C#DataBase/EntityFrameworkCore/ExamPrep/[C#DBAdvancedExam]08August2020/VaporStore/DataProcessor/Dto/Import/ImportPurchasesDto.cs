using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace VaporStore.DataProcessor.Dto.Import
{
    [XmlType("Purchase")]
    public class ImportPurchasesDto
    {
        [XmlAttribute("title")]
        public string Title { get; set; }
        [XmlElement("Type")]
        public string Type { get; set; }
        [XmlElement("Key")]
        [RegularExpression(@"^[A-Z,0-9]{4}-[A-Z,0-9]{4}-[A-Z,0-9]{4}$")]
        public string Key { get; set; }
        [XmlElement("Card")]
        [RegularExpression(@"^(\d){4} (\d){4} (\d){4} (\d){4}$")]
        public string CardNumber { get; set; }
        [XmlElement("Date")]
        public string Date { get; set; }
    }
}


                


