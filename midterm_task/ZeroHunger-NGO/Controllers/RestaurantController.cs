using System.Web.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZeroHunger_NGO.DB;

namespace NGO.Controllers
{
    public class RestaurantController : Controller
    {
        [HttpPost]
        public ActionResult ResCreate(Restaurant restaurant)
        {
            var db = new ZeroHungerEntities2();
            db.Restaurants.Add(restaurant);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Index(int id = 1)
        {
            var db = new ZeroHungerEntities2();
            var result = (from don in db.Donations
                          where don.ResId == id
                          select don).ToList();
            return View(result);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Donation don)
        {
            var db = new ZeroHungerEntities2();
            db.Donations.Add(don);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var db = new ZeroHungerEntities2();
            var result = (from don in db.Donations
                          where don.Id == id
                          select don).SingleOrDefault();
            return View(result);
        }
        [HttpPost]
        public ActionResult Edit(Donation donation)
        {
            var db = new ZeroHungerEntities2();
            var ext = (from don in db.Employees
                       where don.Id == donation.Id
                       select don).SingleOrDefault();
            db.Entry(ext).CurrentValues.SetValues(donation);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}