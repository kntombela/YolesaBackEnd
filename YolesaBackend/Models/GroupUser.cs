using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YolesaBackend.Models
{
    public class GroupUser
    {
        public int Id { get; set; }

        [Required]
        public string UserID { get; set; }

        public int GroupID { get; set; }

        public virtual Group Group { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.Now;

        public DateTime DateModified { get; set; } = DateTime.Now;

    }
}
