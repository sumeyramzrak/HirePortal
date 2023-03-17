﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hireportal.Data.Request.Contracts
{
    public class EditCompanyUserRequestDto
    {
        public Guid UserId { get; set; }
        public Guid CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string UserName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
