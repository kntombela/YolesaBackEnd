using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YolesaBackend.ViewModels
{
    public class GroupViewModel
    {
        public int GroupID { get; set; }

        public string Name { get; set; }

        public GroupType Type { get; set; }

        public string PolicyNumber { get; set; }

        public string Industry { get; set; }

        public DateTime DateModified { get; set; }

        public int MemberCount { get; set; }
    }
}
