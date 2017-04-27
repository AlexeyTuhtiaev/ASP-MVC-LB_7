﻿using _50331_TUHTIAEV.Models;
using Shop.DAL.Entities;
using Shop.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _50331_TUHTIAEV.Controllers
{
    public class CartController : Controller
    {
        IRepository<AutoPart> repository;
        public CartController(IRepository<AutoPart> repo)
        {
            repository = repo;
        }

        // GET: Cart
        [Authorize]
        public ActionResult Index(string returnUrl)
        {
            TempData["returnUrl"] = returnUrl;
            return View(GetCart());
        }
        
        /// <summary>
        /// Получение корзины из сессии
        /// </summary>
        /// <returns></returns>
        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }

        /// <summary>
        /// Добавление товара в корзину
        /// </summary>
        /// <param name="id">id добавляемого элемента</param>
        /// <param name="returnUrl">URL страницы для возврата</param>
        /// <returns></returns>
        public RedirectResult AddToCart(int id, string returnUrl)
        {
            var item = repository.GetAutoPart(id);
            if (item != null)
                GetCart().AddItem(item);
            return Redirect(returnUrl);
        }

        public PartialViewResult CartSummary(string returnUrl)
        {
            TempData["returnUrl"] = returnUrl;
            return PartialView(GetCart());
        }
    }
}