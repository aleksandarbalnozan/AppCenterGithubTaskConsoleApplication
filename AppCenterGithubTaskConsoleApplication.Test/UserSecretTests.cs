using AppCenterGithubTaskConsoleApplication.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using Xunit;

namespace AppCenterGithubTaskConsoleApplication.Test
{
    public class UserSecretTests
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
            var getSecrets = new GetSecrets();

            Assert.True(!String.IsNullOrEmpty(getSecrets.Header));
            Assert.True(!String.IsNullOrEmpty(getSecrets.Token));
        }
    }
}
