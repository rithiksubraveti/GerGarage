using System;
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
    [Authorize(Roles = "Admin")]
    public class ManageBookingsController : Controller
    {
        private GerGarageDbEntities db = new GerGarageDbEntities();

        // GET: ManageBookings
        public ActionResult Index(string Sorting_Order, string Search_Data)
        {
            //for filtering records based on few columns
            ViewBag.Jobid = String.IsNullOrEmpty(Sorting_Order) ? "Job_id" : "";
            ViewBag.SortingName = String.IsNullOrEmpty(Sorting_Order) ? "Name_Description" : "";
            ViewBag.SortingStatus = String.IsNullOrEmpty(Sorting_Order) ? "Status_Description" : "";
            ViewBag.CarModel = String.IsNullOrEmpty(Sorting_Order) ? "Car_Model" : "";
            ViewBag.SortingDate = Sorting_Order == "Service_Date" ? "Date_Description" : "Date";
            //var jobCardDetails = from jd in db.JobCardDetails select jd;
            var jobCardDetails = from jd in db.JobDetails select jd;
            {
                if (!String.IsNullOrEmpty(Search_Data))
                {
                    jobCardDetails = jobCardDetails.Where(jd => jd.CustomerName.Contains(Search_Data));
                }
            }
            switch (Sorting_Order)
            {
                case "Job_id":
                    jobCardDetails = jobCardDetails.OrderBy(jd => jd.JobNumber);
                    break;
                case "Service_Date":
                    jobCardDetails = jobCardDetails.OrderBy(jd => jd.ServiceDate);
                    break;
                case "Date_Description":
                    jobCardDetails = jobCardDetails.OrderByDescending(jd => jd.ServiceDate);
                    break;
                case "Status_Description":
                    jobCardDetails = jobCardDetails.OrderBy(jd => jd.JobStatus);
                    break;
                case "Car_Model":
                    jobCardDetails = jobCardDetails.OrderBy(jd => jd.CarMake);
                    break;
                default:
                    jobCardDetails = jobCardDetails.OrderBy(jd => jd.ServiceDate);
                    break;
            }
            return View(jobCardDetails.ToList());

        }

        // GET: ManageBookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobDetail jobCardDetail = db.JobDetails.Find(id);
            if (jobCardDetail == null)
            {
                return HttpNotFound();
            }
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
            JobDetail jobCardDetail = db.JobDetails.Find(id);
            if (jobCardDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookingId = new SelectList(db.CustomersBookings, "BookingId", "CustomerName", jobCardDetail.BookingId);
            return View(jobCardDetail);
        }

        // POST: ManageBookings/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JobNumber,BookingId,ServiceDate,CustomerName,CarMake,CarModel,ServiceType,Rate,MechanicAssigned,JobStatus")] JobDetail jobCardDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobCardDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookingId = new SelectList(db.CustomersBookings, "BookingId", "CustomerName", jobCardDetail.BookingId);
            return View(jobCardDetail);
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
                JobDetail jd = db.JobDetails.FirstOrDefault(c => c.JobNumber == id);

                var report = new PartialViewAsPdf("~/Views/Shared/Invoice.cshtml", jd);
                return report;
            }

        }
    }
}
