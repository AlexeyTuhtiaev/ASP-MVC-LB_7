using Shop.DAL.Entities;
using Shop.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Repositories
{
    public class EFShopRepository : IRepository<AutoPart>
    {
        ShopContext context;
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="name"> имя строки подключения </param>
        public EFShopRepository(string name)
        {
            context = new ShopContext(name);
        }

        public void CreateAutoPart(AutoPart t)
        {
            context.AutoParts.Add(t);
            context.SaveChanges();
        }

        public void DeleteAutoPart(int id)
        {
            var item = context.AutoParts.Find(id);
            if (item != null)
                context.AutoParts.Remove(item);
            context.SaveChanges();
        }

        public IEnumerable<AutoPart> FindAutoPart(Func<AutoPart, bool> predicate)
        {
            return context.AutoParts.Where(predicate).ToList();
        }

        public AutoPart GetAutoPart(int id)
        {
            return context.AutoParts.Find(id);
        }
        public IEnumerable<AutoPart> GetAllAutoParts()
        {
            return context.AutoParts.OrderBy(ap=>ap.AutoPartName);
        }

        public void UpdateAutoPart(AutoPart t)
        {
            context.Entry<AutoPart>(t).State = EntityState.Modified;
            context.SaveChanges();
        }

        public Task<AutoPart> GetAutoPartAsync(int autoPartId)
        {
            return context.AutoParts.FindAsync(autoPartId);
        }
    }
}
