using Microsoft.EntityFrameworkCore;

namespace DDR_Khudmadad.DataSource
{
    public class SqlServerDb : IDatabase
    {
        public SqlServerDb() { }

        public void Configure(DbContextOptionsBuilder optionsBuilder, string? connectionString)
        {
            if (connectionString == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
