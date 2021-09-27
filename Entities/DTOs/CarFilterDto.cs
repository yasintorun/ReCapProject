using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarFilterDto:IDto
    {
        public List<int> Brands { get; set; }
        public List<int> Colors { get; set; }
    }
}
