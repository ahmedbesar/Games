using System.ComponentModel.DataAnnotations;

namespace GameZone.Models
{
    public class Game:BaseEntity
    {
        
        [MaxLength(2500)]
        public string Description { get; set; }=string.Empty;
        [MaxLength(500)]
        public string Cover { get; set; } = default!;
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; } = default!;
        public virtual ICollection<GameDevice> GameDevices { get; set; } = new List<GameDevice>();



    }
}
