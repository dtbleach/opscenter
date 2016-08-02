using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpsPortal.Entities
{
    public class OperationAccidentEntity : IEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int CriticLevel { get; set; }

        public string Description { get; set; }

        public string RootCause { get; set; }

        public string Resolution { get; set; }

        public string Impaction { get; set; }

        public string ImpactedServices { get; set; }

        public DateTime ReportAt { get; set; }

        public DateTime Level1ResponsetAt { get; set; }

        public DateTime Level2ResponseAt { get; set; }

        public DateTime RootCauseIdentifyAt { get; set; }

        public string RootCauseIdentifyBy { get; set; }

        public string EstimatedFixedTime { get; set; }

        public string ActualFixedTime { get; set; }

        public DateTime FixedAt { get; set; }

        public string FixedBy { get; set; }

        public string KbPath { get; set; }

        public DateTime CreatedAt { get; set; }

        public string CreateBy { get; set; }

        public DateTime UpdatedAt { get; set; }

        public string UpdateBy { get; set; }

        public string OpsDashBoardBuilds { get; set; }
    }
}