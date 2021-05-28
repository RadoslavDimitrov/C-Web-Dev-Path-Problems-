using Git.Data;
using Git.Data.Models;
using Git.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Git.Services
{
    public class RepositoryService : IRepositoryService
    {
        private readonly ApplicationDbContext db;

        public RepositoryService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public string CreateRepo(string name, string repositoryType, string userId)
        {


            var repo = new Repository
            {
                Id = Guid.NewGuid().ToString(),
                Name = name,
                CreatedOn = DateTime.Now,
                OwnerId = userId,
            };

            if (repositoryType.ToLower() == "public")
            {
                repo.IsPublic = true;
            }
            else
            {
                repo.IsPublic = false;
            }

            this.db.Repositories.Add(repo);
            this.db.SaveChanges();

            return repo.Id;
        }

        public IEnumerable<RepositoryModel> GetAllRepos()
        {
            IEnumerable<RepositoryModel> repos = this.db.Repositories.Where(x => x.IsPublic == true).Select(r => new RepositoryModel
            {
                Id = r.Id,
                Name = r.Name,
                Owner = r.Owner.Username,
                CommitsCount = r.Commits.Count,
                CreatedOn = r.CreatedOn,
            })
            .ToList();

            return repos;
        }


        public string GetRepositoryName(string id)
        {
            return this.db.Repositories.Where(x => x.Id == id).Select(x => x.Name).FirstOrDefault();
        }
    }
}
