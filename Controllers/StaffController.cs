using GerGarage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GerGarage.Controllers
{
    public class StaffController : Controller
    {
        
        // GET: Staff
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(RegisteredEmployee regEmp)
        {
            using (var context = new GerGarageDbEntities())
            {
                bool isValid = context.EmployeeLogins.Any(x => x.EmployeeEmailId == regEmp.EmployeeEmailId && x.EmployeePassword == regEmp.EmployeePassword);
                if (isValid)
                {
                    FormsAuthentication.SetAuthCookie(regEmp.EmployeeEmailId, false);
                    return RedirectToAction("Index", "Home");

                }
                ModelState.AddModelError("", "Invalid Employee Credentials!!!!");
            }
            return View();
        }
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(EmployeeRegisterView regEmp)
        {
            using (GerGarageDbEntities db = new GerGarageDbEntities())
            {
                EmployeeRegistry emp = new EmployeeRegistry();

                emp.EmployeeFirstName = regEmp.EmployeeFirstName;
                emp.EmployeeLastName = regEmp.EmployeeLastName;
                emp.EmployeeContact = regEmp.EmployeeContact;
                emp.EmployeeEmailId = regEmp.EmployeeEmailId;
                emp.EmployeePassword = regEmp.EmployeePassword;
                db.EmployeeRegistries.Add(emp);
                db.SaveChanges();

                EmployeeLogin logEmp = new EmployeeLogin();
                logEmp.EmployeeEmailId = regEmp.EmployeeEmailId;
                logEmp.EmployeePassword = regEmp.EmployeePassword;
                db.EmployeeLogins.Add(logEmp);
                db.SaveChanges();


            } 
            return RedirectToAction("Login");

        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home", new { area = "" });
        }

    }
    }
