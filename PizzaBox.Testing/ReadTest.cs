using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;
using PizzaBox.Storing.Repo;
using Xunit;

namespace PizzaBox.Testing
{
     public class RepoTest
     {
          private static readonly SqliteConnection _connection = new SqliteConnection("Data Source=: memory");
          private static readonly DbContextOptions<PizzaBoxDbContext> _options = new DbContextOptionsBuilder<PizzaBoxDbContext>().UseSqlite(_connection).Options;
           public static readonly IEnumerable<object[]> _records = new List<object[]>()
          {
               new object[]
               {
                    new StoreModel() { Id = 1, Name = "West", StoreOrders = new List<OrderModel>()},
                    new UserModel() { Id = 1, Name = "Kyle" , UserOrders = new List<OrderModel>()},
               }
          };
     
          [Theory]
          [MemberData(nameof(_records))]
          public void Test_Create(StoreModel store, UserModel user)
          {
               _connection.Open();
               try
               {
                    using (var context = new PizzaBoxDbContext(_options))
                    {
                         context.Stores.Add(store);
                         context.Users.Add(user);
                         context.SaveChanges();
                    }
               }
               finally
               {
                    _connection.Close();
               }
          }
     }
}