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
          private static UserViewModel _uservm;
          private static StoreViewModel _storevm;
          private static StoreModel _store;
          public OrderController(PizzaBoxDbContext dbContext) //constructor dependency injection
          {
               _db = dbContext;
               _pr = new PizzaBoxRepo(_db);
          }

          //[Route("/home")] Method Routing
          
          public IActionResult Home(UserViewModel u)
          {
               if(_uservm == null)
               {
                    _uservm = u;
               }
               return View("Order", new PizzaViewModel());
          }
          
          [HttpPost]
          [ValidateAntiForgeryToken]
          public IActionResult PlaceOrder(PizzaViewModel pizzaViewModel) //model binding
          {
               if(ModelState.IsValid) //validating if values are null with data annotations
               {
                    var p = new PizzaFactory(); //use dependency injection
                    PizzaModel newPizza = p.Create();
                    newPizza.Name = pizzaViewModel.Name;
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
          [HttpPost()]
          public IActionResult PostStore(StoreViewModel storeViewModel)
          {
               _storevm = storeViewModel;
               var s = new StoreFactory();
               _store = s.Create();
               _store.Name = _storevm.Store;
               _store.StoreOrders = _pr.ReadStore(_store);
                _storevm.StoreOrders = _store.StoreOrders;
                  
               return Redirect("/user/index");
          }
          [HttpGet]
          public IActionResult OrderList(UserViewModel u)
          {
               if(_uservm == null)
               {
                    return Redirect("/user/index");
               }
               return View("DisplayList", _uservm.CurrentOrder);
          }

          [HttpPost]
          [ValidateAntiForgeryToken]
          public IActionResult Edit(OrderViewModel o)
          {
               _uservm.CurrentOrder.Pizzas.RemoveAt(o.SelectedPizza);
               return View("Order", new PizzaViewModel());
          }
          [HttpPost]
          public IActionResult UserHistory(UserViewModel u)
          {
               return View("UserHistory", u);
          }
          [HttpPost]
          public IActionResult Checkout(UserViewModel u)
          {
               var user = _uservm.AddUser();
               user.Name = _uservm.Name;
               var o = new OrderFactory();
               var order = o.Create();
               order.Pizzas = _uservm.CurrentOrder.Pizzas;
               order.Name = "Order"; //generic name
               order.DateOrdered = _uservm.CurrentOrder.DateOrdered;
               user.UserOrders.Add(order);
               _store = _storevm.AddStore();
               _store.Name = _storevm.Store;
               _store.StoreOrders = user.UserOrders;               
               _pr.CreateUser(user);               
                _pr.CreateStore(_store);
               
               foreach(var p in order.Pizzas)
               {
                    _pr.CreatePizza(p);
               }
               _uservm = null;
               _storevm = null;
               return Redirect("/user/index");
          }

      
     }
}