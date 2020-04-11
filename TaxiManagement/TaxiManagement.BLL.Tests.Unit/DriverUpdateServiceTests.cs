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
    public class DriverUpdateServiceTests
    {
        [Test]
        public async Task UpdateAsync_CarValidationSucceed_UpdatesDriver()
        {
            // Arrange
            var driver = new DriverUpdateModel();
            var expected = new Driver();
            
            var carGetService = new Mock<ICarGetService>();
            carGetService.Setup(x => x.ValidateAsync(driver));

            var driverDataAccess = new Mock<IDriverDataAccess>();
            driverDataAccess.Setup(x => x.UpdateAsync(driver)).ReturnsAsync(expected);

            var driverUpdateService = new DriverUpdateService(carGetService.Object, driverDataAccess.Object);
            
            // Act
            var result = await driverUpdateService.UpdateAsync(driver);
            
            // Assert
            result.Should().Be(expected);
        }
        
        [Test]
        public async Task UpdateAsync_CarValidationFailed_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var driver = new DriverUpdateModel();
            var expected = fixture.Create<string>();
            
            var carGetService = new Mock<ICarGetService>();
            carGetService.Setup(x => x.ValidateAsync(driver))
                .Throws(new InvalidOperationException(expected));

            var driverDataAccess = new Mock<IDriverDataAccess>();

            var driverUpdateService = new DriverUpdateService(carGetService.Object, driverDataAccess.Object);
            
            // Act
            var action = new Func<Task>(() => driverUpdateService.UpdateAsync(driver));
            
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>().WithMessage(expected);
            driverDataAccess.Verify(x => x.InsertAsync(driver), Times.Never);
        }
    }
}