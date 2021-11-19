using FinCRM.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinCRM.DataAccess.CQRS.Queries
{
    public class GetUsersQuery : QueryBase<List<User>>
    {
        //public int Id { get; set; }

        public override Task<List<User>> Execute(CRMStorageContext context)
        {
            return context.Users.ToListAsync();

        }
    }
}