using Lab26_ASP.NET_IDENTITY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;



namespace Lab26_ASP.NET_IDENTITY.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            //MenuItemEntities ORM = new MenuItemEntities();
            //string uid = User.Identity.GetUserId();
            //(from MenuItems in ORM.MenuItems
            // where MenuItems.ItemID == uid
            // select MenuItems).ToList();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        [Authorize]
        public ActionResult MenuList()
        {
            MenuItemEntities ORM = new MenuItemEntities();
            List<MenuItems> menuItems = ORM.MenuItems.ToList();
            //ViewBag.Items = ORM.items.ToList();
            //ViewBag.Items = Item;
            ViewBag.Items = menuItems;

            return View();
        }

        public ActionResult MenuListbyID(int itemID)
        {
            //@foreach(Item item in ViewBag.Items)
            MenuItemEntities ORM = new MenuItemEntities();
            List<MenuItems> items = (from item in ORM.MenuItems
                                     where item.ItemID == itemID
                                     select item).ToList();
            ViewBag.Items = items;
            return View("MenuList");
        }

        public ActionResult MenuListbyItemName(string itemName)
        {
            //@foreach(Item item in ViewBag.Items)
            MenuItemEntities ORM = new MenuItemEntities();
            List<MenuItems> items = (from item in ORM.MenuItems
                                     where item.ItemName.Contains(itemName)
                                     select item).ToList();
            ViewBag.Items = items;
            ViewBag.ItemNames = ORM.MenuItems.ToList();
            return View("MenuList");
        }

        public ActionResult MenuListbyDescription(string description)
        {
            //@foreach(Item item in ViewBag.Items)
            MenuItemEntities ORM = new MenuItemEntities();
            List<MenuItems> items = (from item in ORM.MenuItems
                                     where item.Description.Contains(description)
                                     select item).ToList();
            ViewBag.Items = items;
            ViewBag.Description = ORM.MenuItems.ToList();
            return View("MenuList");
        }

        public ActionResult MenuListbyPrice(int price)
        {
            //@foreach(Item item in ViewBag.Items)
            MenuItemEntities ORM = new MenuItemEntities();
            List<MenuItems> items = (from item in ORM.MenuItems
                                     where item.Price == price
                                     select item).ToList();
            ViewBag.Items = items;
            ViewBag.Price = ORM.MenuItems.ToList();
            return View("MenuList");
        }

        public ActionResult MenuListbyQuantity(int quantity)
        {
            //@foreach(Item item in ViewBag.Items)
            MenuItemEntities ORM = new MenuItemEntities();
            List<MenuItems> items = (from item in ORM.MenuItems
                                     where item.Quantity == quantity
                                     select item).ToList();
            ViewBag.Items = items;
            ViewBag.Quantity = ORM.MenuItems.ToList();
            return View("MenuList");
        }

        public ActionResult MenuListSorted(string column)
        {
            MenuItemEntities ORM = new MenuItemEntities();
            if (column == "ItemName")
            {
                ViewBag.Items = (from item in ORM.MenuItems
                                 orderby item.ItemName
                                 select item).ToList();
            }

            else if (column == "Description")
            {
                ViewBag.Items = (from item in ORM.MenuItems
                                 orderby item.Description
                                 select item).ToList();
            }

            else if (column == "Price")
            {
                ViewBag.Items = (from item in ORM.MenuItems
                                 orderby item.Price
                                 select item).ToList();
            }
            else if (column == "Quantity")
            {
                ViewBag.Items = (from item in ORM.MenuItems
                                 orderby item.Quantity
                                 select item).ToList();
            }
            else
            {
                ViewBag.ItemID = ORM.MenuItems.ToList();

            }
            return View("MenuList");
        }

        public ActionResult Add(int id)
        {
            MenuItemEntities ORM = new MenuItemEntities();

            //check if the Cart object already exists
            if (Session["Cart"] == null)
            {
                //if it doesn't, make a new list of books
                List<MenuItems> cart = new List<MenuItems>();
                //add this book to it
                cart.Add((from item in ORM.MenuItems
                          where item.ItemID == id
                          select item).Single());
                //add the list to the session
                Session.Add("Cart", cart);
            }
            else
            {
                //if it does exist, get the list
                List<MenuItems> cart = (List<MenuItems>)(Session["Cart"]);
                //add this book to it
                cart.Add((from item in ORM.MenuItems
                          where item.ItemID == id
                          select item).Single());
            }
            return View();
        }
    }
}