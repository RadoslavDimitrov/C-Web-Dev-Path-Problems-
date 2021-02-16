using P03_FootballBetting.Data.Models.Enumerators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P03_FootballBetting.Data.Models
{
    public class Bet
    {
        public int BetId { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public Prediction Prediction { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        public int UserId { get; set; }
        [Required]
        [ForeignKey("UserId")]
        public User User { get; set; }

        public int GameId { get; set; }
        [Required]
        [ForeignKey("GameId")]

        public Game Game { get; set; }
    }
}
