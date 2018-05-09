using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorAppointmentScheduler.Models
{
    public class DoctorViewModel
    {
        public string DoctorID { get; set; }
        public string DoctorName { get; set; }
        public DoctorSpecialization Specaility { get; set; }
       public bool isAvailable { get; set; }
    }
    
}