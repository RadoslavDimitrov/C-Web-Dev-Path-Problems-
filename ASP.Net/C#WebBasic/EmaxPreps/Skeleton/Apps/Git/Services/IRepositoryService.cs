using Git.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Services
{
    public interface IRepositoryService
    {
        string CreateRepo(string name, string repositoryType, string userId);

        IEnumerable<RepositoryModel> GetAllRepos();

        string GetRepositoryName(string id);
    }
}
