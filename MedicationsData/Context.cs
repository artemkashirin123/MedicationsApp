using MedicationsData.Models;
using System.Data.Entity;

namespace MedicationsData
{
    public class Context : DbContext
    {
        public Context() : base("Medications")
        {

        }

        public DbSet<Medication> Medications { get; set; }

        public DbSet<PharmСompany> PharmСompanies { get; set; }

        public DbSet<Stock> Stocks { get; set; }
    }
}
