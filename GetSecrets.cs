using AppCenterGithubTaskConsoleApplication.Models;
using Newtonsoft.Json;
using System;
using System.IO;

namespace AppCenterGithubTaskConsoleApplication
{
    public class GetSecrets
    {
        public string Header { get; set; }
        public string Token { get; set; }

        public GetSecrets()
        {
            var secrets = JsonConvert.DeserializeObject<UserSecrets>(File.ReadAllText(string.Concat(AppDomain.CurrentDomain.BaseDirectory, "secrets.json")));
            Header = secrets.Header;
            Token = secrets.Token;
        }
    }
}
