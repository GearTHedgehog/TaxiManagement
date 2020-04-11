using System;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using TaxiManagement.BLL.Contracts;
using TaxiManagement.BLL.Implementations;
using TaxiManagement.DataAccess.Contracts;
using TaxiManagement.Domain;
using TaxiManagement.Domain.Contracts;
using TaxiManagement.Domain.Models;

namespace TaxiManagement.BLL.Tests.Unit
{
    public class CarUpdateServiceTests
    {
        [Test]
        public async Task UpdateAsync_DepotValidationSucceed_UpdatesCar()
        {
            // Arrange
            var car = new CarUpdateModel();
            var expected = new Car();
            
            var depotGetService = new Mock<IDepotGetService>();
            depotGetService.Setup(x => x.ValidateAsync(car));

            var carDataAccess = new Mock<ICarDataAccess>();
            carDataAccess.Setup(x => x.UpdateAsync(car)).ReturnsAsync(expected);

            var carUpdateService = new CarUpdateService(depotGetService.Object, carDataAccess.Object);
            
            // Act
            var result = await carUpdateService.UpdateAsync(car);
            
            // Assert
            result.Should().Be(expected);
        }
        
        [Test]
        public async Task UpdateAsync_DepotValidationFailed_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var car = new CarUpdateModel();
            var expected = fixture.Create<string>();
            
            var depotGetService = new Mock<IDepotGetService>();
            depotGetService.Setup(x => x.ValidateAsync(car))
                .Throws(new InvalidOperationException(expected));

            var carDataAccess = new Mock<ICarDataAccess>();

            var carUpdateService = new CarUpdateService(depotGetService.Object, carDataAccess.Object);
            
            // Act
            var action = new Func<Task>(() => carUpdateService.UpdateAsync(car));
            
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>().WithMessage(expected);
            carDataAccess.Verify(x => x.InsertAsync(car), Times.Never);
        }
    }
}