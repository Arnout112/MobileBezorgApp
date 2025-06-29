﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBezorgApp.Models
{
    public class OrderDto
    {
        public int Id { get; set; }
        public CustomerDto Customer { get; set; }
        public List<ProductDto> Products { get; set; }
    }

    public class CreateOrderDto
    {
        public CustomerDto Customer { get; set; }
        public List<ProductDto> Products { get; set; }
    }
}
