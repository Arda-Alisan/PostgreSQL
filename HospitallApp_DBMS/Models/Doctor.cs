using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HospitallApp_DBMS.Models
{
    public class Doctor
{
    [Key]
    public long PersonId { get; set; } // Hem primary key hem foreign key

    public string Specialty { get; set; }

    public long ClinicId { get; set; } // Foreign key, navigation property ile bağlanıyor

    // Navigation Properties
    public Clinic Clinic { get; set; }
    public Person Person { get; set; }

    public ICollection<Appointment> Appointments { get; set; }
}
}