using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;
using PizzaBox.Domain.Factories;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;
using PizzaBox.Storing.Repo;

namespace PizzaBox.Client.Controllers
{
     //[Route("/{controller}/{action}")] //controller routing
     //[EnableCors("private")] //adds private policy
     public class OrderController : Controller
     {
          private readonly PizzaBoxDbContext _db;
          private PizzaBoxRepo _pr;
          //private static UserModel _user;
          //private static StoreModel _store;
          private static UserViewModel _uservm;
          private static StoreViewModel _storevm;
          public OrderController(PizzaBoxDbContext dbContext) //constructor dependency injection
          {
               _db = dbContext;
               _pr = new PizzaBoxRepo(_db);
          }

          //[Route("/home")] Method Routing
          
          public IActionResult Home(UserViewModel u)
          {
               _uservm = u;
               return View("Order", new PizzaViewModel());
          }
          
          [HttpPost]
          [ValidateAntiForgeryToken]
          public IActionResult PlaceOrder(PizzaViewModel pizzaViewModel) //model binding
          {
               if(ModelState.IsValid) //validating if values are null with data annotations
               {
                    var p = new PizzaFactory(); //use dependency injection
                    var newPizza = p.Create();
                    newPizza.Crust = new CrustModel(){Name = pizzaViewModel.Crust};
                    newPizza.Size = new SizeModel(){Name = pizzaViewModel.Size};
                    newPizza.Toppings = new List<ToppingModel>();
                    foreach(var item in pizzaViewModel.SelectedToppings)
                    {
                         newPizza.Toppings.Add(new ToppingModel(){Name = item});
                    } 
                    _uservm.CurrentOrder.Pizzas.Add(newPizza);
                    return Redirect("/user/index"); //http 300-series status
                    //^--sends to browser to request user controller, index action
                    
               }
               else
               {
                    return View("Order", pizzaViewModel);
               }
          }
          [HttpGet]
          public IActionResult OrderList(UserViewModel u)
          {
               ViewBag.User(u);
               return View("DisplayList");
          }
          [HttpPost]
          public IActionResult Checkout(UserViewModel u)
          {
               _pr.CreateOrder(u.CurrentOrder);
               //add all to repo
               return Redirect("user/clearorder");
          }

      
     }
}