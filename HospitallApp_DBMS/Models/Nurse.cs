using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitallApp_DBMS.Models
{
    public class Nurse
    {
    [Key]
    public long PersonId { get; set; }
    public long DoctorPersonId { get; set; }

    // Navigation Properties
    public Person Person { get; set; }
    public Doctor Doctor { get; set; }
    }
}