using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System.Linq;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class StatisticController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());

        Context database = new Context();

        public ActionResult Index()
        {
            var categoryvalues = cm.CountCategory();
            ViewBag.getCategoryCount = categoryvalues;

            var basliktakiKategori = database.Headings.Count(x => x.CategoryID == 11);
            ViewBag.getbasliktakiKategori = basliktakiKategori;

            var getContainsa = database.Writers.Count(x => x.WriterName.Contains("a"));
            ViewBag.getContainsa = getContainsa;

            var categoryadi = database.Headings.Max(x => x.Category.CategoryName);
            ViewBag.getcategoryadi = categoryadi;

            int getTrue = database.Categories.Count(x => x.CategoryStatus == true);
            int getFalse = database.Categories.Count(x => x.CategoryStatus == false);
            int fark = getTrue - getFalse;
            ViewBag.fark = fark;

            return View();
        }
    }
}