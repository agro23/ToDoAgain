using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using MySQLCore.Models;
using System;
using ToDo.Models;




namespace ToDo.Controllers
{
  public class HomeController : Controller
  {

    // [HttpGet("/")]
    // public ActionResult Index()
    // {
    //   return View("Index", Item.GetString());
    // }
    //

    [HttpGet("/")]
    public ActionResult Index()
    {
      List<Category> categories = new List <Category>{};
      categories = Category.GetAll();
      return View(categories);
    }


    [HttpGet("/categories/new")]
    public ActionResult CreateCatForm()
    {
      // Console.WriteLine("Got to Categories New");
      // List<Category> allCategories = new List<Category>{};
      // return View("Index", allCategories); // was plain view
      return View("CreateForm");
    }
    [HttpPost("/categories/new")]
    public ActionResult CreateCat()
    {
        Category newCategory = new Category(Request.Form["category-name"]);
        newCategory.Save();
        // return RedirectToAction("Success", "Home");
        return View("Success");
    }

    [HttpGet("/categories/{id}")]
    public ActionResult CatDetails(int id)
    {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Category selectedCategory = Category.Find(id);
        List<Item> categoryItems = selectedCategory.GetItems();
        List<Item> allItems = Item.GetAll();
        model.Add("category", selectedCategory);
        model.Add("categoryItems", categoryItems);
        model.Add("allItems", allItems);
        return View(model);
    }

    //ADD TASK TO CATEGORY
    [HttpPost("/categories/{categoryId}/items/new")]
    public ActionResult AddItem(int categoryId)
    {
        Category category = Category.Find(categoryId);
        Item item = Item.Find(Int32.Parse(Request.Form["item-id"]));
        category.AddItem(item);
        // return RedirectToAction("Success", "Home");
        return View("Success");
    }


    // [HttpGet("/")]
    // public ActionResult Index()
    // {
    // //   List<Item> Model = new List<Item> {};
    // //   // Model.Save;
    // //   return View("Index", Model);
    // List<Item> allItems = Item.GetAll();
    // Console.WriteLine("I'm in ItemsIndex()");
    // return View("Index", allItems);
    // }

    // [HttpGet("/items")]
    // public ActionResult ItemsIndex()
    // {
    //     List<Item> allItems = Item.GetAll();
    //     Console.WriteLine("I'm in ItemsIndex()");
    //     return View("Index", allItems);
    // }
    //
    // [HttpGet("/date/asc")]
    // public ActionResult ToggleDateIndexAsc()
    // {
    //   List<Item> allItems = Item.GetAll();
    //   Console.WriteLine("Toggle Positive");
    //   return View("IndexByAsc", allItems);
    // }

    // [HttpGet("/date/desc")]
    // public ActionResult ToggleDateIndexDesc()
    // {
    //   List<Item> allItems = Item.GetAllDesc();
    //   Console.WriteLine("Toggle Negative");
    //   return View("IndexByDesc", allItems);
    // }

    // [HttpGet("/items/new")]
    // public ActionResult CreateForm()
    // {
    //   Console.WriteLine("I'm in CreateForm()");
    //     // return View("Index");
    //     return View();
    // }
    //
    // [HttpPost("/items")]
    // public ActionResult Create()
    // {
    //   string x = Request.Form["new-item-date"];
    //   string[] x1 = x.Split('-');
    //   DateTime x2 = new DateTime(int.Parse(x1[0]), int.Parse(x1[1]), int.Parse(x1[2])).Date;
    //   Item newItem = new Item (Request.Form["new-item"], 1); // *****
    //   Console.WriteLine("I'm in Create()");
    //   Console.WriteLine("The details are: " + Request.Form["new-item"] + " AND " + Request.Form["new-item-date"]); // *****
    //   //
    //   newItem.Save();
    //   List<Item> allItems = Item.GetAll();
    //   // return RedirectToAction("Index");
    //   return View("Index", allItems);
    //   // return View();
    //
    // }
    //
    // [HttpGet("/items/{id}")]
    // public ActionResult Details(int id)
    // {
    //   Console.WriteLine("I'm in Find()");
    //     Item item = Item.Find(id);
    //     return View(item);
    // }
    //
    // [HttpGet("/items/{id}/update")]
    // public ActionResult UpdateForm(int id)
    // {
    //   Console.WriteLine("I'm in Update() and ID is " + id);
    //     Item item = Item.Find(id);
    //     return View("Update", item);
    // }
    //
    // [HttpPost("/items/{id}/update")]
    // public ActionResult Update(int id)
    // {
    //     Item thisItem = Item.Find(id);
    //     thisItem.UpdateDescription(Request.Form["new-name"]);
    //     return RedirectToAction("Index");
    // }
    //
    // [HttpGet("/items/{id}/delete")]
    // public ActionResult Delete(int id)
    // {
    //     Item thisItem = Item.Find(id);
    //     thisItem.Delete();
    //     return RedirectToAction("Index");
    // }
    //
    //
    // [HttpPost("/items/delete")]
    // public ActionResult DeleteAll()
    // {
    //   Console.WriteLine("I'm in DeleteALL()");
    //     Item.DeleteAll();
    //     return View();
    // }


  }
}
