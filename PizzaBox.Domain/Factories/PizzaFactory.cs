using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Factories
{
     public class PizzaFactory : IFactory<PizzaModel>
     {
          public PizzaModel Create()
          {
               return new PizzaModel()
               {
                    Toppings = new List<ToppingModel>(),
               };
          }
     }
}