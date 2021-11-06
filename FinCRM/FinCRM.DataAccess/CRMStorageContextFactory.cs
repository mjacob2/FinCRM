namespace FinCRM.DataAccess
{

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;

     public class CRMStorageContextFactory : IDesignTimeDbContextFactory<CRMStorageContext>
    {
        public CRMStorageContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CRMStorageContext>();
            optionsBuilder.UseSqlServer("Data Source =.\\SQLEXPRESS; Initial Catalog = CRMStorage; Integrated Security = True");
            return new CRMStorageContext(optionsBuilder.Options);
        }
    }
}
