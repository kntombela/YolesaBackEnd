using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using YolesaBackend.Models;

namespace YolesaBackend.Models
{
    public class YolesaContext : DbContext
    {
        public YolesaContext (DbContextOptions<YolesaContext> options)
            : base(options)
        {
        }

        public DbSet<Lead> Lead { get; set; }

        public DbSet<Group> Group { get; set; }

        public DbSet<Member> Member { get; set; }

        public DbSet<Beneficiary> Beneficiary { get; set; }

        public DbSet<YolesaBackend.Models.GroupUser> GroupUser { get; set; }
    }
}
