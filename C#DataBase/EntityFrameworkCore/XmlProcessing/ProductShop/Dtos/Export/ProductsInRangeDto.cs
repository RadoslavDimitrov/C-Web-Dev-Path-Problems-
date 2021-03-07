﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("Product")]
    public class ProductsInRangeDto
    {
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("price")]
        public decimal Price { get; set; }

        [XmlElement("buyer")]
        public string BuyerFullName { get; set; }
    }
}

//< Product >

//    < name > TRAMADOL HYDROCHLORIDE </ name >
   

//       < price > 516.48 </ price >
   

//     </ Product >
