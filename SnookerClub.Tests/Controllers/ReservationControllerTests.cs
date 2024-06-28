using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Laboratorium3_App.Controllers;
using Laboratorium3_App.Models;
using System;

namespace SnookerClub.Tests.Controllers
{
    public class ReservationControllerTests
    {
        private readonly Mock<IReservationService> _mockService;
        private readonly ReservationController _controller;

        public ReservationControllerTests()
        {
            _mockService = new Mock<IReservationService>();
            _controller = new ReservationController(_mockService.Object);
        }

        [Fact]
        public void Details_ShouldReturnCorrectReservation()
        {
            // Arrange
            var reservation = new Reservation { Id = 1, CustomerName = "Player 1", ReservationDate = new DateTime(2024, 6, 28), PlayTimeHours = 2 };
            _mockService.Setup(s => s.FindById(1)).Returns(reservation);

            // Act
            var result = _controller.Details(1);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<Reservation>(viewResult.ViewData.Model);
            Assert.Equal("Player 1", model.CustomerName);
        }

        [Fact]
        public void Create_Get_ShouldReturnView()
        {
            // Act
            var result = _controller.Create();

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Create_Post_ValidModel_ShouldRedirectToIndex()
        {
            // Arrange
            var reservation = new Reservation { Id = 1, CustomerName = "Player 1", ReservationDate = new DateTime(2024, 6, 28), PlayTimeHours = 2 };

            // Act
            var result = _controller.Create(reservation);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName, ignoreCase: true);
            _mockService.Verify(s => s.Add(It.IsAny<Reservation>()), Times.Once);
        }

        [Fact]
        public void Update_Get_ShouldReturnViewWithModel()
        {
            // Arrange
            var reservation = new Reservation { Id = 1, CustomerName = "Player 1", ReservationDate = new DateTime(2024, 6, 28), PlayTimeHours = 2 };
            _mockService.Setup(s => s.FindById(1)).Returns(reservation);

            // Act
            var result = _controller.Update(1);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<Reservation>(viewResult.ViewData.Model);
            Assert.Equal("Player 1", model.CustomerName);
        }

        [Fact]
        public void Update_Post_ValidModel_ShouldRedirectToIndex()
        {
            // Arrange
            var reservation = new Reservation { Id = 1, CustomerName = "Player 1", ReservationDate = new DateTime(2024, 6, 28), PlayTimeHours = 2 };

            // Act
            var result = _controller.Update(reservation);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName, ignoreCase: true);
            _mockService.Verify(s => s.Update(It.IsAny<Reservation>()), Times.Once);
        }

        [Fact]
        public void Update_Post_InvalidModel_ShouldReturnView()
        {
            // Arrange
            _controller.ModelState.AddModelError("CustomerName", "Required");
            var reservation = new Reservation { Id = 1, ReservationDate = new DateTime(2024, 6, 28), PlayTimeHours = 2 };

            // Act
            var result = _controller.Update(reservation);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<Reservation>(viewResult.ViewData.Model);
            Assert.NotNull(model);
        }

        [Fact]
        public void Delete_Get_ShouldReturnViewWithModel()
        {
            // Arrange
            var reservation = new Reservation { Id = 1, CustomerName = "Player 1", ReservationDate = new DateTime(2024, 6, 28), PlayTimeHours = 2 };
            _mockService.Setup(s => s.FindById(1)).Returns(reservation);

            // Act
            var result = _controller.Delete(1);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<Reservation>(viewResult.ViewData.Model);
            Assert.Equal("Player 1", model.CustomerName);
        }

        [Fact]
        public void Delete_Post_ShouldRedirectToIndex()
        {
            // Arrange
            var reservation = new Reservation { Id = 1, CustomerName = "Player 1", ReservationDate = new DateTime(2024, 6, 28), PlayTimeHours = 2 };

            // Act
            var result = _controller.Delete(reservation);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName, ignoreCase: true);
            _mockService.Verify(s => s.DeleteById(It.IsAny<int>()), Times.Once);
        }
    }
}
