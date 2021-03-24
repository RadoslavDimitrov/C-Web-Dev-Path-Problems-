
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace SoftJail.DataProcessor.ImportDto
{
    public class ImportMailDto
    {
        [JsonProperty("Description")]
        [Required]
        public string Description { get; set; }
        [JsonProperty("Sender")]
        [Required]
        public string Sender { get; set; }
        [JsonProperty("Address")]
        [Required]
        [RegularExpression(@"^[ A-Za-z0-9]*(s{1}t{1}r{1}.{1})$")]
        public string Address { get; set; }
    }
}


//"Mails": [
//      {
//        "Description": "Invalid FullName",
//        "Sender": "Invalid Sender",
//        "Address": "No Address"
//      },
//      {
//    "Description": "Do not put this in your code",
//        "Sender": "My Ansell",
//        "Address": "ha-ha-ha"
//      }
//    ]
