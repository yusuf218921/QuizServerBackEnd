﻿using DataAccess.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities.Concretes
{
    public class User : IEntity
    {
        public int UserID { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Username { get; set; }
        public bool Status { get; set; }
    }
}
