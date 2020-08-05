using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Models
{
     public class UserViewModel
     {
          public List<OrderModel> UserOrders { get; set; }

     }
}