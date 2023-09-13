namespace GameZone.Models
{
    public class GameDevice
    {
        public int GameId { get; set; }
        public int DeviceId { get; set; }

        public virtual Game Game { get; set; } = default!;
        public  virtual Device Device { get; set; } = default!;

    }
}
