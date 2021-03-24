using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace SoftJail.DataProcessor.ImportDto
{
    public class ImportPrisonerDto
    {
        [JsonProperty("FullName")]
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string FullName { get; set; }
        [JsonProperty("Nickname")]
        [Required]
        [RegularExpression(@"^(T{1}h{1}e{1} )[A-Z]+[A-Za-z]*$")]
        public string Nickname { get; set; }
        [JsonProperty("Age")]
        [Range(18,65)]
        public int Age { get; set; }
        [JsonProperty("IncarcerationDate")]
        [Required]
        public string IncarcerationDate { get; set; }
        [JsonProperty("ReleaseDate")]
        public string ReleaseDate { get; set; }
        [JsonProperty("Bail")]
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal? Bail { get; set; }
        [JsonProperty("CellId")]
        public int CellId { get; set; }
        [JsonProperty("Mails")]
        public ImportMailDto[] Mails { get; set; }
    }
}
//"FullName": "", 

//    "Nickname": "The Wallaby", 

//    "Age": 32, 

//    "IncarcerationDate": "29/03/1957", 

//    "ReleaseDate": "27/03/2006", 


//    "Bail": null, 

//    "CellId": 5, 

//    "Mails": [
