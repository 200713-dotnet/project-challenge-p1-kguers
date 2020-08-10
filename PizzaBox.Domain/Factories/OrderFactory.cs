using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Factories
{
     public class OrderFactory : IFactory<OrderModel>
     {
          public OrderModel Create()
          {
               return new OrderModel()
               {
                    Pizzas = new List<PizzaModel>(),
               };
          }
     }
}