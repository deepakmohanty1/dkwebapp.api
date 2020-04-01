using Microsoft.EntityFrameworkCore;
using dkwebapp.api.models;
namespace dkwebapp.api.Data
{
    public class datacontext : DbContext
    {
        public datacontext( DbContextOptions<datacontext> options) : base(options)
        {

        }

        public DbSet<value> values { get; set; }
       
    }
}