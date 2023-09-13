

namespace GameZone.Models
{
    public class GameZoneDBContext :DbContext
    {


        public GameZoneDBContext(DbContextOptions<GameZoneDBContext> options)
        : base(options)
        {
        }

        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Device> Devices { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<GameDevice> GameDevices { get; set; }






        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<GameDevice>()
                 .HasKey(e => new
                 {
                     e.GameId,e.DeviceId
                 });
        
        }

      









    }


}
