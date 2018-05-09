using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoctorAppointmentScheduler.Models;

namespace DoctorAppointmentScheduler.Controllers
{
    public class LoginController : Controller
    {
        Schduler m = new Schduler();

        // GET: Login
        public ActionResult Login()
        {
            return View("LoginView");
        }

        [HttpPost]
        public ActionResult Login(Login logindatails)
        {

            if (logindatails.RoleName == Role.Doctor)
            {
                @ViewBag.username = logindatails.UserName;
                this.HttpContext.Session["doctorname"] = logindatails.UserName;
                
                DoctorViewModel dd= new DoctorViewModel();
                dd.DoctorName = logindatails.UserName;
                if (!m.CheckDoctorDetailByID(logindatails.UserName))
                    return View("AddDoctor",dd);
                else
                {
                    return View("../UserManagement/DisplayDoctorDetails", m.getDoctorDetailByID(logindatails.UserName));
                }
            }

            if (logindatails.RoleName == Role.Patient)
            {
                PatientViewModel pp = new PatientViewModel();
                pp.PatientName = logindatails.UserName;
                this.HttpContext.Session["patientname"] = logindatails.UserName;
                if (!m.CheckPatientDetailByID(logindatails.UserName))
                
               
                    return View("AddPatient",pp);
                else
                {
                    return View("../UserManagement/BookingConstraints");
                    // return View("../UserManagement/DoctorAvailability",m.GetAllDcotors());
                }
                return View("AddPatient");
            }
            if (logindatails.RoleName == Role.Adminstator)
            {
               
                return View("../UserManagement/ListAppointments",m.GetAllAppointments());
            }

            return null;
        }

      
    }
}