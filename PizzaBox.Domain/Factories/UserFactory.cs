using PizzaBox.Domain.Models;
using System.Collections.Generic;
namespace PizzaBox.Domain.Factories
{
     public class UserFactory : IFactory<UserModel>
     {
          public UserModel Create()
          {
               return new UserModel()
               {
                    UserOrders = new List<OrderModel>()
               };
          }
     }
}