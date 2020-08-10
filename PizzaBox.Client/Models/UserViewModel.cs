using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Factories;

namespace PizzaBox.Client.Models
{
     public class UserViewModel
     {
          public List<OrderModel> UserOrders { get; set; }
          public OrderModel CurrentOrder { get; set; }
          [Required]
          public string Name { get; set; }

          public UserViewModel()
          {
               var o = new OrderFactory();
               CurrentOrder = o.Create();
          }
          

     }
}