using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AppCenterGithubTaskConsoleApplication
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // Get Secrets
            var userSecrets = new GetSecrets();
            string header = userSecrets.Header;
            var token = userSecrets.Token;

            // Instanciate the GetBranches cobject
            var getBranches = new GetBranches();
            var branches = await getBranches.GetBranchesAsync(header, token);

            // print all branches
            foreach (var branch in branches)
            {
                Console.WriteLine("Available branch: {0}", branch.branch.name);
            }

            var triggerBuild = new TriggerBuild();

            // Print branches where the build is being triggered
            foreach (var branch in branches)
            {
                Console.WriteLine("Triggering build for {0}", branch.branch.name);
                await triggerBuild.CreateBuildAsync(header, token, branch.branch.name, branch.branch.commit.sha);
            }

            var getTriggeredBuildStatus = new GetTriggeredBuild();
            // Print build status every 2.5 min
            foreach (var branch in branches)
            {

                GetTriggeredBuild._isStatusCompleted = false;


                while (!GetTriggeredBuild._isStatusCompleted)
                {
                    var triggeredBuildStatus = await getTriggeredBuildStatus.GetBuildStatusesAsync(header, token, branch.branch.name);


                    string buildUrl = string
                        .Format("https://appcenter.ms/users/balnozan-aleksandar/apps/AppCenter-Xamarin-GithubTask/build/branches/{0}/builds/{1}",
                        branch.branch.name, triggeredBuildStatus.id);

                    if (triggeredBuildStatus.status == "completed" || triggeredBuildStatus.status == "failed" || triggeredBuildStatus.status == "canceled")
                    {
                        GetTriggeredBuild._isStatusCompleted = true;
                    }
                    else
                    {
                        // sleep for 125s
                        Thread.Sleep(125000);
                    }

                    Console.WriteLine("{0} build {1} in 125s. Link to build logs: {2}", branch.branch.name, triggeredBuildStatus.status, buildUrl);
                }
            }

            Console.ReadLine();
        }


    }
}
