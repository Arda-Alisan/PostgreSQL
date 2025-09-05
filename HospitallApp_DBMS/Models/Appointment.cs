using System.ComponentModel.DataAnnotations.Schema;

namespace HospitallApp_DBMS.Models
{
    public class Appointment
    {
        public long AppointmentId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Description { get; set; }

        // Foreign Key: Patient
        
        [ForeignKey("PatientPersonId")]
        public long PatientPersonId { get; set; }
        public Patient Patient { get; set; }

        // Foreign Key: Doctor
        [ForeignKey("DoctorPersonId")]
        public long DoctorPersonId { get; set; }
        public Doctor Doctor { get; set; }
    }
}