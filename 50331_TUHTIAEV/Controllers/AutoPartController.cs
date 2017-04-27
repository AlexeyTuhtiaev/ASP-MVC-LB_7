using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.DAL.Entities;
using Shop.DAL.Interfaces;
using _50331_TUHTIAEV.Models;
using System.Drawing;
using System.Threading.Tasks;

namespace _50331_TUHTIAEV.Controllers
{
    public class AutoPartController : Controller
    {
        IRepository<AutoPart> repository;
        int pageSize = 3;

        //хочу, для объектов, не имеющих фото, возвращать  imageToView (для метода GetImage)
        Type type;
        byte[] imageToView;


        public AutoPartController(IRepository<AutoPart> repos)
        {
            repository = repos;

            //заполняю type и imageToView
            Image image = Image.FromFile(@"D:\LEXA\БГУИР\ASP\50331_TUHTIAEV_LB6\50331_TUHTIAEV\Images\photo.png");
            System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
            image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
            imageToView = memoryStream.ToArray();
            type = image.GetType();
        }

        // GET: AutoPart
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult List()
        //{
        //    return View(repsitory.GetAllAutoParts());
        //}

        //ЛБ4
        //public ActionResult List(int page = 1)
        //{
        //    var lst = repsitory.GetAllAutoParts().OrderBy(ap => ap.Weight);
        //    return View(PageListViewModel<AutoPart>.CreatePage(lst, page,pageSize));
        //}

        //ЛБ5
        public ActionResult List(string category, int page = 1)
        {
            var itemsList = repository.GetAllAutoParts()
                                        .Where(d => category == null || d.GroupName.Equals(category))
                                        .OrderBy(d => d.Weight);
            var model = PageListViewModel<AutoPart>.CreatePage(itemsList, page, pageSize);
            if (Request.IsAjaxRequest())
            {
                return PartialView("ListViewPatial", model);
            }
            return View(model);
        }

        //public FileContentResult GetImage(int autoPartId)
        //{
        //    AutoPart ap = repository.GetAutoPart(autoPartId);

        //    if (ap != null && ap.Image != null)
        //        return File(ap.Image, ap.MimeType);
        //    else
        //    {
        //        return File(imageToView, type.ToString()); ;
        //    }
        //}

        public async Task<FileContentResult> GetImage(int autoPartId)
        {
            AutoPart ap = await repository.GetAutoPartAsync(autoPartId);

            if (ap != null && ap.Image != null)
                return File(ap.Image, ap.MimeType);
            else
            {
                return File(imageToView, type.ToString()); ;
            }
        }
    }
}