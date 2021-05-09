using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace TeisterMask.DataProcessor.ImportDto
{
    [XmlType("Project")]
    public class ImportProjectXmlDto
    {
        [XmlElement("Name")]
        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string ProjectName { get; set; }
        [XmlElement("OpenDate")]
        [Required]
        public string OpenDate { get; set; }
        [XmlElement("DueDate")]
        public string DueDate { get; set; }
        [XmlArray("Tasks")]
        public ImportTasksDto[] Tasks { get; set; }
    }
}
//< Project >

//    < Name > S </ Name >

//    < OpenDate > 25 / 01 / 2018 </ OpenDate >

//    < DueDate > 16 / 08 / 2019 </ DueDate >

//    < Tasks > 