using AppCenterGithubTaskConsoleApplication.Dto.TriggerBuildDto;
using System.Threading.Tasks;

namespace AppCenterGithubTaskConsoleApplication
{
    public interface IGetTriggeredBuild
    {
        Task<TriggerBuildDto> GetBuildStatusesAsync(string header, string token, string branchName, string ownerName = "balnozan-aleksandar", string appName = "AppCenter-Xamarin-GithubTask");
    }
}