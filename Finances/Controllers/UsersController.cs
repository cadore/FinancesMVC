using Finances.DAO;
using Finances.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Finances.Controllers
{
    public class UsersController : Controller
    {
        //
        // GET: /User/
        private UserDAO userDAO;
        public UsersController(UserDAO userDAO)
        {
            this.userDAO = userDAO;
        }
        public ActionResult Index()
        {
            return View(userDAO.List());
        }

        public ActionResult Form()
        {
            return View();
        }

        public ActionResult Save(User us)
        {
            if (us == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    userDAO.Save(us);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Form", us);
                }
            }
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                var us = userDAO.Details(id);
                if (us == null)
                {
                    return RedirectToAction("Index");
                }
                return View(us);
            }
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var us = userDAO.Details(id);
            if (us == null)
            {
                return RedirectToAction("Index");
            }
            return View("Form", us);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return RedirectToAction("Index");
            }
            userDAO.Delete(id);
            return RedirectToAction("Index");
        }
	}
}