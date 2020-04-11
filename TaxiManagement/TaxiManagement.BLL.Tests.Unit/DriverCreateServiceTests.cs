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
    public class DriverCreateServiceTests
    {
        [Test]
        public async Task CreateAsync_CarValidationSucceed_CreatesDriver()
        {
            // Arrange
            var driver = new DriverUpdateModel();
            var expected = new Driver();
            
            var carGetService = new Mock<ICarGetService>();
            carGetService.Setup(x => x.ValidateAsync(driver));

            var driverDataAccess = new Mock<IDriverDataAccess>();
            driverDataAccess.Setup(x => x.InsertAsync(driver)).ReturnsAsync(expected);

            var driverCreateService = new DriverCreateService(carGetService.Object, driverDataAccess.Object);
            
            // Act
            var result = await driverCreateService.CreateAsync(driver);
            
            // Assert
            result.Should().Be(expected);
        }
        
        [Test]
        public async Task CreateAsync_CarValidationFailed_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var driver = new DriverUpdateModel();
            var expected = fixture.Create<string>();
            
            var carGetService = new Mock<ICarGetService>();
            carGetService.Setup(x => x.ValidateAsync(driver))
                .Throws(new InvalidOperationException(expected));

            var driverDataAccess = new Mock<IDriverDataAccess>();

            var driverCreateService = new DriverCreateService(carGetService.Object, driverDataAccess.Object);
            
            // Act
            var action = new Func<Task>(() => driverCreateService.CreateAsync(driver));
            
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>().WithMessage(expected);
            driverDataAccess.Verify(x => x.InsertAsync(driver), Times.Never);
        }
    }
}