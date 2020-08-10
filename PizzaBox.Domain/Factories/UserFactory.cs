using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Factories
{
     public class UserFactory : IFactory<UserModel>
     {
          public UserModel Create()
          {
               return new UserModel();
          }
     }
}