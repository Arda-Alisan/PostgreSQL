using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitallApp_DBMS.Models
{
    public class Patient
    {
            [Key]
            public long PersonId { get; set; }

            public string MedicalHistory { get; set; }


            // Navigation Prop
            public ICollection<Appointment> Appointments { get; set; }

            public Person Person { get; set; }
    }
}