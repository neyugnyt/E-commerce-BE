﻿using Core.Entiies.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.DTOs
{
    public class OrderToReturnDTO
    {
        public int Id { get; set; }
        public string BuyerEmail { get; set; }

        public DateTimeOffset OderDate { get; set; }

        public Address ShipToAddress { get; set; }

        public string DeliveryMethod { get; set; }
        public decimal ShippingPrice { get; set; }

        public IReadOnlyList<OrderItemDTO> OrderItems { get; set; }

        public decimal Subtotal { get; set; }
        public decimal Total { get; set; } 

        public string Status { get; set; }
    }
}
