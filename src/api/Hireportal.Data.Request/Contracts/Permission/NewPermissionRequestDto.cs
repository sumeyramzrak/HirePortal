﻿
namespace Hireportal.Data.Request.Contracts
{
    public class NewPermissionRequestDto
    {
        public Guid CompanyUserId { get; set; }
        public Guid? LookUpId { get; set; }
        public Guid? LookUpTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double PermissionDayCount { get; set; }
        public bool IsApproved { get; set; }
        public Guid ApprovedManagerID { get; set; }
        public DateTime ApprovedDate { get; set; }
        public string Information { get; set; }
    }
}
