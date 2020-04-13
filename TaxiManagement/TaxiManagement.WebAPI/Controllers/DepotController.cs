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
    [Route("api/depot")]
    public class DepotController : ControllerBase
    {
        private ILogger<DepotController> Logger { get; }
        private IDepotCreateService DepotCreateService { get; }
        private IDepotGetService DepotGetService { get; }
        private IDepotDeleteService DepotDeleteService { get; }
        private IMapper Mapper { get; }

        public DepotController(ILogger<DepotController> logger, IMapper mapper,
            IDepotCreateService depotCreateService, IDepotDeleteService depotDeleteService,
            IDepotGetService depotGetService)
        {
            this.Logger = logger;
            this.Mapper = mapper;
            this.DepotCreateService = depotCreateService;
            this.DepotDeleteService = depotDeleteService;
            this.DepotGetService = depotGetService;
        }

        [HttpPut]
        [Route("")]
        public async Task<DepotDTO> PutAsync(DepotCreateDTO depot)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");
            var result = await this.DepotCreateService.CreateAsync(this.Mapper.Map<DepotCreateModel>(depot));
            return this.Mapper.Map<DepotDTO>(result);
        }
        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<DepotDTO>> GetAsync()
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called");
            return this.Mapper.Map<IEnumerable<DepotDTO>>(
                await this.DepotGetService.GetAsync()
                );
        }
        [HttpGet]
        [Route("{depotId}")]
        public async Task<DepotDTO> GetAsync(int depotId)
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called");
            return this.Mapper.Map<DepotDTO>(
                await this.DepotGetService.GetAsync(new DepotIdModel(depotId))
            );
        }
        [HttpDelete]
        [Route("{depotId}")]
        public async Task DeleteAsync(int depotId)
        {
            this.Logger.LogTrace($"{nameof(this.DeleteAsync)} called");
            await this.DepotDeleteService.DeleteAsync(new DepotIdModel(depotId));
        }
    }
}