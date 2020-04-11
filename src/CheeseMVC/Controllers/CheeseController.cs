using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Models;
using CheeseMVC.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {
        public IActionResult Index()
        {
            EditCheeseViewModel model = new EditCheeseViewModel
            {
                Cheeses = CheeseData.GetAll()
            };

            return View(model);
        }

        public IActionResult Add()
        {
            EditCheeseViewModel addModel = new EditCheeseViewModel();
            return View(addModel);
        }


        [HttpPost]
        public IActionResult Add(EditCheeseViewModel cheeseListViewModel)
        {
            if (ModelState.IsValid)
            {
                Cheese newCheese = new Cheese
                {

                    Name = cheeseListViewModel.Name,
                    Description = cheeseListViewModel.Description,
                    Type = cheeseListViewModel.Type
                };

                // Add the new cheese to my existing cheeses
                CheeseData.Add(newCheese);

                return Redirect("/Cheese");
            }
            return View(cheeseListViewModel);
        }
        public IActionResult Remove()
        {
            ViewBag.title = "Remove Cheeses";
                ViewBag.cheeses = CheeseData.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Remove(int[] cheeseIds)
        {
            foreach (int cheeseId in cheeseIds)
            {
                CheeseData.Remove(cheeseId);            
           }
            return Redirect("/");
        }

        public IActionResult Edit(int cheeseId)
        {
            Cheese cheese = CheeseData.GetById(cheeseId);
            EditCheeseViewModel editCheeseViewModel = new EditCheeseViewModel
            {
                CheeseId = cheese.CheeseId,
                Name = cheese.Name,
                Description = cheese.Description,
                Type = cheese.Type

            };
            return View(editCheeseViewModel);
        }

        [HttpPost]
        public IActionResult Edit(EditCheeseViewModel editCheeseViewModel)
        {
            if (ModelState.IsValid)
            {
                Cheese cheese = CheeseData.GetById(editCheeseViewModel.CheeseId);
                cheese.Name = editCheeseViewModel.Name;
                cheese.Description = editCheeseViewModel.Description;
                cheese.Type = editCheeseViewModel.Type;
                return Redirect("/Cheese");
            }
            return View(editCheeseViewModel);
        }
    }

}

