using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Models
{
     public class PizzaViewModel
     {
          //list out to client
          public List<CrustModel> Crusts { get; set; }
          public List<SizeModel> Sizes { get; set; }
          public List<ToppingModel> Toppings { get; set; }
          public List<CheckBoxTopping> Toppings2 { get; set; }
          //presets

          // in from the client
          public string Name { get; set; }
          [Required]
          public string Crust { get; set; }
          [Required]
          public string Size { get; set; }

          [MinLength(2)]
          [MaxLength(5)]
          public List<string> SelectedToppings { get; set; }
          public List<CheckBoxTopping> SelectedToppings2 { get; set; }


          public PizzaViewModel()
          {
               // instantiate options for pizza
               Crusts = new List<CrustModel>()
               {
                    new CrustModel(){Name = "Regular"},
                    new CrustModel(){Name = "Stuffed"},
                    new CrustModel(){Name = "Thin"}
               };
               Sizes = new List<SizeModel>() {
                    new SizeModel() {Name = "Small"},
                    new SizeModel() {Name = "Medium"},
                    new SizeModel() {Name = "Large"},
                    new SizeModel() {Name = "Party"}
               };
               Toppings = new List<ToppingModel>() {
                    new ToppingModel() {Name = "Cheese"},
                    new ToppingModel() {Name = "Sauce"},
                    new ToppingModel() {Name = "Pepperoni"},
                    new ToppingModel() {Name = "Sausage"},
                    new ToppingModel() {Name = "Bacon"},
                    new ToppingModel() {Name = "Meatball"},
                    new ToppingModel() {Name = "Ham"},
                    new ToppingModel() {Name = "Pineapple"}
               };
               Toppings2 = new List<CheckBoxTopping>(){
                    new CheckBoxTopping() {Text = "Cheese", IsSelected = false},
                    new CheckBoxTopping() {Text = "Sauce", IsSelected = false},
                    new CheckBoxTopping() {Text = "Pepperoni", IsSelected = false},
                    new CheckBoxTopping() {Text = "Sausage", IsSelected = false},
                    new CheckBoxTopping() {Text = "Bacon", IsSelected = false},
                    new CheckBoxTopping() {Text = "Meatball", IsSelected = false},
                    new CheckBoxTopping() {Text = "Ham", IsSelected = false},
                    new CheckBoxTopping() {Text = "Pineapple", IsSelected = false}
               };
          }
          public class CheckBoxTopping : ToppingModel
          {
               public string Text { get; set; }
               public bool IsSelected { get; set; }
          }

     }
}