using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCenterGithubTaskConsoleApplication.Dto.TriggerBuildDto
{

    public class TriggerBuildDto
    {
        public int id { get; set; }
        public string buildNumber { get; set; }
        public string queueTime { get; set; }
        public string startTime { get; set; }
        public string finishTime { get; set; }
        public string lastChangedDate { get; set; }
        public string status { get; set; }
        public string result { get; set; }
        public string sourceBranch { get; set; }
        public string sourceVersion { get; set; }
    }

}
