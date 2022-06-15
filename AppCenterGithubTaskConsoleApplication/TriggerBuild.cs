using AppCenterGithubTaskConsoleApplication.Dto.TriggerBuildDto;
using AppCenterGithubTaskConsoleApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AppCenterGithubTaskConsoleApplication
{
    public class TriggerBuild : ITriggerBuild
    {
        /// <summary>
        /// Creates a build by the branch name and the last commit
        /// </summary>
        /// <param name="header"></param>
        /// <param name="token"></param>
        /// <param name="branchName"></param>
        /// <param name="commitId"></param>
        /// <param name="ownerName"></param>
        /// <param name="appName"></param>
        /// <returns></returns>
        public async Task CreateBuildAsync(string header, string token, string branchName,
            string commitId, string ownerName = "balnozan-aleksandar", string appName = "AppCenter-Xamarin-GithubTask")
        {
            var rootObject = new Rootobject
            {
                branch = new Branch
                {
                    commit = new Commit
                    {
                        sha = commitId
                    }
                }
            };


            try
            {

                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    //_client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add(header, token);

                    string url = string.Format(
                        "https://api.appcenter.ms/v0.1/apps/{0}/{1}/branches/{2}/builds",
                        ownerName, appName, branchName);

                    var build = JsonSerializer.Serialize(rootObject);

                    var requestContent = new StringContent(build, encoding: Encoding.UTF8, "application/json");

                    var result = await client.PostAsync(url, requestContent);

                    result.EnsureSuccessStatusCode();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
