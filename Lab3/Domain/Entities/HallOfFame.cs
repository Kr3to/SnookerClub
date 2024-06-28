using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class HallOfFame
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [Range(1, 100)]
        public int Age { get; set; }

        [Required]
        [Range(0, 100)]
        public int Titles { get; set; }
    }
}
