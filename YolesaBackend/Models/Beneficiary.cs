using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YolesaBackend.Models
{
    public class Beneficiary
    {
        public int Id { get; set; }

        public Title Title { get; set; }

        public string FullNames { get; set; }

        public string Surname { get; set; }

        public Gender Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public bool IsSACitizen { get; set; }

        public string IDNumber { get; set; }

        public string Country { get; set; }

        public string PassportNumber { get; set; }
        
        public string Relationship { get; set; }

        public int MemberID { get; set; }

        public virtual Member Member { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.Now;

        public DateTime DateModified { get; set; } = DateTime.Now;
    }
}
