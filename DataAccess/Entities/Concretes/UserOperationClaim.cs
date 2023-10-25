﻿using DataAccess.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities.Concretes
{
    public class UserOperationClaim : IEntity
    {
        public int UserOperationClaimID { get; set; }
        public int UserID { get; set; }
        public int OperationClaimID { get; set; }
    }
}
