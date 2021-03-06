﻿using TaxiManagement.Domain.Contracts;

namespace TaxiManagement.Domain
{
    public class Car:IDepotContainer
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int YearOfProduction { get; set; }
        public int CurrentRepairs { get; set; }
        public Depot Depot { get; set; }

        int? IDepotContainer.DepotId => this.Depot.Id;
    }
}