using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PizzaBox.Domain.Factories;
using PizzaBox.Domain.Models;
//using PizzaBox.Domain.Factories;
//using PizzaBox.Client.Models;

namespace PizzaBox.Client.Models
{
     public class UserViewModel
     {
          public List<OrderModel> UserOrders { get; set; }
          public OrderViewModel CurrentOrder { get; set; }

          [Required]
          public string Name { get; set; }

          public UserViewModel()
          {
               CurrentOrder = new OrderViewModel();
               UserOrders = new List<OrderModel>();
          }

          public UserModel AddUser()
          {
               var u = new UserFactory();
               return u.Create();
          }
          

     }
}