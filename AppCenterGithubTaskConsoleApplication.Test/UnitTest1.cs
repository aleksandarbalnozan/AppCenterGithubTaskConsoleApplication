using AppCenterGithubTaskConsoleApplication.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using Xunit;

namespace AppCenterGithubTaskConsoleApplication.Test
{
    public class UnitTest1
    {
        [Fact]
        public void TestFileExist_WithCurrentFileLocation_ReturnsTrue()
        {
            bool fileExist = File.Exists(string.Concat(AppDomain.CurrentDomain.BaseDirectory, "secrets.json"));

            Assert.True(fileExist);
        }

        [Fact]
        public void TestPropertyNotNull_WithCurrentFileLocation_ReturnTrue()
        {
            var secrets = JsonConvert.DeserializeObject<UserSecrets>(File.ReadAllText(string.Concat(AppDomain.CurrentDomain.BaseDirectory, "secrets.json")));

            Assert.True(!String.IsNullOrEmpty(secrets.Header));
            Assert.True(!String.IsNullOrEmpty(secrets.Token));
        }
    }
}
