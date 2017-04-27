using Shop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Interfaces
{
   public interface IRepository<AutoPart>
    {
        IEnumerable<AutoPart> GetAllAutoParts();
        AutoPart GetAutoPart(int autoPartId);
        IEnumerable<AutoPart> FindAutoPart(Func<AutoPart, bool> predicate);
        void CreateAutoPart(AutoPart autoPart);
        void UpdateAutoPart(AutoPart autoPart);
        void DeleteAutoPart(int autoPartId);
        Task<AutoPart> GetAutoPartAsync(int autoPartId);
    }
}
