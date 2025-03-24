using MyClass.DAO;
using MyClass.Models;
using System.Web.Mvc;

namespace BanDienThoai.Controllers
{
    public class TimkiemController : Controller
    {
        // GET: Search
        Product product = new Product();
        ProductDAO productDAO = new ProductDAO();
        public ActionResult Index(string SearchString, int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 8;
            if (string.IsNullOrEmpty(SearchString))
            {
                ViewBag.Notification = "Từ khóa tìm kiếm chưa hợp lệ";
            }
            else
            {
                if (SearchString == "" || SearchString.Length < 3)
                {
                    ViewBag.Notification = "Từ khóa tìm kiếm chưa hợp lệ";
                }
                else
                {
                    var resultProduct = new ProductDAO().SearchByKey(SearchString);
                    return View(resultProduct);
                }
            }

            return View();
        }
    }
}