using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P03_FootballBetting.Data.Models
{
    public class PlayerStatistic
    {
        //TODO composite primary key (GameId, PlayerId)
        [Required]
        public int GameId { get; set; }
        [Required]
        [ForeignKey("GameId")]
        public Game Game { get; set; }

        public int PlayerId { get; set; }
        [Required]
        [ForeignKey("PlayerId")]
        public Player Player { get; set; }

        [Required]
        public int ScoredGoals { get; set; }
        [Required]
        public int Assists { get; set; }
        [Required]
        public int MinutesPlayed { get; set; }
    }
}
