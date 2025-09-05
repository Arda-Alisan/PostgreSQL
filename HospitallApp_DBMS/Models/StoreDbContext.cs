using Microsoft.EntityFrameworkCore;

namespace HospitallApp_DBMS.Models {
    public class StoreDbContext : DbContext {
        public StoreDbContext(DbContextOptions<StoreDbContext> options): base(options) { }
        
        // public DbSet<Person> Persons => Set<Person>();
        public DbSet<Person> Persons => Set<Person>();
        public DbSet<Patient> Patients => Set<Patient>();
        public DbSet<Doctor> Doctors => Set<Doctor>();
        
        public DbSet<Appointment> Appointments => Set<Appointment>();
        public DbSet<Clinic> Clinics => Set<Clinic>();
        public DbSet<Nurse> Nurses => Set<Nurse>();
        public DbSet<Drug> Drugs => Set<Drug>();
        public DbSet<Prescription> Prescriptions => Set<Prescription>();
        public DbSet<Room> Rooms => Set<Room>();
        public DbSet<PrescriptionDrug> PrescriptionDrugs => Set<PrescriptionDrug>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Composite Primary Key for PrescriptionDrug
            modelBuilder.Entity<PrescriptionDrug>()
                .HasKey(pd => new { pd.prescription, pd.drug });

            // Relationships
            modelBuilder.Entity<PrescriptionDrug>()
                .HasOne(pd => pd.Prescription)
                .WithMany(p => p.PrescriptionDrugs)
                .HasForeignKey(pd => pd.prescription);

            modelBuilder.Entity<PrescriptionDrug>()
                .HasOne(pd => pd.Drug)
                .WithMany(d => d.PrescriptionDrugs)
                .HasForeignKey(pd => pd.drug);

                        // Person ile Patient arasında bire çok ilişki
                modelBuilder.Entity<Patient>()
                .HasOne(d => d.Person) // Doctor bir Person'a bağlı
                .WithMany(p => p.Patients) // Bir Person birden fazla Doctor'a sahip olabilir
                .HasForeignKey(d => d.PersonId) // Foreign Key olarak PersonId kullanılıyor
                .HasConstraintName("FK_Patient_Person_PersonId");


                        // Person ile Doctor arasında bire çok ilişki
            modelBuilder.Entity<Doctor>()
                .HasOne(d => d.Person) // Doctor bir Person'a bağlı
                .WithMany(p => p.Doctors) // Bir Person birden fazla Doctor'a sahip olabilir
                .HasForeignKey(d => d.PersonId) // Foreign Key olarak PersonId kullanılıyor
                .HasConstraintName("FK_Doctor_Person_PersonId"); // Constraint adı belirleniyor


                        // Person ile Nurse arasında bire çok ilişki
            modelBuilder.Entity<Nurse>()
                .HasOne(d => d.Person) // Doctor bir Person'a bağlı
                .WithMany(p => p.Nurses) // Bir Person birden fazla Doctor'a sahip olabilir
                .HasForeignKey(d => d.PersonId) // Foreign Key olarak PersonId kullanılıyor
                .HasConstraintName("FK_Nurse_Person_PersonId"); // Constraint adı belirleniyor
                

                // Doctor ile Clinic arasında bire çok ilişki
            modelBuilder.Entity<Doctor>()
                .HasOne(d => d.Clinic)
                .WithMany(c => c.Doctors) // Bir Clinic, birden fazla Doctor içerebilir
                .HasForeignKey(d => d.ClinicId) // Foreign key olarak ClinicId kullanılıyor
                .HasConstraintName("FK_Doctors_Clinics_ClinicId"); // Constraint adı belirleniyor

        }

    }
}