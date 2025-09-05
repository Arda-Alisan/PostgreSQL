namespace HospitallApp_DBMS.Models
{
    public class PrescriptionDrug
    {
        // PK FK
        public long prescription { get; set; }
        public long drug { get; set; }
        

        public Prescription Prescription { get; set; }
        public Drug Drug { get; set; }

    }
}