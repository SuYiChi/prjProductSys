using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

using prjProductSys.Models;

namespace prjProductSys.Controllers
{
    public class HomeController : Controller
    {

        // GET: 使用者登入
        public ActionResult Index()
        {
            return View();
        }

        // Post: 使用者登入
        // 成功: 轉向產品類別頁面(Category)
        // 失敗: 回到登入頁
        [HttpPost]
        public ActionResult Index(string UId, string UPwd)
        {
            dbProductEntities dbProduct = new dbProductEntities();

            var member = dbProduct.會員.Where(m => m.帳號 == UId && m.密碼 == UPwd).FirstOrDefault();

            if (member != null)
            {
                FormsAuthentication.RedirectFromLoginPage(UId, true);
                return RedirectToAction("Index", "Category");
            }
            //登入失敗: 紀錄沒有登入, 並導回登入頁
            ViewBag.IsLogin = false;
            return View();
        }
    }
}