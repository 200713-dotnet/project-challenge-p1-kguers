using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Factories
{
     public class StoreFactory : IFactory<StoreModel>
     {
          public StoreModel Create()
          {
               return new StoreModel();
          }
     }
}