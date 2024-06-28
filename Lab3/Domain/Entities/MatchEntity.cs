using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public class MatchEntity
    {
        [Key]
        public int MatchId { get; set; }

        [Required]
        public int Player1Id { get; set; }

        [ForeignKey("Player1Id")]
        public PlayerEntity Player1 { get; set; }

        [Required]
        public int Player2Id { get; set; }

        [ForeignKey("Player2Id")]
        public PlayerEntity Player2 { get; set; }

        [Required]
        [StringLength(100)]
        public string Location { get; set; }

        [Required]
        [StringLength(100)]
        public string Tournament { get; set; }
    }
}
