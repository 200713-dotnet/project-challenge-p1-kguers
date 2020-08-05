using System;
using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
     public class OrderModel : AModel
     {
          public List<PizzaModel> Pizzas { get; set; }
          public DateTime DateOrdered { get; set; }
     }
}