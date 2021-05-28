using Git.Services;
using Git.ViewModels;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Controllers
{
    public class CommitsController : Controller
    {
        private readonly ICommitsService commitsService;
        private readonly IRepositoryService repositoryService;

        public CommitsController(ICommitsService commitsService, IRepositoryService repositoryService)
        {
            this.commitsService = commitsService;
            this.repositoryService = repositoryService;
        }
        public HttpResponse Create(string id)
        {
            if (!IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            string repoName = this.repositoryService.GetRepositoryName(id);
            var viewModel = new CreateCommitInputModel
            {
                Id = id,
                Name = repoName
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public HttpResponse Create(CreateCommitModel model, string id)
        {
            if (!IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (String.IsNullOrEmpty(model.Description) || model.Description.Length < 5)
            {
                return this.Redirect("/Commits/Create");
            }

            var userId = this.GetUserId();

            this.commitsService.CreateCommit(userId, id, model.Description);

            return this.Redirect("/Commits/All");
        }


        public HttpResponse All()
        {
            var userId = this.GetUserId();

            var commits = this.commitsService.GetAllCommitsFromUser(userId);

            return this.View(commits);
        }
    }
}
