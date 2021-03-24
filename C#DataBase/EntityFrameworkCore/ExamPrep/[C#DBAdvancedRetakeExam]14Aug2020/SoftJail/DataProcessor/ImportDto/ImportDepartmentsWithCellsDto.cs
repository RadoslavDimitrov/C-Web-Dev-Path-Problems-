using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace SoftJail.DataProcessor.ImportDto
{
    public class ImportDepartmentsWithCellsDto
    {
        [JsonProperty("Name")]
        [Required]
        [MinLength(3)]
        [MaxLength(25)]
        public string Name { get; set; }
        
        [JsonProperty("Cells")]
        [Required]
        public ImportCellDto[] Cells { get; set; }
    }
}
