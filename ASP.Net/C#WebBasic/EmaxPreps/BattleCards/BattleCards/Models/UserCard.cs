using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BattleCards.Models
{
    public class UserCard
    {
        public string UserId { get; set; }
        [Required]
        public User User { get; set; }
        public int CardId { get; set; }
        [Required]
        public Card Card { get; set; }
    }
}
