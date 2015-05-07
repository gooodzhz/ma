using MA.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MA.Web.Controllers
{
    public class AdminController : Controller
    {
        MaUserBLL _maUserBLL = new MaUserBLL();
        //
        // GET: /Admin/
        public ActionResult Index()
        {
            var list = _maUserBLL.GetList();
            return View();
        }
    }
}