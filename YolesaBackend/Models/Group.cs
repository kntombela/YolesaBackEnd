using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

public enum GroupType
{
    Company,
    CC,
    SoleProprietor,
    Partnership,
    Trust,
    Union,
    BurialSociety,
    FuneralParlour,
    Church,
    Other
}

namespace YolesaBackend.Models
{
    public class Group
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public GroupType Type { get; set; }

        public string PolicyNumber { get; set; }

        public string Industry { get; set; }

        public ICollection<Member> Members { get; set; }

        public ICollection<GroupUser> GroupUsers { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.Now;

        public DateTime DateModified { get; set; } = DateTime.Now;

    }
}
