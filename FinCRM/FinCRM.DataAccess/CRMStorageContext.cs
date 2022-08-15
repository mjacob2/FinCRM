using FinCRM.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinCRM.DataAccess
{
   public class CRMStorageContext : DbContext
    {
        public CRMStorageContext(DbContextOptions<CRMStorageContext> opt) : base(opt)
        {

        }


        public DbSet<Client>? Clients { get; set; }

        public DbSet<Application>? Applications { get; set; }

        public DbSet<User>? Users { get; set; }


    }
}
