using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Models
{
     public class StoreViewModel
     {
          public List<OrderModel> StoreOrders { get; set; }
          public List<string> Stores { get; set; }

          [Required]
          public string Store { get; set; }

          public StoreViewModel()
          {
               Stores = new List<string>{"West End Pizzeria", "East Side Pies"};
          }

     }
}