using Microsoft.EntityFrameworkCore;
using P01_HospitalDatabase.Data.Models;

namespace P01_HospitalDatabase.Data
{
    public class HospitalContext : DbContext
    {

        public HospitalContext()
        {
        }

        public HospitalContext(DbContextOptions options)
            :base(options)
        {

        }

        DbSet<Diagnose> Diagnoses { get; set; }
        DbSet<Medicament> Medicaments { get; set; }
        DbSet<Patient> Patients { get; set; }
        DbSet<PatientMedicament> PatientsMedicaments { get; set; }
        DbSet<Visitation> Visitations { get; set; }

        DbSet<Doctor> Doctors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Patient>(patient =>
                {
                    patient.HasKey(p => p.PatientId);

                    patient.Property(p => p.FirstName)
                    .IsRequired(true)
                    .HasMaxLength(50)
                    .IsUnicode(true);

                    patient.Property(p => p.LastName)
                    .IsRequired(true)
                    .HasMaxLength(50)
                    .IsUnicode(true);

                    patient.Property(p => p.Address)
                    .IsRequired(true)
                    .HasMaxLength(250)
                    .IsUnicode(true);

                    patient.Property(p => p.Email)
                    .IsRequired(true)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                    patient.Property(p => p.HasInsurance)
                    .IsRequired(true);

                });

            modelBuilder
                .Entity<Visitation>(visitation =>
                {
                    visitation.HasKey(v => v.VisitationId);

                    visitation.Property(v => v.Date)
                    .IsRequired(true);

                    visitation.Property(v => v.Comments)
                    .IsRequired(true)
                    .HasMaxLength(250)
                    .IsUnicode(true);

                    visitation.HasOne(v => v.Patient)
                    .WithMany(p => p.Visitations)
                    .HasForeignKey(v => v.PatientId);

                    visitation.HasOne(v => v.Doctor)
                    .WithMany(d => d.Visitations)
                    .HasForeignKey(v => v.DoctorId);
                });

            modelBuilder
                .Entity<Diagnose>(diagnose =>
                {
                    diagnose.HasKey(d => d.DiagnoseId);

                    diagnose.Property(d => d.Name)
                    .IsRequired(true)
                    .HasMaxLength(50)
                    .IsUnicode(true);

                    diagnose.Property(d => d.Comments)
                    .IsRequired(true)
                    .HasMaxLength(250)
                    .IsUnicode(true);

                    diagnose.HasOne(d => d.Patient)
                    .WithMany(p => p.Diagnoses)
                    .HasForeignKey(d => d.PatientId);
                });

            modelBuilder
                .Entity<Medicament>(medicament => 
                {
                    medicament.HasKey(m => m.MedicamentId);

                    medicament.Property(m => m.Name)
                    .IsRequired(true)
                    .HasMaxLength(50)
                    .IsUnicode(true);
                });

            modelBuilder
                .Entity<PatientMedicament>(patientMedicament => 
                {
                    patientMedicament.HasKey(pm => new { pm.PatientId, pm.MedicamentId });

                    patientMedicament.HasOne(pm => pm.Patient)
                    .WithMany(p => p.Prescriptions)
                    .HasForeignKey(pm => pm.PatientId);

                    patientMedicament.HasOne(pm => pm.Medicament)
                    .WithMany(m => m.Prescriptions)
                    .HasForeignKey(pm => pm.MedicamentId);
                });

            modelBuilder
                .Entity<Doctor>(doctor => 
                {
                    doctor.HasKey(d => d.DoctorId);

                    doctor.Property(d => d.Name)
                    .IsRequired(true)
                    .HasMaxLength(100)
                    .IsUnicode(true);

                    doctor.Property(d => d.Specialty)
                    .IsRequired(true)
                    .HasMaxLength(100)
                    .IsUnicode(true);
                });
        }
    }
}
