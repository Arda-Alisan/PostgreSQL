namespace HospitallApp_DBMS.Models
{
    public class Drug 
    {
        // PK
        public long DrugId { get; set; }


        public string DrugName { get; set; }
        public string DrugType { get; set; }

        // Many-to-Many Relationship
        public ICollection<PrescriptionDrug> PrescriptionDrugs { get; set; }
        
    }
}