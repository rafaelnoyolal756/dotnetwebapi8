using System.ComponentModel.DataAnnotations;

namespace dotnetwebapi8.Model
{
    public class OurHero
    {
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public required string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? Alias { get; set; }
        public bool isActive { get; set; } = true;
        public ICollection<Power> Powers { get; set; } = new List<Power>();
    }
}
