using AutoMapper;
using TaxiManagement.Domain.Models;
using TaxiManagement.DTO.DTO;
using TaxiManagement.DTO.Requests.Create;
using TaxiManagement.DTO.Requests.Update;

namespace TaxiManagement.WebAPI
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<DataAccess.Entities.Car, Domain.Car>();
            this.CreateMap<DataAccess.Entities.Driver, Domain.Driver>();
            this.CreateMap<DataAccess.Entities.Depot, Domain.Depot>();
            this.CreateMap<Domain.Car, CarDTO>();
            this.CreateMap<Domain.Driver, DriverDTO>();
            this.CreateMap<Domain.Depot, DepotDTO>();
            this.CreateMap<CarCreateDTO, CarUpdateModel>();
            this.CreateMap<CarUpdateDTO, CarUpdateModel>();
            this.CreateMap<DriverCreateDTO, DriverUpdateModel>();
            this.CreateMap<DriverUpdateDTO, DriverUpdateModel>();
            this.CreateMap<DepotCreateDTO, DepotCreateModel>();
            this.CreateMap<CarUpdateModel, DataAccess.Entities.Car>();
            this.CreateMap<DriverUpdateModel, DataAccess.Entities.Driver>();
            this.CreateMap<DepotCreateModel, DataAccess.Entities.Depot>();
        }
    }
}