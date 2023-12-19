using Core.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concretes
{
    // OperationClaim tablosu (Kullanıcı rollerini tutuyor; admin, moderator vb.)
    public class OperationClaim : IEntity
    {
        public int OperationClaimID { get; set; }
        public string OperationClaimName { get; set; }
    }
}
