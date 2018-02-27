using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using MySQLCore.Models;
using System;
using ToDo.Models;

namespace ToDo.Controllers
{
    public class ItemsController : Controller
    {

      [HttpGet("/Items/Index")]
      public ActionResult Index()
      {
        List<Item> secondItems = new List<Item>{};
        return View(secondItems);
      }

        [HttpGet("/items")]
        public ActionResult ItemsIndex()
        {
            List<Item> allItems = Item.GetAll();
            List<Item> secondItems = new List<Item>{};

            if (allItems.Count <= 0)
            {
                allItems = secondItems;
            }
            return View("Index", allItems);
        }


        [HttpGet("/items/new")]
        public ActionResult CreateForm()
        {
            return View();
        }
        [HttpPost("/items/new")]
        public ActionResult Create()
        {
            Item newItem = new Item(Request.Form["item-description"]);
            newItem.Save();
            // return RedirectToAction("Success", "Home");
            return View("Success");

        }


        //ONE TASK
        [HttpGet("/items/{id}")]
        public ActionResult Details(int id)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Item selectedItem = Item.Find(id);
            List<Category> itemCategories = selectedItem.GetCategories();
            List<Category> allCategories = Category.GetAll();
            model.Add("item", selectedItem);
            model.Add("itemCategories", itemCategories);
            model.Add("allCategories", allCategories);
            return View( model);

        }

        //ADD CATEGORY TO TASK
        [HttpPost("/items/{itemId}/categories/new")]
        public ActionResult AddCategory(int itemId)
        {
            Item item = Item.Find(itemId);
            Category category = Category.Find(Int32.Parse(Request.Form["category-id"]));
            item.AddCategory(category);
            return RedirectToAction("Success", "Home");
        }

    }

}
