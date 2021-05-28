using Git.Data;
using Git.Data.Models;
using Git.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Git.Services
{
    public class CommitsService : ICommitsService
    {
        private readonly ApplicationDbContext db;

        public CommitsService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public string CreateCommit(string creatorId, string repositoryId, string description)
        {
            var commit = new Commit
            {
                Id = Guid.NewGuid().ToString(),
                CreatedOn = DateTime.Now,
                CreatorId = creatorId,
                RepositoryId = repositoryId,
                Description = description
            };

            this.db.Commits.Add(commit);
            this.db.SaveChanges();

            return commit.Id;
        }

        public ICollection<CommitViewModel> GetAllCommitsFromUser(string userId)
        {
            return this.db.Commits.Where(c => c.CreatorId == userId).Select(x => new CommitViewModel
            {
                CreatedOn = x.CreatedOn,
                Description = x.Description,
                Repository = x.Repository.Name,
                Id = x.Id
            })
                .ToList();
        }
    }
}
