using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using domain = PizzaBox.Domain.Models;
using PizzaBox.Storing;

namespace PizzaBox.Storing.Repo
{
     public class PizzaBoxRepo
     {

          private PizzaBoxDbContext _db;

          public PizzaBoxRepo(PizzaBoxDbContext dbContext)
          {
               _db = dbContext;
          }
          public void CreatePizza(domain.PizzaModel pizzaModel)
          {
               _db.Pizzas.Add(pizzaModel);
          }

          public void CreateOrder(domain.OrderModel orderModel)
          {
               _db.Orders.Add(orderModel);
               foreach (var item in orderModel.Pizzas)
               {
                    CreatePizza(item);
               }
          }

          public void CreateStore(domain.StoreModel storeModel)
          {
               _db.Stores.Add(storeModel);
               _db.SaveChanges();
          }

          public void CreateUser(domain.UserModel userModel)
          {
               _db.Users.Add(userModel);
               foreach (var item in userModel.UserOrders.ToList())
               {
                    CreateOrder(item);
               }
               _db.SaveChanges();
          }

          public List<domain.OrderModel> ReadStore(domain.StoreModel store)
          {
               var storeOrderList = new List<domain.OrderModel>();
               var findUser = _db.Stores.Include(t => t.Name).Where(t => t.Name == store.Name);

               return storeOrderList;
          }
          public domain.UserModel ReadUser(domain.UserModel user)
          {
               var findUser = _db?.Users.Include(t => t.Id).Where(p => p.Name == user.Name).SingleOrDefault();
               if (findUser == null)
               {
                    return null;
               }
               else
               {
                    var UserHistory = _db.Users
                    .Include(t => t.UserOrders)
                    .ThenInclude(t => t.Pizzas)
                    .ThenInclude(t => t.Toppings)
                    .Where(use => use.Name == user.Name)
                    .Select(u => new domain.UserModel
                    {
                         Id = u.Id,
                         Name = u.Name,
                         UserOrders = u.UserOrders.Select(o => new domain.OrderModel()
                         {
                              Pizzas = o.Pizzas.Select(p => new domain.PizzaModel()
                              {
                                   Crust = p.Crust,
                                   Size = p.Size,
                                   Toppings = p.Toppings.Select(top => new domain.ToppingModel()
                                   {
                                        Name = top.Name,
                                   }).ToList(),
                              }).ToList(),
                         }).ToList(),
                    }).SingleOrDefault();
                    return UserHistory;
               }
          }

          public void Update()
          {

          }
          public void Delete()
          {

          }

     }
}
//var userPizzaToppings = _db.Users.Include(t => t.UserOrders)
//      .ThenInclude(t => t.Pizzas)
//      .ThenInclude(t => t.Toppings)
//      .ThenInclude(t => t.Name)
//      .Where(t => t.Id == user.Id)
//      .OrderBy(t => t.UserOrders)
//      .ToList();
// foreach(var u in userPizzaToppings.ToList())
// {
//      foreach(var o in u.UserOrders.ToList())
//      {
//           var domainOrderModel = new domain.OrderModel()
//           {
//                DateOrdered = o.DateOrdered,
//                Pizzas = new List<domain.PizzaModel>()
//           };
//           foreach(var p in o.Pizzas.ToList())
//           {
//                var domainPizzaModel = new domain.PizzaModel
//                {
//                     Crust = new domain.CrustModel{Name = p.Crust.Name},
//                     Size = new domain.SizeModel{Name = p.Size.Name},
//                     Name = p.Name,
//                };
//                foreach(var t in p.Toppings.ToList())
//                {
//                     domainPizzaModel.Toppings.Add(new domain.ToppingModel{Name = t.Name});
//                }
//                domainOrderModel.Pizzas.Add(domainPizzaModel);
//           }
//           userOrderList.Add(domainOrderModel);
//      }
// }

//// //var storePizzaToppings = _db.Stores.Include(t => t.StoreOrders)
//      .ThenInclude(t => t.Pizzas)
//      .ThenInclude(t => t.Toppings)
//      .ThenInclude(t => t.Name)
//      .Where(t => t.Id == store.Id)
//      .OrderBy(t => t.StoreOrders);
// foreach(var s in storePizzaToppings.ToList())
// {
//      foreach(var o in s.StoreOrders.ToList())
//      {
//           var domainOrderModel = new domain.OrderModel()
//           {
//                DateOrdered = o.DateOrdered,
//                Pizzas = new List<domain.PizzaModel>()
//           };
//           foreach(var p in o.Pizzas.ToList())
//           {
//                var domainPizzaModel = new domain.PizzaModel
//                {
//                     Crust = new domain.CrustModel{Name = p.Crust.Name},
//                     Size = new domain.SizeModel{Name = p.Size.Name},
//                     Name = p.Name,
//                };
//                foreach(var t in p.Toppings.ToList())
//                {
//                     domainPizzaModel.Toppings.Add(new domain.ToppingModel{Name = t.Name});
//                }
//                domainOrderModel.Pizzas.Add(domainPizzaModel);
//           }
//           storeOrderList.Add(domainOrderModel);
//      }
// }
// var findUser = _db.Users
//                ?.Include(t => t.UserOrders)
//                ?.ThenInclude(t => t.Pizzas)
//                ?.ThenInclude(t => t.Toppings)
//                ?.Where(t => t.Name == user.Name)
//                ?.Select(u => new domain.UserModel
//                {
//                     Id = u.Id,
//                     Name = u.Name,
//                     UserOrders = u.UserOrders.Select(o => new domain.OrderModel(){
//                          Pizzas = o.Pizzas.Select(p => new domain.PizzaModel()
//                          {
//                               Crust = p.Crust,
//                               Size = p.Size,
//                               Toppings = p.Toppings.Select(top => new domain.ToppingModel()
//                               {
//                                    Name = top.Name,
//                               }).ToList(),
//                          }).ToList(),
//                     }).ToList(),
//                }).SingleOrDefault();