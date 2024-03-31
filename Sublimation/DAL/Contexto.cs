using Microsoft.EntityFrameworkCore;

namespace Sublimation.DAL
{
    public class Contexto : DbContext
    {



        public Contexto(DbContextOptions<Contexto> options) : base(options) { }
    }
}
