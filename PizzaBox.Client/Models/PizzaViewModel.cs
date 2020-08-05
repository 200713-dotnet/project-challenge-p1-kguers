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

          // in from the client
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
               Crusts = new List<CrustModel>() {new CrustModel(){Name = "Stuffed"}};
               Sizes = new List<SizeModel>() { new SizeModel() {Name = "Medium"}};
               Toppings = new List<ToppingModel>() {
                    new ToppingModel() {Name = "Pepperoni"},
                    new ToppingModel() {Name = "Sausage"}
                    };
               Toppings2 = new List<CheckBoxTopping>(){
                    new CheckBoxTopping() {Text = "Pepperoni", IsSelected = false},
                    new CheckBoxTopping() {Text = "Sausage", IsSelected = false}
                    };
          }
          
          public class CheckBoxTopping : ToppingModel
          {
               public string Text { get; set; }
               public bool IsSelected{ get; set; }
          }
     }
}