using System;
using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaStore.Client.Models
{
     public class OrderViewModel
     {
          public List<PizzaModel> Pizzas { get; set; }
          public List<DateTime> DateOrdered { get; set; }

     }
}