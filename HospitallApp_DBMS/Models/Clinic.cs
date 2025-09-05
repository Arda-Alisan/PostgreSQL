namespace HospitallApp_DBMS.Models
{
    public class Clinic 
    {
        public long ClinicId { get; set; }
        public string ClinicName { get; set; }

        public ICollection<Doctor> Doctors { get; set; }
        public ICollection<Room> Rooms { get; set; }
    }
}