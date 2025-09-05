namespace HospitallApp_DBMS.Models
{
    public class Person
    {
        public long PersonId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool doctor { get; set; }
        public bool patient { get; set; }
        public bool nurse { get; set; }


        public ICollection<Doctor> Doctors { get; set; }
        public ICollection<Patient> Patients { get; set; }
        public ICollection<Nurse> Nurses { get; set; }

    }
}