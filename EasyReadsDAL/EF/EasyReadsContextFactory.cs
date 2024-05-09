using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReadsDAL.EF
{
    public class EasyReadsContextFactory : IDesignTimeDbContextFactory<EasyReadsContext>
    {
        public EasyReadsContext CreateDbContext(string[] args)
        {
            var connectionString = "Server=localhost;Port=3306;User=root;Database=EasyReadsDb;";
            var optionsBuilder = new DbContextOptionsBuilder<EasyReadsContext>();
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

            return new EasyReadsContext(optionsBuilder.Options);
        }
    }
}
