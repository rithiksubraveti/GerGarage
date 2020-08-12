using GerGarage.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GerGarage.Controllers
{
    public class UserController : Controller
    {
     

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(RegisteredUser regUser)
        {
            using (var context = new GerGarageDbEntities())
            {
                bool isValid = context.CustomerLogins.Any(x => x.CustomerEmailId == regUser.CustomerEmailId && x.CustomerPassword == regUser.CustomerPassword);
                if (isValid)
                {
                    FormsAuthentication.SetAuthCookie(regUser.CustomerEmailId, false);
                    return RedirectToAction("Index", "Home");

                }
                ModelState.AddModelError("", "Invalid Credentials!!!!");
            }
            return View();
        }
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(UserRegisterView regUser)
        {
            using (GerGarageDbEntities db = new GerGarageDbEntities())
            {
                CustomerRegistry user = new CustomerRegistry();

                user.CustomerFirstName = regUser.CustomerFirstName;
                user.CustomerLastName = regUser.CustomerLastName;
                user.CustomerContact = regUser.CustomerContact;
                user.CustomerEmailId = regUser.CustomerEmailId;
                user.CustomerPassword = regUser.CustomerPassword;
                user.CustomerAddress = regUser.CustomerAddress;
                user.CustomerPostalCode = regUser.CustomerPostalCode;

                CustomerLogin logUser = new CustomerLogin();
                logUser.CustomerEmailId = regUser.CustomerEmailId;
                logUser.CustomerPassword = regUser.CustomerPassword;
                if (ModelState.IsValid)
                {
                    db.CustomerRegistries.Add(user);
                    db.CustomerLogins.Add(logUser);
                    db.SaveChanges();

                    return RedirectToAction("Login");
                }
                return View();

            }

        }
        /*The following code is to fetch data from the Vehicle Type DB and populate them in the Drop Down List*/
        public List<VehicleMake> GetVehicleMakes()
        {
            GerGarageDbEntities db = new GerGarageDbEntities();
            List<VehicleMake> vehicleMakes = db.VehicleMakes.ToList();
            return vehicleMakes;

        }
        public List<ServicesAvailable> GetServicesAvailables()
        {
            GerGarageDbEntities db = new GerGarageDbEntities();
            List<ServicesAvailable> servicesAvailables = db.ServicesAvailables.ToList();
            return servicesAvailables;

        }
        [Authorize]
        public ActionResult Booking()
        {
            
                GerGarageDbEntities db = new GerGarageDbEntities();

                ViewBag.VehicleList = new SelectList(db.VehicleMakes, "VehicleBrand", "VehicleBrand");
                ViewBag.ServiceList = new SelectList(db.ServicesAvailables, "ServiceName", "ServiceName");
                
            return View();
        }
        [HttpPost]
        public ActionResult Booking(CustomerAppointment custBooking)
        {
            using (GerGarageDbEntities db = new GerGarageDbEntities())
            {


                /*CustomerBooking booking = new CustomerBooking();

                 JobCardDetail jobCard = new JobCardDetail();

                 jobCard.BookingId = custBooking.BookingId;
                 booking.BookingDate = custBooking.BookingDate;
                 booking.CustomerName = custBooking.CustomerName;
                 jobCard.CustomerName = custBooking.CustomerName;
                 booking.CustomerEmail = custBooking.CustomerEmail;
                 booking.VehicleMake = custBooking.VehicleMake;
                 jobCard.CarMake = custBooking.VehicleMake;
                 booking.VehicleModel = custBooking.VehicleModel;
                 jobCard.CarModel = custBooking.VehicleModel;
                 booking.ServiceType = custBooking.ServiceType;
                 jobCard.ServiceType = custBooking.ServiceType;
                 booking.ServiceDate = custBooking.ServiceDate;
                 jobCard.ServiceDate = custBooking.ServiceDate;
                 booking.Remarks = custBooking.Remarks;
                 jobCard.CustomerMessage = custBooking.Remarks;

                 db.CustomerBookings.Add(booking);
                 db.JobCardDetails.Add(jobCard);*/


                CustomersBooking booking = new CustomersBooking();

                JobDetail jobCard = new JobDetail();

                jobCard.BookingId = custBooking.BookingId;
                booking.BookingDate = custBooking.BookingDate;
                booking.CustomerName = custBooking.CustomerName;
                jobCard.CustomerName = custBooking.CustomerName;
                booking.CustomerEmail = custBooking.CustomerEmail;
                booking.VehicleMake = custBooking.VehicleMake;
                jobCard.CarMake = custBooking.VehicleMake;
                booking.VehicleModel = custBooking.VehicleModel;
                jobCard.CarModel = custBooking.VehicleModel;
                booking.VehicleNumber = custBooking.VehicleNumber;
                jobCard.CarNumber = custBooking.VehicleNumber;
                booking.VehicleFuelType = custBooking.VehicleFuelType;
                booking.ServiceType = custBooking.ServiceType;
                jobCard.ServiceType = custBooking.ServiceType;
                booking.ServiceDate = custBooking.ServiceDate;
                jobCard.ServiceDate = custBooking.ServiceDate;
                booking.Remarks = custBooking.Remarks;
                jobCard.CustomerMessage = custBooking.Remarks;

                db.CustomersBookings.Add(booking);
                db.JobDetails.Add(jobCard);
                db.SaveChanges();
            }

            ViewData["Confirmed"] = "Your Booking was succesfull";
            return RedirectToAction("Booking");
        
    }

    public ActionResult Logout()
    {
        FormsAuthentication.SignOut();
        return RedirectToAction("Index", "Home", new { area = "" });
    }





    }
}