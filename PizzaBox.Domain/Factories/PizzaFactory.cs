using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Factories
{
     public class PizzaFactory : IFactory<PizzaModel>
     {
          public PizzaModel Create()
          {
               return new PizzaModel();
          }
     }
}