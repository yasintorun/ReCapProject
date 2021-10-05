using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CarDetail : IEntity
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int ModelYear { get; set; }
        public int SeatCount { get; set; }
        public string Transmission { get; set; }
        public string Fuel { get; set; }
    }
}
