using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BusinessObject.Object
{
    public partial class StudentManagementContext : DbContext
    {
        public StudentManagementContext()
        {
        }

        public StudentManagementContext(DbContextOptions<StudentManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AcademicTranscript> AcademicTranscripts { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<SchoolYear> SchoolYears { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(local);uid=sa;pwd=123456;database=StudentManagement");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AcademicTranscript>(entity =>
            {
                entity.HasKey(e => e.TranscriptId)
                    .HasName("PK__Academic__DF577D86A7F35CFE");

                entity.Property(e => e.TranscriptId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("transcriptID");

                entity.Property(e => e.Average).HasColumnName("average");

                entity.Property(e => e.FinalTest).HasColumnName("finalTest");

                entity.Property(e => e.Semester).HasColumnName("semester");

                entity.Property(e => e.StudentId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("studentID");

                entity.Property(e => e.SubjectId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("subjectID");

                entity.Property(e => e.Test15Min).HasColumnName("test15Min");

                entity.Property(e => e.Test45Min).HasColumnName("test45Min");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.AcademicTranscripts)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK__AcademicT__stude__2E1BDC42");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.AcademicTranscripts)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK__AcademicT__subje__2F10007B");
            });

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Accounts__CB9A1CDFDD85E079");

                entity.Property(e => e.UserId)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("userID");

                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .HasColumnName("name");

                entity.Property(e => e.Role)
                    .HasMaxLength(30)
                    .HasColumnName("role");
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.Property(e => e.ClassId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("classID");

                entity.Property(e => e.ClassName)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("className");

                entity.Property(e => e.SchoolYear)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("schoolYear");

                entity.Property(e => e.StudentId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("studentID");

                entity.Property(e => e.UserId)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("userID");

                entity.HasOne(d => d.SchoolYearNavigation)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.SchoolYear)
                    .HasConstraintName("FK__Classes__schoolY__30F848ED");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK__Classes__student__300424B4");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Classes__userID__31EC6D26");
            });

            modelBuilder.Entity<SchoolYear>(entity =>
            {
                entity.Property(e => e.SchoolYearId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("schoolYearID");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.StudentId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("studentID");

                entity.Property(e => e.Address)
                    .HasMaxLength(250)
                    .HasColumnName("address");

                entity.Property(e => e.Birth)
                    .HasColumnType("date")
                    .HasColumnName("birth");

                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .HasColumnName("name");

                entity.Property(e => e.Proficiency)
                    .HasMaxLength(20)
                    .HasColumnName("proficiency");

                entity.Property(e => e.SchoolYearId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("schoolYearID");

                entity.HasOne(d => d.SchoolYear)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.SchoolYearId)
                    .HasConstraintName("schoolYearID");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.Property(e => e.SubjectId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("subjectID");

                entity.Property(e => e.SubjectName)
                    .HasMaxLength(50)
                    .HasColumnName("subjectName");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
