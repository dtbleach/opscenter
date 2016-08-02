using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpsPortal.Entities
{
    public class JenkinsJobEntity : IEntity
    {
        public int Id { get; set; }
        public string ServiceName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime LaterTime { get; set; }
        public string BuildNumber { get; set; }
        public int Status { get; set; }

    }
}