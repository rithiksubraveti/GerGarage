﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GerGarage.Models;
using Rotativa;

namespace GerGarage.Controllers
{
    public class ManageBookingsController : Controller
    {
        private GerGarageDbEntities db = new GerGarageDbEntities();

        // GET: ManageBookings
        public ActionResult Index()
        {
            var jobCardDetails = db.JobCardDetails.Include(j => j.CustomerBooking);
            return View(jobCardDetails.ToList());
        }

        // GET: ManageBookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobCardDetail jobCardDetail = db.JobCardDetails.Find(id);
            if (jobCardDetail == null)
            {
                return HttpNotFound();
            }
            return View(jobCardDetail);
        }

        // GET: ManageBookings/Create
        public ActionResult Create()
        {
            ViewBag.BookingId = new SelectList(db.CustomerBookings, "BookingId", "CustomerName");
            return View();
        }

        // POST: ManageBookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "JobNumber,BookingId,ServiceDate,CustomerName,CarMake,CarModel,ServiceType,Rate,MechanicAssigned,JobStatus")] JobCardDetail jobCardDetail)
        {
            if (ModelState.IsValid)
            {
                db.JobCardDetails.Add(jobCardDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BookingId = new SelectList(db.CustomerBookings, "BookingId", "CustomerName", jobCardDetail.BookingId);
            return View(jobCardDetail);
        }
        public List<EmployeeRegistry> GetEmployees()
        {
            GerGarageDbEntities db = new GerGarageDbEntities();
            List<EmployeeRegistry> employeeRegistries = db.EmployeeRegistries.ToList();
            return employeeRegistries;

        }
        public List<BookingStatusTable> GetStatusTables()
        {
            GerGarageDbEntities db = new GerGarageDbEntities();
            List<BookingStatusTable> bookingStatus = db.BookingStatusTables.ToList();
            return bookingStatus;

        }

        // GET: ManageBookings/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.EmployeeList = new SelectList(GetEmployees(), "EmployeeFirstName", "EmployeeFirstName");
            ViewBag.StatusList = new SelectList(GetStatusTables(), "BookingStatus", "BookingStatus");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobCardDetail jobCardDetail = db.JobCardDetails.Find(id);
            if (jobCardDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookingId = new SelectList(db.CustomerBookings, "BookingId", "CustomerName", jobCardDetail.BookingId);
            return View(jobCardDetail);
        }

        // POST: ManageBookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JobNumber,BookingId,ServiceDate,CustomerName,CarMake,CarModel,ServiceType,Rate,MechanicAssigned,JobStatus")] JobCardDetail jobCardDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobCardDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookingId = new SelectList(db.CustomerBookings, "BookingId", "CustomerName", jobCardDetail.BookingId);
            return View(jobCardDetail);
        }

        // GET: ManageBookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobCardDetail jobCardDetail = db.JobCardDetails.Find(id);
            if (jobCardDetail == null)
            {
                return HttpNotFound();
            }
            return View(jobCardDetail);
        }

        // POST: ManageBookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JobCardDetail jobCardDetail = db.JobCardDetails.Find(id);
            db.JobCardDetails.Remove(jobCardDetail);
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
        public ActionResult GenerateInvoice(int id)
        {
            using (GerGarageDbEntities db = new GerGarageDbEntities())
            {
                JobCardDetail jd = db.JobCardDetails.FirstOrDefault(c => c.JobNumber == id);

                var report = new PartialViewAsPdf("~/Views/Shared/Invoice.cshtml", jd);
                return report;
            }

        }
    }
}
