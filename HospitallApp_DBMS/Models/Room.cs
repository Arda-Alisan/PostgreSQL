using System.ComponentModel.DataAnnotations.Schema;

namespace HospitallApp_DBMS.Models
{
    public class Room
    {
        // PK
        public long RoomId { get; set; }

        public string RoomName { get; set; }
        
        // FK
        [ForeignKey("DoctorPersonId")]
        
        public long DoctorPersonId { get; set; }
        
        [ForeignKey("ClinicId")]
        public long ClinicId { get; set; }

        // Navigate Properties
        public Doctor Doctor { get; set; }

        public Clinic Clinic { get; set; }


    }
}