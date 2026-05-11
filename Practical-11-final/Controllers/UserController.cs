using Practical_11_final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practical_11_final.Controllers
{
    public class UserController : Controller
    {

        static List<User> userList = new List<User>() {
            new User {Id=1, Name = "Amit Shah", DOB = new DateTime(1995, 5, 12), Address = "Ahmedabad" },
            new User {Id=2, Name = "Priya Patel", DOB = new DateTime(1998, 8, 25), Address = "Surat" },
            new User {Id=3, Name = "Rahul Mehta", DOB = new DateTime(1993, 3, 18), Address = "Vadodara" },
            new User {Id=4, Name = "Neha Joshi", DOB = new DateTime(1997, 11, 5), Address = "Rajkot" },
            new User {Id=5, Name = "Karan Desai", DOB = new DateTime(1994, 1, 30), Address = "Gandhinagar" }
            };

        // GET: User
        public ActionResult Index()
        {
            return View(userList);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User userobj)
        {
            userobj.Id = userList.Count + 1;
            userList.Add(userobj);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var user = userList.Find(x => x.Id == id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(User userobj)
        {
            var user = userList.Find(x => x.Id == userobj.Id);
            if(user != null)
            {
                user.Name = userobj.Name;
                user.DOB = userobj.DOB;
                user.Address = userobj.Address;
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var user = userList.FirstOrDefault(x => x.Id == id);
            if(user != null)
            {
                userList.Remove(user);
            }
            return RedirectToAction("Index");   
        }

        public ActionResult Details(int id)
        {
            var user = userList.Find(x => x.Id == id);
            return View(user);
        }

    }
}