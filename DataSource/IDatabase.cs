using Microsoft.EntityFrameworkCore;

namespace DDR_Khudmadad.DataSource
{
    public interface IDatabase
    {
        void Configure(DbContextOptionsBuilder optionsBuilder, string? connectionString); 
    }
}
