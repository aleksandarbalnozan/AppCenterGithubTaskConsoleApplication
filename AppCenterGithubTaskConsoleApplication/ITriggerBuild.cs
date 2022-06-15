using AppCenterGithubTaskConsoleApplication.Dto.TriggerBuildDto;
using System.Threading.Tasks;

namespace AppCenterGithubTaskConsoleApplication
{
    public interface ITriggerBuild
    {
        Task CreateBuildAsync(string header, string token, string branchName, string commitId, string ownerName = "balnozan-aleksandar", string appName = "AppCenter-Xamarin-GithubTask");
    }
}