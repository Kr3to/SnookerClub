using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class PlayerEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public int Ranking { get; set; }

        public virtual ICollection<MatchEntity> MatchesAsPlayer1 { get; set; } = new List<MatchEntity>();
        public virtual ICollection<MatchEntity> MatchesAsPlayer2 { get; set; } = new List<MatchEntity>();
    }
}
