using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;

namespace PizzaBox.Client.Controllers
{
     public class UserController : Controller
     {
          private readonly PizzaBoxDbContext _db;
          public UserController(PizzaBoxDbContext dbContext) //constructor dependency injection
          {
               _db = dbContext;
          }

          [HttpGet()]
          public IEnumerable<UserModel> Get()
          {
               return _db.Users.ToList();
          }

          [HttpGet("{id}")]
          public UserModel Get(int id)
          {
               return _db.Users.SingleOrDefault(p => p.Id == id);
          }
     }
}