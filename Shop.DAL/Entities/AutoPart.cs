using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Shop.DAL.Entities
{
    public class AutoPart
    {
        [HiddenInput]
        public int AutoPartId { get; set; }

        [Required(ErrorMessage = "Необходимо ввести наименование")]
        [Display(Name = "Наименование")]
        public string AutoPartName { get; set; }

        [Required(ErrorMessage = "Необходимо ввести описание")]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Поле вес заполнено некорректно")]

        [Display(Name = "Вес")]
        [Range(0.001, 200, ErrorMessage = "Введите вес от 0 до 500 кг!")]
        //[Range(minimum:0.1, maximum:500.0,ErrorMessage ="Введите вес от 0 до 500 кг!!!")]
        //[Range(Double.MinValue, Double.MaxValue, ErrorMessage = "Введите вес от 0 до 500 кг!!Doubledd!")]
        //[Range(typeof(double), "0", "100")]
        //[Range(10.1, 1000, ErrorMessage = "Value between {1} and {2}")]
        public double Weight { get; set; }

        [Required(ErrorMessage = "Необходимо ввести имя группы товаров")]
        [Display(Name = "Группа товаров")]
        public string GroupName { get; set; }

        [ScaffoldColumn(false)]
        public byte[] Image { get; set; }
        [ScaffoldColumn(false)]
        public string MimeType { get; set; }

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Необходимо ввести цену товара")]
        [Display(Name = "Цена")]
        public decimal Price { get; set; }
    }
}
