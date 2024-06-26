using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    [Table("reservations")]
    public class ReservationEntity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string CustomerName { get; set; }

        [Required]
        [Range(1, 8)]
        public int PlayTimeHours { get; set; }

        [Required]
        public DateTime ReservationDate { get; set; }
    }
}
