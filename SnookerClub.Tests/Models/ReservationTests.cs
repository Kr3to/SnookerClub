using Xunit;
using Laboratorium3_App.Models;
using System;

namespace SnookerClub.Tests.Models
{
    public class ReservationTests
    {
        [Fact]
        public void CanChangeReservationDate()
        {
            // Arrange
            var reservation = new Reservation { ReservationDate = new DateTime(2023, 6, 28) };

            // Act
            reservation.ReservationDate = new DateTime(2024, 6, 28);

            // Assert
            Assert.Equal(new DateTime(2024, 6, 28), reservation.ReservationDate);
        }
    }
}


