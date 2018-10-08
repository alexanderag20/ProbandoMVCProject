using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PruebaMVC_App.Models;

namespace PruebaMVC_App.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [HttpGet]
        public ActionResult AddOrEdit(int id=0)
        {
            User userModel = new User();

            return View(userModel);
        }
        [HttpPost]
        public ActionResult AddOrEdit (User userModel)
        {
            
            using (AppMVCEntitiesDB dbModel = new AppMVCEntitiesDB())
            {     
                dbModel.Users.Add(userModel);
                dbModel.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registration Successful";
            return View("AddOrEdit", new User());
        }
    }
}