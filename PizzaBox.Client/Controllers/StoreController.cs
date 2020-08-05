using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;

namespace PizzaBox.Client.Controllers
{
     public class StoreController : Controller
     {
          private readonly PizzaBoxDbContext _db;
          public StoreController(PizzaBoxDbContext dbContext) //constructor dependency injection
          {
               _db = dbContext;
          }

          [HttpGet()]
          public IEnumerable<StoreModel> Get()
          {
               return _db.Stores.ToList();
          }

          [HttpGet("{id}")]
          public StoreModel Get(int id)
          {
               return _db.Stores.SingleOrDefault(p => p.Id == id);
          }
     }
}