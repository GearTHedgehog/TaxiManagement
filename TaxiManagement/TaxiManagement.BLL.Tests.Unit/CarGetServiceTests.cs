using System;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using TaxiManagement.BLL.Implementations;
using TaxiManagement.DataAccess.Contracts;
using TaxiManagement.Domain;
using TaxiManagement.Domain.Contracts;

namespace TaxiManagement.BLL.Tests.Unit
{
    [TestFixture]
    public class CarGetServiceTests
    {
        [Test]
        public async Task ValidateAsync_CarExists_DoesNothing()
        {
            var carContainer = new Mock<ICarContainer>();
            var car = new Car();
            var carDataAccess = new Mock<ICarDataAccess>();
            carDataAccess.Setup(x 
                => x.GetByAsync(carContainer.Object)).ReturnsAsync(car);
            
            var carGetService = new CarGetService(carDataAccess.Object);

            var action = new Func<Task>(() => carGetService.ValidateAsync(carContainer.Object));

            await action.Should().NotThrowAsync<Exception>();
        }

        [Test]
        public async Task ValidateAsync_CarNotExists_ThrowsError()
        {
            var fixture = new Fixture();
            var id = fixture.Create<int>();
            var carContainer = new Mock<ICarContainer>();
            carContainer.Setup(x => x.CarContainer).Returns(id);
            
            var carDataAccess = new Mock<ICarDataAccess>();
            carDataAccess.Setup(x 
                => x.GetByAsync(carContainer.Object)).ReturnsAsync((Car)null);
            
            var carGetService = new CarGetService(carDataAccess.Object);
            var action = new Func<Task>(() => carGetService.ValidateAsync(carContainer.Object));

            await action.Should().ThrowAsync<InvalidOperationException>($"Car not found by id {id}");
        }
    }
}