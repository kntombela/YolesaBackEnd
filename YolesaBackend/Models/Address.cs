using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YolesaBackend.Models
{
    public enum AddressType
    {
        Residential,
        Postal
    }

    public class Address
    {
        public int Id { get; set; }

        public AddressType AddressType { get; set; }

        [Required]
        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string AddressLine3 { get; set; }

        public string Suburb { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Province { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string PostalCode { get; set; }

        public int MemberID { get; set; }

        public virtual Member Member { get; set; }

    }
}
