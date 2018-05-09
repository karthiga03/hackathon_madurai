using DoctorAppointmentScheduler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoctorAppointmentScheduler.Controllers
{
    public class UserManagementController : Controller
    {
        Schduler m = new Schduler();
        // GET: UserManagement
        [HttpPost]
        public ActionResult AddDoctor(DoctorViewModel details)
        {
            details.DoctorName = this.HttpContext.Session["doctorname"].ToString();
          
            m.addDoctor(details);
            return View("DisplayDoctorDetails", m.getDoctorDetailByID(details.DoctorName));
        }
        [HttpPost]
        public ActionResult AddPatient(PatientViewModel details)
        {
            details.PatientName = this.HttpContext.Session["patientname"].ToString();
            m.addPatient(details);

            return View("BookingConstraints");
           // return View("../UserManagement/DoctorAvailability",m.GetAllDcotors());
        }

        public ActionResult BookAppointment(string id)
        {
            AppointmentDetail a= new AppointmentDetail();
            a.DoctorID = id;
            a.PatientID =  this.HttpContext.Session["patientname"].ToString();
            a.StartTime=DateTime.Now;
            a.EndTime = DateTime.Now.AddMinutes(30);
            m.createAppointment(a);
         //   return "Appointment created successfully";
            return View("ListAppointments",m.GetAllAppointments());
        }

        public ActionResult ListAppointments()
        {
            return View();
        }
        public ActionResult BookingConstraints()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult BookingConstraints(BookingConstraints bb)
        {
            IEnumerable<DoctorDetail> dd = m.GetAllDcotors();
            List<DoctorDetail> docs = dd.Where(n => n.Specaility == bb.speciality.ToString() && n.IsAvailable=="yes").ToList();
            return View("DoctorAvailability",docs);
        }
    }
}