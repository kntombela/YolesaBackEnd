using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YolesaBackend.Models
{
    public enum Title
    {
        Adv,
        Dr,
        Hon,
        Mr,
        Mrs,
        Ms,
        Prof,
        Rev
    }

    public enum Gender
    {
        Male,
        Female
    }

    public class Member
    {
        public int Id { get; set; }

        public Title Title { get; set; }

        [Required]
        public string FullNames { get; set; }

        [Required]
        public string Surname { get; set; }

        public Gender Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        [StringLength(13)]
        public string IDNumber { get; set; }

        public string PassportNumber { get; set; }

        public bool IsSACitizen { get; set; }

        public string Country { get; set; }

        public bool IsEmployed { get; set; }

        public string Employer { get; set; }

        public string EmployerContactNumber { get; set; }

        [Required]
        public string ContactNumber { get; set; }

        public string TelephoneHome { get; set; }

        public string OtherContactNumber { get; set; }

        [Required]
        public string Email { get; set; }

        public bool HasChronicIllness { get; set; }

        public string ChronicIllnessDetails { get; set; }

        public bool IsUnderDebtReview { get; set; }

        public string DebtDetails { get; set; }

        public bool IsActive { get; set; }

        public int GroupID { get; set; }

        public virtual Group Group { get; set; }

        public ICollection<Beneficiary> Beneficiaries { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.Now;

        public DateTime DateModified { get; set; } = DateTime.Now;
    }
}
