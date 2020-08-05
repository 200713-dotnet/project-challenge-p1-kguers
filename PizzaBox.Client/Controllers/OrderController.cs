using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;
using PizzaBox.Domain.Factories;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;

namespace PizzaBox.Client.Controllers
{
     //[Route("/{controller}/{action}")] //controller routing
     //[EnableCors("private")] //adds private policy
     public class OrderController : Controller
     {
          private readonly PizzaBoxDbContext _db;
          public OrderController(PizzaBoxDbContext dbContext) //constructor dependency injection
          {
               _db = dbContext;
          }

          //[Route("/home")] Method Routing
          public IActionResult Home()
          {
               return View("Order", new PizzaViewModel());
          }
          
          [HttpPost]
          [ValidateAntiForgeryToken]
          public IActionResult PlaceOrder(PizzaViewModel pizzaViewModel) //model binding
          {
               // if(ModelState.IsValid) //validating if values are null with data annotations
               // {
               //      var p = new PizzaFactory(); //use dependency injection
               //      //p.Create(pizzaViewModel);
               //      //repo.Create(pizzaViewModel);

               //      //return View("User"); // in scope of OrderController
               //      return Redirect("/user/index"); //http 300-series status
               //      //^--sends to browser to request user controller, index action
                    
               // }
               // else
               // {
                    return View("Order", pizzaViewModel);
               // }
          }
      
     }
}