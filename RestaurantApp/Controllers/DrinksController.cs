﻿/*
 * App: SuchiVille
 * File: DrinksController.cs
 * Developed by: Alex Andriishyn, Anthony Scinocco, Sam Parathuvayalil Sunny, Lyka Sunesara 
 * Purpose: Drinks endpoints
 */

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RestaurantApp.Models;

namespace RestaurantApp.Controllers
{
    public class DrinksController : Controller
    {
        private RestaurantContext db = new RestaurantContext();

        // GET: Drinks
        public async Task<ActionResult> Index()
        {
			ViewBag.title = "Drinks";
			var data = await db.Drinks.ToListAsync();
			if (User.Identity.IsAuthenticated) return View("MenuItems/AdminIndex", data);
			return View("MenuItems/UserIndex", data);
        }

        // GET: Drinks/Details/5
        public async Task<ActionResult> Details(int? id)
        {
			ViewBag.title = "Drinks";

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drink drink = await db.Drinks.FindAsync(id);
            if (drink == null)
            {
                return HttpNotFound();
            }
            return View("MenuItems/UserDetails", drink);
        }

        // GET: Drinks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Drinks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "DrinkId,Name,ThumbNail,FullImage,ShortDesc,FullDesc,Price")] Drink drink)
        {
            if (ModelState.IsValid)
            {
                db.Drinks.Add(drink);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(drink);
        }

        // GET: Drinks/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drink drink = await db.Drinks.FindAsync(id);
            if (drink == null)
            {
                return HttpNotFound();
            }
            return View(drink);
        }

        // POST: Drinks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "DrinkId,Name,ThumbNail,FullImage,ShortDesc,FullDesc,Price")] Drink drink)
        {
            if (ModelState.IsValid)
            {
                db.Entry(drink).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(drink);
        }

        // GET: Drinks/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drink drink = await db.Drinks.FindAsync(id);
            if (drink == null)
            {
                return HttpNotFound();
            }
            return View(drink);
        }

        // POST: Drinks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Drink drink = await db.Drinks.FindAsync(id);
            db.Drinks.Remove(drink);
            await db.SaveChangesAsync();
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
