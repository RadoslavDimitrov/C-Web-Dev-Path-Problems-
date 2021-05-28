using Git.Services;
using Git.ViewModels;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Controllers
{
    public class RepositoriesController : Controller
    {
        private readonly IRepositoryService repositoryService;

        public RepositoriesController(IRepositoryService repositoryService)
        {
            this.repositoryService = repositoryService;

        }
        public HttpResponse All()
        {
            var repos = this.repositoryService.GetAllRepos();

            return this.View(repos);
        }

        public HttpResponse Create()
        {
            if (!IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }
        [HttpPost]
        public HttpResponse Create(CreateRepositoryInputModel input)
        {
            if (!IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.GetUserId();

            var repoId = this.repositoryService.CreateRepo(input.Name, input.RepositoryType, userId);

            if(repoId == null)
            {
                return Redirect("/Repositories/Create");
            }

            return this.Redirect("/Repositories/All");
        }
    }
}
