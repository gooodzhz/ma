using MA.BLL;
using MA.Model;
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
        public ActionResult Index(string index, string name)
        {
            PagerInfo pager = new PagerInfo();
            pager.PageIndex = index;
            var list = _maUserBLL.SearchByName(name, pager);
            ViewBag.Name = name;
            ViewBag.Pager = pager;
            return View(list);
        }

        public PartialViewResult Add()
        {
            ViewBag.DiaTitle = "新增用户";
            return PartialView("Edit");
        }

        public PartialViewResult Edit(int id)
        {
            ViewBag.DiaTitle = "编辑用户";
            MaUser maUser = _maUserBLL.GetById(id);
            ViewBag.Info = maUser;
            return PartialView();
        }

        public void Save(string name, string pwd, string nickname)
        {
            try
            {
                if (string.IsNullOrEmpty(name))
                {
                    Response.Write(string.Format("0:{0}不能为空", MaUserSummary.NameSummary)); Response.End(); return;
                }
                if (name.Length > MaUserSummary.NameCharLength)
                {
                    Response.Write(string.Format("0:{0}长度不能超过", MaUserSummary.NameSummary, MaUserSummary.NameCharLength)); Response.End(); return;
                }
                if (string.IsNullOrEmpty(pwd))
                {
                    Response.Write(string.Format("0:{0}不能为空", MaUserSummary.PwdSummary)); Response.End(); return;
                }
                if (pwd.Length > MaUserSummary.NameCharLength)
                {
                    Response.Write(string.Format("0:{0}长度不能超过", MaUserSummary.PwdSummary, MaUserSummary.PwdCharLength)); Response.End(); return;
                }
                if (string.IsNullOrEmpty(nickname))
                {
                    Response.Write(string.Format("0:{0}不能为空", MaUserSummary.NicknameSummary)); Response.End(); return;
                }
                if (nickname.Length > MaUserSummary.NameCharLength)
                {
                    Response.Write(string.Format("0:{0}长度不能超过", MaUserSummary.NicknameSummary, MaUserSummary.NicknameCharLength)); Response.End(); return;
                }
                MaUser info = new MaUser();
                info.Name = name;
                info.Pwd = pwd;
                info.Nickname = nickname;
                _maUserBLL.Add(info);
                Response.Write("1:保存成功");
                Response.End();
            }
            catch (Exception e)
            {
                Response.Write("0:保存失败 " + e.Message);
                Response.End();
            }
        }

    }
}