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

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                var us = userDAO.Details(id);
                if (us == null)
                {
                    return HttpNotFound();
                }
                return View(us);
            }
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var us = userDAO.Details(id);
            if (us == null)
            {
                return HttpNotFound();
            }
            return View("Form", us);
        }
	}
}