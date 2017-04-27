using Shop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _50331_TUHTIAEV.Models
{
    public class CartItem
    {
        public AutoPart autoPart { get; set; }
        public int quantity { get; set; }
    }


    public class Cart
    {
        List<CartItem> items;
        public Cart()
        {
            items = new List<CartItem>();
        }

        /// <summary>
        /// Добавить в корзину
        /// </summary>
        /// <param name="autoPart">объект для добавления</param>
        public void AddItem(AutoPart autoPart)
        {
            var item = items.Find(i => i.autoPart.AutoPartId == autoPart.AutoPartId);
            if (item == null)
            {
                items.Add(new CartItem { autoPart = autoPart,quantity = 1 });
            }
            else
                item.quantity += 1;
        }

        /// <summary>
        /// Удалить из корзины
        /// </summary>
        /// <param name="autoPart">Объект для удаления</param>
        public void RemoveItem(AutoPart autoPart)
        {
            var item = items.Find(i => i.autoPart.AutoPartId == autoPart.AutoPartId);
            if (item.quantity == 1)
                items.Remove(item);
            else
                item.quantity -= 1;
        }

        /// <summary>
        /// Очистить корзину
        /// </summary>
        public void Clear()
        {
            items.Clear();
        }

        /// <summary>
        /// Получение суммы калорий
        /// </summary>
        /// <returns></returns>
        public decimal GetTotal()
        {
            return items.Sum(i => i.autoPart.Price * i.quantity);
        }

        /// <summary>
        /// Получение содержимого корзины 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CartItem> GetItems()
        {
            return items;
        }
    }
}