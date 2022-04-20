using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace CRUD_Hospital.Model
{
    public partial class dbhospitalsContext : DbContext
    {
        public dbhospitalsContext()
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<Disease> Diseases { get; set; } = null!;
        public virtual DbSet<Doctor> Doctors { get; set; } = null!;
        public virtual DbSet<Hospital> Hospitals { get; set; } = null!;
        public virtual DbSet<Medicalhistory> Medicalhistories { get; set; } = null!;
        public virtual DbSet<Medication> Medications { get; set; } = null!;
        public virtual DbSet<Patient> Patients { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;
        public virtual DbSet<Treatment> Treatments { get; set; } = null!;
        public virtual DbSet<Visit> Visits { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("config.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("departments");

                entity.Property(e => e.DepartmentId).HasColumnName("department_id");

                entity.Property(e => e.DName).HasColumnName("d_name");

                entity.Property(e => e.HospitalId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("hospital_id");

                entity.HasOne(d => d.Hospital)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.HospitalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("departments_hospital_id_fkey");
            });

            modelBuilder.Entity<Disease>(entity =>
            {
                entity.ToTable("diseases");

                entity.Property(e => e.DiseaseId).HasColumnName("disease_id");

                entity.Property(e => e.DName).HasColumnName("d_name");

                entity.Property(e => e.MedicalhistiryId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("medicalhistiry_id");

                entity.HasOne(d => d.Medicalhistiry)
                    .WithMany(p => p.Diseases)
                    .HasForeignKey(d => d.MedicalhistiryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("diseases_medicalhistiry_id_fkey");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.ToTable("doctors");

                entity.Property(e => e.DoctorId).HasColumnName("doctor_id");

                entity.Property(e => e.DFisrtname).HasColumnName("d_fisrtname");

                entity.Property(e => e.DJobtitle).HasColumnName("d_jobtitle");

                entity.Property(e => e.DLastname).HasColumnName("d_lastname");

                entity.Property(e => e.DPhone).HasColumnName("d_phone");

                entity.Property(e => e.DSecondname).HasColumnName("d_secondname");

                entity.Property(e => e.DepartmentId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("department_id");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("doctors_department_id_fkey");
            });

            modelBuilder.Entity<Hospital>(entity =>
            {
                entity.ToTable("hospitals");

                entity.Property(e => e.HospitalId).HasColumnName("hospital_id");

                entity.Property(e => e.HAddress).HasColumnName("h_address");

                entity.Property(e => e.HCity).HasColumnName("h_city");

                entity.Property(e => e.HName).HasColumnName("h_name");
            });

            modelBuilder.Entity<Medicalhistory>(entity =>
            {
                entity.ToTable("medicalhistories");

                entity.Property(e => e.MedicalhistoryId).HasColumnName("medicalhistory_id");

                entity.Property(e => e.PatientId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("patient_id");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Medicalhistories)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("medicalhistories_patient_id_fkey");
            });

            modelBuilder.Entity<Medication>(entity =>
            {
                entity.ToTable("medications");

                entity.Property(e => e.MedicationId).HasColumnName("medication_id");

                entity.Property(e => e.MName).HasColumnName("m_name");

                entity.Property(e => e.TreatmentId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("treatment_id");

                entity.HasOne(d => d.Treatment)
                    .WithMany(p => p.Medications)
                    .HasForeignKey(d => d.TreatmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("medications_treatment_id_fkey");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.ToTable("patients");

                entity.Property(e => e.PatientId).HasColumnName("patient_id");

                entity.Property(e => e.HospitalId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("hospital_id");

                entity.Property(e => e.PFirstname).HasColumnName("p_firstname");

                entity.Property(e => e.PLastname).HasColumnName("p_lastname");

                entity.Property(e => e.PPhone).HasColumnName("p_phone");

                entity.Property(e => e.PSecondname).HasColumnName("p_secondname");

                entity.HasOne(d => d.Hospital)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.HospitalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("patients_hospital_id_fkey");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.HasKey(e => e.ServicedId)
                    .HasName("services_pkey");

                entity.ToTable("services");

                entity.Property(e => e.ServicedId).HasColumnName("serviced_id");

                entity.Property(e => e.SName).HasColumnName("s_name");

                entity.Property(e => e.SPrice).HasColumnName("s_price");

                entity.Property(e => e.TreatmentId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("treatment_id");

                entity.HasOne(d => d.Treatment)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.TreatmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("services_treatment_id_fkey");
            });

            modelBuilder.Entity<Treatment>(entity =>
            {
                entity.ToTable("treatments");

                entity.HasIndex(e => e.VisitId, "treatments_visit_id_key")
                    .IsUnique();

                entity.Property(e => e.TreatmentId).HasColumnName("treatment_id");

                entity.Property(e => e.Countdays).HasColumnName("countdays");

                entity.Property(e => e.VisitId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("visit_id");

                entity.HasOne(d => d.Visit)
                    .WithOne(p => p.Treatment)
                    .HasForeignKey<Treatment>(d => d.VisitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("treatments_visit_id_fkey");
            });

            modelBuilder.Entity<Visit>(entity =>
            {
                entity.ToTable("visits");

                entity.Property(e => e.VisitId).HasColumnName("visit_id");

                entity.Property(e => e.DoctorId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("doctor_id");

                entity.Property(e => e.PatientId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("patient_id");

                entity.Property(e => e.VDate).HasColumnName("v_date");

                entity.Property(e => e.VTine).HasColumnName("v_tine");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Visits)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("visits_doctor_id_fkey");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Visits)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("visits_patient_id_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
