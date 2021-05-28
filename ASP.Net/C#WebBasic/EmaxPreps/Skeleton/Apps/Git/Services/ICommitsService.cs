using Git.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Services
{
    public interface ICommitsService
    {
        string CreateCommit(string creatorId, string repositoryId, string description);

        ICollection<CommitViewModel> GetAllCommitsFromUser(string userId);
    }
}
