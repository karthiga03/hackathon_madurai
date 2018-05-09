using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorAppointmentScheduler.Models
{
    public class BookingConstraints
    {
        public DoctorSpecialization speciality { get; set; }
        public DateTime appointmentDate { get; set; }
       
    }
}