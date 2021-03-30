using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class ImportUsersDto
    {
        [Required]
        
        [RegularExpression(@"^[A-Z]{1}[a-z]+[ ][A-Z]{1}[a-z]+$")]
        public string FullName { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Range(3,103)]
        public int Age { get; set; }

        public ImportCardDto[] Cards { get; set; }
    }
}


//{
//    "FullName": "", 
//    "Username": "invalid", 
//    "Email": "invalid@invalid.com", 
//    "Age": 20, 
//    "Cards": [
//      {
//        "Number": "1111 1111 1111 1111", 
//        "CVC": "111", 
//        "Type": "Debit"
//      } 
//    ] 
//  }, 
