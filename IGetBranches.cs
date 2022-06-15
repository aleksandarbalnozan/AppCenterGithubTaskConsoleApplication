using AppCenterGithubTaskConsoleApplication.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppCenterGithubTaskConsoleApplication
{
    public interface IGetBranches
    {
        Task<List<Rootobject>> GetBranchesAsync(string header, string token, string ownerName = "balnozan-aleksandar", string appName = "AppCenter-Xamarin-GithubTask");
    }
}