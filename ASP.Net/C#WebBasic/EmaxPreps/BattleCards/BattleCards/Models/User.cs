using SIS.MvcFramework;
using System.Collections.Generic;

namespace BattleCards.Models
{
    public class User : IdentityUser<string>
    {
        public virtual ICollection<UserCard> UserCards { get; set; }
    }
}
