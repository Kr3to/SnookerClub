using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Laboratorium3_App.Models
{
    public class Reservation
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please fill the name of the player")]
        [StringLength(100)]
        [Display(Name = "Customer Name")]

        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Please fill the amount of hours")]
        [Range(1, 8)]
        [Display(Name = "Play time (hours)")]

        public int PlayTimeHours { get; set; }

        [Required(ErrorMessage = "Please fill the reservation date")]
        [Display(Name = "Reservation date")]

        public DateTime ReservationDate { get; set; }

    }
}
