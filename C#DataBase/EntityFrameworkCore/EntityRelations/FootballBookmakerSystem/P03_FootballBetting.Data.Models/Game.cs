using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P03_FootballBetting.Data.Models
{
    public class Game
    {
        public int GameId { get; set; }

        public int HomeTeamId { get; set; }
        [Required]
        [ForeignKey("HomeTeamId")]
        public Team HomeTeam { get; set; }

        public int AwayTeamId { get; set; }
        [Required]
        [ForeignKey("AwayTeamId")]
        public Team AwayTeam { get; set; }
        public int HomeTeamGoals { get; set; }
        public int AwayTeamGoals { get; set; }

        public DateTime DateTime { get; set; }

        public double HomeTeamBetRate { get; set; }

        public double AwayTeamBetRate { get; set; }
        public double DrawBetRate { get; set; }

        public string Result { get; set; }
    }
}
