using System.ComponentModel.DataAnnotations.Schema;

namespace HospitallApp_DBMS.Models
{
    public class Prescription
    {
        // PK
        public long PrescriptionId { get; set; }
        
        // FK
        [ForeignKey("DoctorPersonId")]
        
        public long DoctorPersonId { get; set; }

        [ForeignKey("PatientPersonId")]
        public long PatientPersonId { get; set; }

        // Navigate Properties
        public Doctor Doctor { get; set; }

        public Patient Patient { get; set; }

        // Many-to-Many Relationship
        public ICollection<PrescriptionDrug> PrescriptionDrugs { get; set; }


    }
}