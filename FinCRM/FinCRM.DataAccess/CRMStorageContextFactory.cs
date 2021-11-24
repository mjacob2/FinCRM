namespace FinCRM.DataAccess
{

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;

     public class CRMStorageContextFactory : IDesignTimeDbContextFactory<CRMStorageContext>
    {
        public CRMStorageContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CRMStorageContext>();
            optionsBuilder.UseSqlServer("Server=tcp:fin-crm.database.windows.net,1433;Initial Catalog=CRMStorge;Persist Security Info=False;User ID=marek;Password=$38YJ^^Q@r*rW4;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
);
            return new CRMStorageContext(optionsBuilder.Options);
        }
    }
}

//Local
// "Data Source =.\\SQLEXPRESS; Initial Catalog = CRMStorage; Integrated Security = True"

//Azure
//"Server=tcp:fin-crm.database.windows.net,1433;Initial Catalog=CRMStorge;Persist Security Info=False;User ID=marek;Password=$38YJ^^Q@r*rW4;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"