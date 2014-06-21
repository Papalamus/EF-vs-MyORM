using System.Data.Entity;
using MyOrmLib;

namespace EF_vs_MicroOrm
{
    class LibrayContext:DbContext
    {
        public DbSet<Person> Persons { get; set; }

        public DbSet<Article> Articles { get; set; }
    }
}
