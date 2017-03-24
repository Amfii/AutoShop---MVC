using Microsoft.EntityFrameworkCore;


namespace AutoShop
{
    public class AutoContext : DbContext
    {
        public DbSet<Manufacturer> Manufacturer { get; set; }
        public DbSet<Car> Car { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"user id=root;" +
                           "password=root;" +
                           "server=DESKTOP-8LBDR39\\SQLEXPRESS;" +
                           "Trusted_Connection=yes;" +
                           "database=autolist; " +
                           "connection timeout=30;" +
                           "MultipleActiveResultSets=True;");
        }
    }

    public class Manufacturer
    {
        public int ManufacturerID { get; set; }
        public string ManufacturerName { get; set; }
    }

    public class Car
    {
        public int CarID { get; set; }
        public string CarManufacturer { get; set; }
        public string CarName { get; set; }
        public string CarEngine { get; set; }
        public int CarYear { get; set; }
        public string CarColor { get; set; }
        public int CarPrice { get; set; }
        public string CarDescription { get; set; }

    }
}