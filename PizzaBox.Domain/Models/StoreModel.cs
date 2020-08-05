using System;
using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
     public class StoreModel: AModel
     {
          public List<OrderModel> StoreOrders { get; set; }

     }
}