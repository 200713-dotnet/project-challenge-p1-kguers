using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;
using PizzaBox.Domain.Factories;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;
using PizzaBox.Storing.Repo;

namespace PizzaBox.Client.Controllers
{
     public class StoreController : Controller
     {
          private readonly PizzaBoxDbContext _db;
          //private StoreModel _store;
          //private UserModel _user;
          private PizzaBoxRepo _pr;
          public StoreController(PizzaBoxDbContext dbContext) //constructor dependency injection
          {
               _db = dbContext;
               _pr = new PizzaBoxRepo(_db);
          }
          public IActionResult Index()
          {
               return View("Store");
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