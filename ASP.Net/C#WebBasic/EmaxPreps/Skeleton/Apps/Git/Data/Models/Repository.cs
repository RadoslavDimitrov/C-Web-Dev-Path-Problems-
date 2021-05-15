using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Git.Data.Models
{
    public class Repository
    {
        public Repository()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Commits = new HashSet<Commit>();
        }

        [Key]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsPublic { get; set; }
        [Required]
        public string OwnerId { get; set; }
        [Required]
        public virtual User Owner { get; set; }
        public virtual ICollection<Commit> Commits { get; set; }
    }
}

