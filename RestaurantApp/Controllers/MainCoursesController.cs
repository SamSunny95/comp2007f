﻿/*
 * App: SuchiVille
 * File: MainCoursesController.cs
 * Developed by: Alex Andriishyn, Anthony Scinocco, Sam Parathuvayalil Sunny, Lyka Sunesara 
 * Purpose: Main Courses endpoints
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
    public class MainCoursesController : Controller
    {
        private RestaurantContext db = new RestaurantContext();

        // GET: MainCourses
        public async Task<ActionResult> Index()
        {
			ViewBag.Title = "Main Course";
			var data = await db.MainCourses.ToListAsync();
			if (User.Identity.IsAuthenticated) return View("MenuItems/AdminIndex", data);
			return View("MenuItems/UserIndex", data);
        }

        // GET: MainCourses/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MainCourse mainCourse = await db.MainCourses.FindAsync(id);
            if (mainCourse == null)
            {
                return HttpNotFound();
            }
            return View("MenuItems/UserDetails", mainCourse);
        }

        // GET: MainCourses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MainCourses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MainCourseId,Name,ThumbNail,FullImage,ShortDesc,FullDesc,Price")] MainCourse mainCourse)
        {
            if (ModelState.IsValid)
            {
                db.MainCourses.Add(mainCourse);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(mainCourse);
        }

        // GET: MainCourses/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MainCourse mainCourse = await db.MainCourses.FindAsync(id);
            if (mainCourse == null)
            {
                return HttpNotFound();
            }
            return View(mainCourse);
        }

        // POST: MainCourses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MainCourseId,Name,ThumbNail,FullImage,ShortDesc,FullDesc,Price")] MainCourse mainCourse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mainCourse).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(mainCourse);
        }

        // GET: MainCourses/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MainCourse mainCourse = await db.MainCourses.FindAsync(id);
            if (mainCourse == null)
            {
                return HttpNotFound();
            }
            return View(mainCourse);
        }

        // POST: MainCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            MainCourse mainCourse = await db.MainCourses.FindAsync(id);
            db.MainCourses.Remove(mainCourse);
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
