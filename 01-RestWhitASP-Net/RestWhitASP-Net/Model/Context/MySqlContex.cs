using Microsoft.EntityFrameworkCore;

namespace RestWhitASP_Net.Model.Context
{
    public class MySqlContex(DbContextOptions<AppContext>Options : Base64FormattingOpti)
    {
        public MySqlContex() { }
        public DbSet<Person> _person { get; set; }

    }

    

}
