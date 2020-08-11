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
               _db.SaveChangesAsync();
          }

          public void CreateStore(domain.StoreModel storeModel)
          {
               _db.Stores.Add(storeModel);
               _db.SaveChanges();
          }

          public void CreateUser(domain.UserModel userModel)
          {
               _db.Users.Add(userModel);
               _db.SaveChanges();
          }

          public List<domain.OrderModel> ReadStore(domain.StoreModel store)
          {
                var StoreHistory = _db?.Stores
                    .Include(t => t.StoreOrders)
                    .ThenInclude(t => t.Pizzas)
                    .ThenInclude(t => t.Toppings)
                    .FirstOrDefault(s => s.Name == s.Name);
                    if(StoreHistory == null)
                    {
                         return new List<domain.OrderModel>();
                    }
                    else
                    {
                         return StoreHistory.StoreOrders;
                    }
          }
          public List<domain.OrderModel> ReadUser(domain.UserModel user)
          {
                    var UserHistory = _db?.Users
                    .Include(t => t.UserOrders)
                    .ThenInclude(t => t.Pizzas)
                    .ThenInclude(t => t.Toppings)
                    .FirstOrDefault(u => u.Name == user.Name);
                    if(UserHistory == null)
                    {
                         return new List<domain.OrderModel>();
                    }
                    else
                    {
                         return UserHistory.UserOrders;
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