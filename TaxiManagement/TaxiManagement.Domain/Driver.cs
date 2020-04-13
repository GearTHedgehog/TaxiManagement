﻿using System.Runtime.CompilerServices;
using TaxiManagement.Domain.Contracts;

namespace TaxiManagement.Domain
{
    public class Driver : ICarContainer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public Car Car { get; set; }

        int? ICarContainer.CarId => this.Car.Id;
    }
}