using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheeseMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;



namespace CheeseMVC.ViewModels
{
    public class CheeseListViewModel
    {
        [Required]
        [Display(Name = "Cheese Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Cheese MUST have a Description!")]
        public string Description { get; set; }
        public string Title { get; set; } = "All Cheeses";
        public List<Cheese> Cheeses { get; set; }

        public CheeseType Type { get; set; }

        // public int CheeseId { get; set; }
        // private static int nextId = 1;
        public List<SelectListItem> CheeseTypes { get; set; }

        public CheeseListViewModel()
        {
            CheeseTypes = new List<SelectListItem>();
            CheeseTypes.Add(new SelectListItem
            {
                Value = ((int)CheeseType.Hard).ToString(),
                Text = CheeseType.Hard.ToString()
            });

            CheeseTypes.Add(new SelectListItem
            {
                Value = ((int)CheeseType.Soft).ToString(),
                Text = CheeseType.Soft.ToString()
            });

            CheeseTypes.Add(new SelectListItem
            {
                Value = ((int)CheeseType.Fake).ToString(),
                Text = CheeseType.Fake.ToString()
            });
        }

    }
}
