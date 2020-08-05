using System;
using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
     public class UserModel: AModel
     {
          public List<OrderModel> UserOrders { get; set; }

     }
}