using Microsoft.EntityFrameworkCore;

namespace RestWhitASP_Net.Model.Context
{
    public class MySqlContex: DbContext
    {
        public MySqlContex(DbContextOptions<MySqlContex> options) :base (options)
        { }
        public DbSet<Person> Persons { get; set; }

    }
}
