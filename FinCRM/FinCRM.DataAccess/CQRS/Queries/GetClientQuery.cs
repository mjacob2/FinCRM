﻿namespace FinCRM.DataAccess.CQRS.Queries
{
    using FinCRM.DataAccess.Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class GetClientQuery : QueryBase<Client>
    {
        public int ClientId { get; set; }

        public override async Task<Client> Execute(CRMStorageContext context)
        {
            var client = await context.Clients.FirstOrDefaultAsync(x => x.Id == this.ClientId);
            return client;
        }
    }
}
