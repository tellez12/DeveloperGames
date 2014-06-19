using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DeveloperGames.Domain.Entities;
using DeveloperGames.Domain.EF;
using DeveloperGames.WebUI.Models;
using Microsoft.AspNet.Identity;

namespace DeveloperGames.WebUI.Controllers
{
    public class UserStrategyController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /UserStrategy/
        public ActionResult Index()
        {
            return View(db.UserStrategies.ToList());
        }

        // GET: /UserStrategy/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserStrategy userstrategy = db.UserStrategies.Find(id);
            if (userstrategy == null)
            {
                return HttpNotFound();
            }
            return View(userstrategy);
        }

        // GET: /UserStrategy/Create
        public ActionResult Create()
        {
            var model = new UserStrategyViewModel{
                     GameId = 1,
                     UserId = User.Identity.GetUserId(),
                     UserCode = db.Games.Find(1).SampleCode
                        };
            return View(model);
        }

        // POST: /UserStrategy/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,UserCode")] UserStrategyViewModel model)
        {
           
            if (ModelState.IsValid)
            {
                var userstrategy = new UserStrategy()
                            {
                                UserId = User.Identity.GetUserId(),
                                GameId = model.GameId,
                                UserCode =  model.UserCode
                            };
                db.UserStrategies.Add(userstrategy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: /UserStrategy/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserStrategy userstrategy = db.UserStrategies.Find(id);
            if (userstrategy == null)
            {
                return HttpNotFound();
            }
            return View(userstrategy);
        }

        // POST: /UserStrategy/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,UserCode")] UserStrategy model)
        {
            if (ModelState.IsValid)
            {
                var userstrategy = new UserStrategy()
                {
                    UserId = User.Identity.GetUserId(),
                    GameId = model.GameId,
                    UserCode = model.UserCode
                };
                db.Entry(userstrategy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: /UserStrategy/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserStrategy userstrategy = db.UserStrategies.Find(id);
            if (userstrategy == null)
            {
                return HttpNotFound();
            }
            return View(userstrategy);
        }

        // POST: /UserStrategy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserStrategy userstrategy = db.UserStrategies.Find(id);
            db.UserStrategies.Remove(userstrategy);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
