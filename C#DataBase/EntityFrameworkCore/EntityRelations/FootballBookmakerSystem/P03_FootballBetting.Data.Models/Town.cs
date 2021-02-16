﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P03_FootballBetting.Data.Models
{
    public class Town
    {
        public int TownId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public int CountryId { get; set; }
        [Required]
        [ForeignKey("CountryId")]
        public Country Country { get; set; }
    }
}
