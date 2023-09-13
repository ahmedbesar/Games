

namespace GameZone.Models
{
    public class Device : BaseEntity
    {
        [MaxLength(100)]
        public string Icon { get; set; } = string.Empty;
        public virtual ICollection<GameDevice> GameDevices { get; set; } = new List<GameDevice>();
    }

}
