using AppCenterGithubTaskConsoleApplication.Dto.TriggerBuildDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace AppCenterGithubTaskConsoleApplication
{
    public class GetTriggeredBuild
    {
        //private static readonly HttpClient _client;
        public static bool _isStatusCompleted = false;

        /// <summary>
        /// Gets build status async
        /// </summary>
        /// <param name="header"></param>
        /// <param name="token"></param>
        /// <param name="branchName"></param>
        /// <param name="ownerName"></param>
        /// <param name="appName"></param>
        /// <returns>Returns the last build attempt</returns>
        public async Task<TriggerBuildDto> GetBuildStatusesAsync(string header, string token, string branchName,
            string ownerName = "balnozan-aleksandar", string appName = "AppCenter-Xamarin-GithubTask")
        {
            try
            {
                using (var _client = new HttpClient())
                {
                    _client.DefaultRequestHeaders.Accept.Clear();
                    _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    _client.DefaultRequestHeaders.Add(header, token);

                    string url = string.Format("https://api.appcenter.ms/v0.1/apps/{0}/{1}/branches/{2}/builds", ownerName, appName, branchName);
                    var result = await _client.GetStreamAsync(url);

                    var buildStatus = await JsonSerializer.DeserializeAsync<List<TriggerBuildDto>>(result);

                    if (buildStatus is null)
                    {
                        throw new ArgumentException("There are no available builds", nameof(buildStatus));
                    }

                    return buildStatus.FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
