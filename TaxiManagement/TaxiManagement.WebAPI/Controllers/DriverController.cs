using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TaxiManagement.BLL.Contracts;
using TaxiManagement.DTO.DTO;
using TaxiManagement.DTO.Requests.Create;
using TaxiManagement.DTO.Requests.Update;
using TaxiManagement.Domain;
using TaxiManagement.Domain.Contracts;
using TaxiManagement.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
namespace TaxiManagement.WebAPI.Controllers
{
    [ApiController] 
    [Route("api/driver")]
    public class DriverController : ControllerBase
    {
        private ILogger<DriverController> Logger { get; }
        private IDriverCreateService DriverCreateService { get; }
        private IDriverGetService DriverGetService { get; }
        private IDriverUpdateService DriverUpdateService { get; }
        private IDriverDeleteService DriverDeleteService { get; }
        private IMapper Mapper { get; }

        public DriverController(ILogger<DriverController> logger, IMapper mapper,
            IDriverCreateService driverCreateService, IDriverDeleteService driverDeleteService,
            IDriverGetService driverGetService, IDriverUpdateService driverUpdateService)
        {
            this.Logger = logger;
            this.Mapper = mapper;
            this.DriverCreateService = driverCreateService;
            this.DriverDeleteService = driverDeleteService;
            this.DriverUpdateService = driverUpdateService;
            this.DriverGetService = driverGetService;
        }

        [HttpPut]
        [Route("")]
        public async Task<DriverDTO> PutAsync(DriverCreateDTO driver)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");
            var result = await this.DriverCreateService.CreateAsync(this.Mapper.Map<DriverUpdateModel>(driver));
            return this.Mapper.Map<DriverDTO>(result);
        }
        [HttpPatch]
        [Route("")]
        public async Task<DriverDTO> PatchAsync(DriverUpdateDTO driver)
        {
            this.Logger.LogTrace($"{nameof(this.PatchAsync)} called");
            var result = await this.DriverUpdateService.UpdateAsync(this.Mapper.Map<DriverUpdateModel>(driver));
            return this.Mapper.Map<DriverDTO>(result);
        }
        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<DriverDTO>> GetAsync()
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called");
            return this.Mapper.Map<IEnumerable<DriverDTO>>(
                await this.DriverGetService.GetAsync()
                );
        }
        [HttpGet]
        [Route("{driverId}")]
        public async Task<DriverDTO> GetAsync(int driverId)
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called");
            return this.Mapper.Map<DriverDTO>(
                await this.DriverGetService.GetAsync(new DriverIdModel(driverId))
            );
        }
        [HttpDelete]
        [Route("{driverId}")]
        public async Task DeleteAsync(int driverId)
        {
            this.Logger.LogTrace($"{nameof(this.DeleteAsync)} called");
            await this.DriverDeleteService.DeleteAsync(new DriverIdModel(driverId));
        }
    }
}