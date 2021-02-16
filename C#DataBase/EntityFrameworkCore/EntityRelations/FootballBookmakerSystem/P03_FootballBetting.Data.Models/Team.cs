using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P03_FootballBetting.Data.Models
{
    public class Team
    {
        public int TeamId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string LogoUrl { get; set; }

        [Required]
        [MaxLength(10)]
        public string Initials { get; set; }

        [Required]
        public decimal Budget { get; set; }

        public int PrimaryKitColorId { get; set; }

        [Required]
        [ForeignKey("PrimaryKitColorId")]
        public Color PrimaryKitColor { get; set; }

        public int SecondaryKitColorId { get; set; }

        [Required]
        [ForeignKey("SecondaryKitColorId")]
        public Color SecondaryKitColor { get; set; }

        public int TownId { get; set; }
        [Required]
        [ForeignKey("TownId")]
        public Town Town { get; set; }

        public ICollection<Game> HomeGames { get; set; } = new HashSet<Game>();
        public ICollection<Game> AwayGames { get; set; } = new HashSet<Game>();
        public ICollection<Player> Players { get; set; } = new HashSet<Player>();

    }
}
