using Core.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    // Kullanıcılar için kayıt modeli
    public class UserForRegisterDto : IDto
    {
        public string Password { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
    }
}
