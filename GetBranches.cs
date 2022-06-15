﻿using AppCenterGithubTaskConsoleApplication.Models;
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
    public class GetBranches
    {
        private static readonly HttpClient _client = new HttpClient();

        /// <summary>
        /// Gets all branches async
        /// </summary>
        /// <param name="header">Environment secret</param>
        /// <param name="token">Environment secret</param>
        /// <param name="ownerName">Owner name</param>
        /// <param name="appName">App name</param>
        /// <returns>A <see cref="List{string}" </returns>
        public static async Task<List<Rootobject>> GetBranchesAsync(string header, string token,
            string ownerName = "balnozan-aleksandar", string appName= "AppCenter-Xamarin-GithubTask")
        {
            try
            {
                _client.DefaultRequestHeaders.Accept.Clear();
                _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                _client.DefaultRequestHeaders.Add(header, token);

                string url = string.Format("https://api.appcenter.ms/v0.1/apps/{0}/{1}/branches", ownerName, appName);
                var result = await _client.GetStreamAsync(url);

                var branches = await JsonSerializer.DeserializeAsync<List<Rootobject>>(result);

                if (branches is null)
                {
                    throw new ArgumentException("There are no available branches", nameof(branches));
                }

                return branches;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
