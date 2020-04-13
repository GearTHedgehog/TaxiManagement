using System;
using Moq;
using AutoFixture;
using FluentAssertions;
using System.Threading.Tasks;
using NUnit.Framework;
using TaxiManagement.BLL.Implementations;
using TaxiManagement.DataAccess.Contracts;
using TaxiManagement.Domain;
using TaxiManagement.Domain.Contracts;

namespace TaxiManagement.BLL.Tests.Unit
{
    [TestFixture]
    public class DepotGetServiceTests
    {
        [Test]
        public async Task ValidateAsync_DepotExists_DoesNothing()
        {
            var depotContainer = new Mock<IDepotContainer>();
            var depot = new Depot();
            var depotDataAccess = new Mock<IDepotDataAccess>();
            depotDataAccess.Setup(x 
                => x.GetByAsync(depotContainer.Object)).ReturnsAsync(depot);
            
            var depotGetService = new DepotGetService(depotDataAccess.Object);

            var action = new Func<Task>(() => depotGetService.ValidateAsync(depotContainer.Object));

            await action.Should().NotThrowAsync<Exception>();
        }

        [Test]
        public async Task ValidateAsync_DepotNotExists_ThrowsError()
        {
            var fixture = new Fixture();
            var id = fixture.Create<int>();
            var depotContainer = new Mock<IDepotContainer>();
            depotContainer.Setup(x => x.DepotId).Returns(id);
            
            var depotDataAccess = new Mock<IDepotDataAccess>();
            depotDataAccess.Setup(x 
                => x.GetByAsync(depotContainer.Object)).ReturnsAsync((Depot)null);
            
            var depotGetService = new DepotGetService(depotDataAccess.Object);
            var action = new Func<Task>(() => depotGetService.ValidateAsync(depotContainer.Object));

            await action.Should().ThrowAsync<InvalidOperationException>($"Depot not found by id {id}");
        }
    }
}