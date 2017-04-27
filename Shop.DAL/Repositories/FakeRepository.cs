using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.DAL.Entities;
using Shop.DAL.Interfaces;

namespace Shop.DAL.Repositories
{
    public class FakeRepository : IRepository<AutoPart>
    {
        public void CreateAutoPart(AutoPart autoPart)
        {
            throw new NotImplementedException();
        }

        public void DeleteAutoPart(int autoPartId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AutoPart> FindAutoPart(Func<AutoPart, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AutoPart> GetAllAutoParts()
        {
            //    List<AutoPart> autoPatrs = new List<AutoPart> {
            //    new AutoPart { AutoPartId=1,Description="Для модеей после 2015 года",
            //    AutoPartName ="Тормозные колодки задние", GroupName="Тормозная система", Weight=0.35M,Price=25.2M},

            //    new AutoPart { AutoPartId=2,Description="Для модеей после 2015 года",
            //    AutoPartName ="Тормозные колодки передние", GroupName="Тормозная система", Weight=0.27M,Price=22.7M},

            //    new AutoPart { AutoPartId=3,Description="В комплекте уплотнительное кольцо",
            //    AutoPartName ="Клапан топливный", GroupName="Система питания", Weight=0.05M,Price=35},

            //    new AutoPart { AutoPartId=4,Description="Для модеей с двигателем 1.6",
            //    AutoPartName ="Шкив распредвала", GroupName="Двигатель", Weight=2.74M,Price=59.7M},

            //    new AutoPart { AutoPartId=5,Description="Для модеей после 2011 года",
            //    AutoPartName ="Трос ручника", GroupName="Тормозная система", Weight=0.75M,Price=12.2M},

            //    new AutoPart { AutoPartId=6,Description="h=215, r=35, u=15",
            //    AutoPartName ="Клапан головки блока цилиндров", GroupName="Двигатель", Weight=0.1M,Price=17},

            //    new AutoPart { AutoPartId=7,Description="Гидромеханический",
            //    AutoPartName ="Регулятор холостого хода", GroupName="Система питания", Weight=0.52M,Price=73.2M},

            //    new AutoPart { AutoPartId=8,Description="В комплекте соединительные разъемы",
            //    AutoPartName ="Датчик уровня топлива", GroupName="Система питания", Weight=0.35M,Price=25.8M}
            //};
            //    return autoPatrs;
            return null;
        }

        public AutoPart GetAutoPart(int autoPartId)
        {
            throw new NotImplementedException();
        }

        public void UpdateAutoPart(AutoPart autoPart)
        {
            throw new NotImplementedException();
        }

        public Task<AutoPart> GetAutoPartAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
