using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Git.Data.Models
{
    public class Commit
    {
        public Commit()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        [Key]
        public string Id { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatorId { get; set; }
        [Required]
        public virtual User Creator { get; set; }
        public string RepositoryId { get; set; }
        [Required]
        public virtual Repository Repository { get; set; }
    }
}

