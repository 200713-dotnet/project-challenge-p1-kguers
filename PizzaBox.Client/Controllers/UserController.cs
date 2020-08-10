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
     public class UserController : Controller
     {
          private readonly PizzaBoxDbContext _db;
          private PizzaBoxRepo _pr;
          private static UserModel _user;
          private static StoreModel _store;
          private static UserViewModel _uservm;
          private static StoreViewModel _storevm;
          public UserController(PizzaBoxDbContext dbContext) //constructor dependency injection
          {
               _db = dbContext;
               _pr = new PizzaBoxRepo(_db);
          }
          public IActionResult Index()
          {
               if(_user == null)
               {
                    return View("User", new UserViewModel());
               }
               else
               {
                    return View("UserDirectory", _user);
               }
          }
          
          [HttpPost]
          [ValidateAntiForgeryToken]
          public IActionResult Name(UserViewModel userViewModel)
          {
               if(ModelState.IsValid)
               {
                    _uservm = userViewModel;
                    var u = new UserFactory();
                    _user = u.Create();
                    _user.Name = userViewModel.Name;
                    //_user = _pr.ReadUser(_user);
                    if(_user.UserOrders == null)
                    {
                         _pr.CreateUser(_user);
                    }
                    return View("UserStore", new StoreViewModel());//??
               }
               else
               {
                    return View("User", userViewModel);
               }
          }

          [HttpPost()]
          public IActionResult PostStore(StoreViewModel storeViewModel)
          {
               _storevm = storeViewModel;
               var s = new StoreFactory();
               _store = s.Create();
               _store.Name = storeViewModel.Store;
               // newStore.StoreOrders = _pr.ReadStore(newStore);
               if(_store.StoreOrders == null)
               {
                    _pr.CreateStore(_store);
               }
               return View("UserDirectory", _uservm);
          }

     }
}