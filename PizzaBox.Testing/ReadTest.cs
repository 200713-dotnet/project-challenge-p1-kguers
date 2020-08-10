using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;
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
                    new StoreModel() { Id = 1, Name = "West" },
                    new UserModel() { Id = 1, Name = "Kyle" },
               }
          };


     
          [Theory]
          [MemberData(nameof(_records))]
          // public void Test_Create()
          // {

          // }
          // public void Test_Read()
          // {

          // }     
     }
}