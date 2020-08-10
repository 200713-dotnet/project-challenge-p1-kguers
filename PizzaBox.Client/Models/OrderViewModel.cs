using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Models
{
     public class OrderViewModel
     {
          public List<PizzaModel> Pizzas { get; set; }
          public DateTime DateOrdered { get; set; }
          
          [Required]
          public int SelectedPizza { get; set; }
          public OrderViewModel()
          {
               Pizzas = new List<PizzaModel>();
               DateOrdered = DateTime.Now;
          }
     }
}