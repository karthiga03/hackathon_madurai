using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorAppointmentScheduler.Models
{
    public class PatientViewModel
    {
        public string PatientID { get; set; }
        public string PatientName { get; set; }
        public Nullable<int> Age { get; set; }
        public Gender Gender { get; set; }
        public string HealthConditions { get; set; }
    }

    public enum Gender
    {
        F,M
    }
}