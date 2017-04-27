using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Entities
{
    class ShopContext: DbContext
    {
        /// <summary>
        /// Конструктор класса
        /// </summary>
        ///// <param name="name"> имя строки подключения </param>
        public ShopContext(string name) : base(name)
{
            Database.SetInitializer(new ShopContextInitializer());
        }
        public DbSet<AutoPart> AutoParts { get; set; }
    }

    class ShopContextInitializer :DropCreateDatabaseIfModelChanges<ShopContext>
    {
        protected override void Seed(ShopContext context)
        {
            List<AutoPart> autoParts = new List<AutoPart> {
            new AutoPart { AutoPartId=1,Description="Для модеей после 2015 года",
            AutoPartName ="Тормозные колодки задние", GroupName="Тормозная система", Weight=0.35,Price=25},

            new AutoPart { AutoPartId=2,Description="Для модеей после 2015 года",
            AutoPartName ="Тормозные колодки передние", GroupName="Тормозная система", Weight=0.27,Price=22},

            new AutoPart { AutoPartId=3,Description="В комплекте уплотнительное кольцо",
            AutoPartName ="Клапан топливный", GroupName="Система питания", Weight=0.05,Price=35},

            new AutoPart { AutoPartId=4,Description="Для модеей с двигателем 1.6",
            AutoPartName ="Шкив распредвала", GroupName="Двигатель", Weight=2.74,Price=59},

            new AutoPart { AutoPartId=5,Description="Для модеей после 2011 года",
            AutoPartName ="Трос ручника", GroupName="Тормозная система", Weight=0.75,Price=12},

            new AutoPart { AutoPartId=6,Description="h=215, r=35, u=15",
            AutoPartName ="Клапан головки блока цилиндров", GroupName="Двигатель", Weight=0.1,Price=17},

            new AutoPart { AutoPartId=7,Description="Гидромеханический",
            AutoPartName ="Регулятор холостого хода", GroupName="Система питания", Weight=0.52,Price=73},

            new AutoPart { AutoPartId=8,Description="В комплекте соединительные разъемы",
            AutoPartName ="Датчик уровня топлива", GroupName="Система питания", Weight=0.35,Price=25}
        };
            context.AutoParts.AddRange(autoParts);
            context.SaveChanges();
        }
    }
}
