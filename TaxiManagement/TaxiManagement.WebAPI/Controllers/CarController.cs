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
    [Route("api/car")]
    public class CarController : ControllerBase
    {
        private ILogger<CarController> Logger { get; }
        private ICarCreateService CarCreateService { get; }
        private ICarGetService CarGetService { get; }
        private ICarUpdateService CarUpdateService { get; }
        private ICarDeleteService CarDeleteService { get; }
        private IMapper Mapper { get; }

        public CarController(ILogger<CarController> logger, IMapper mapper,
            ICarCreateService carCreateService, ICarDeleteService carDeleteService,
            ICarGetService carGetService, ICarUpdateService carUpdateService)
        {
            this.Logger = logger;
            this.Mapper = mapper;
            this.CarCreateService = carCreateService;
            this.CarDeleteService = carDeleteService;
            this.CarUpdateService = carUpdateService;
            this.CarGetService = carGetService;
        }

        [HttpPut]
        [Route("")]
        public async Task<CarDTO> PutAsync(CarCreateDTO car)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");
            var result = await this.CarCreateService.CreateAsync(this.Mapper.Map<CarUpdateModel>(car));
            return this.Mapper.Map<CarDTO>(result);
        }
        [HttpPatch]
        [Route("")]
        public async Task<CarDTO> PatchAsync(CarUpdateDTO car)
        {
            this.Logger.LogTrace($"{nameof(this.PatchAsync)} called");
            var result = await this.CarUpdateService.UpdateAsync(this.Mapper.Map<CarUpdateModel>(car));
            return this.Mapper.Map<CarDTO>(result);
        }
        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<CarDTO>> GetAsync()
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called");
            return this.Mapper.Map<IEnumerable<CarDTO>>(
                await this.CarGetService.GetAsync()
                );
        }
        [HttpGet]
        [Route("{carId}")]
        public async Task<CarDTO> GetAsync(int carId)
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called");
            return this.Mapper.Map<CarDTO>(
                await this.CarGetService.GetAsync(new CarIdModel(carId))
            );
        }
        [HttpDelete]
        [Route("{carId}")]
        public async Task DeleteAsync(int carId)
        {
            this.Logger.LogTrace($"{nameof(this.DeleteAsync)} called");
            await this.CarDeleteService.DeleteAsync(new CarIdModel(carId));
        }
    }
}