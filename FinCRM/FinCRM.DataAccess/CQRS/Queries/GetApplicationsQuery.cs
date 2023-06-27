using FinCRM.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinCRM.DataAccess.CQRS.Queries
{


	public class GetApplicationtsQuery : QueryBase<List<Application>>
	{
		

		public override Task<List<Application>> Execute(CRMStorageContext context)
		{
			return context.Applications
			    .Include(x => x.Clients)
			    .ToListAsync();
		}
	}
}