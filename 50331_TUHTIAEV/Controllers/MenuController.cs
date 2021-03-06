﻿using _50331_TUHTIAEV.Models;
using Shop.DAL.Entities;
using Shop.DAL.Interfaces;
using Shop.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _50331_TUHTIAEV.Controllers
{
    public class MenuController : Controller
    {
        List<MenuItem> items;
        IRepository<AutoPart> repository;

        public MenuController(IRepository<AutoPart> repos)
        {
            repository = repos;

            items = new List<MenuItem>
            {
                new MenuItem{Name="Домой", Controller="Home",
                Action="Index", Active=string.Empty},

                new MenuItem{Name="Список товаров", Controller="AutoPart",
                Action="List", Active=string.Empty},

                new MenuItem{Name="Каталог", Controller="Product",
                Action="List", Active=string.Empty},

                new MenuItem{Name="Администрирование", Controller="Admin",
                Action="Index", Active=string.Empty},
            };
        }

        // GET: Menu
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Main(string a = "Index", string c = "Home")
        {
            IEnumerable<MenuItem> itemCliced = items.Where<MenuItem>(m => m.Controller == c);
            if (itemCliced.Any())
                items.First(m => m.Controller == c).Active = "active";
            return PartialView(items);
        }

        public PartialViewResult UserInfo()
        {
            return PartialView();
        }

        public PartialViewResult Side()
        {
            var groupsNames = repository.GetAllAutoParts()
                                                     .Select(ap => ap.GroupName)
                                                     .Distinct();
            return PartialView(groupsNames);
        }

        public PartialViewResult Map()
        {
            return PartialView(items);
        }
    }
}