using DDR_Khudmadad.BusinessObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DDR_Khudmadad.DataSource
{
    public class PostgresDb : IDatabase
    {
        public PostgresDb() {}

        public void Configure(DbContextOptionsBuilder optionsBuilder, string? connectionString)
        {
            if (connectionString == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                optionsBuilder.UseNpgsql(connectionString);
            }
        }
    }
}
