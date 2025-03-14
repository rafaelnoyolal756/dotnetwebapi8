using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace dotnetwebapi8.Model
{
    public class Power
    {
        public int Id { get; set; }

        [ForeignKey("Hero")]
        public int HeroId { get; set; }
        public OurHero Hero { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }
    }
}
