using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BusinessObject.Object
{
    public partial class studentmanagementContext : DbContext
    {
        public studentmanagementContext()
        {
        }

        public studentmanagementContext(DbContextOptions<studentmanagementContext> options)
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
                optionsBuilder.UseSqlServer("server=(local);uid=sa;pwd=1234;database=studentmanagement");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AcademicTranscript>(entity =>
            {
                entity.HasKey(e => e.TranscriptId)
                    .HasName("PK__Academic__DF577D863E96E56F");

                entity.Property(e => e.TranscriptId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("transcriptID");

                entity.Property(e => e.Average).HasColumnName("average");

                entity.Property(e => e.FinalTest).HasColumnName("finalTest");

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
                    .HasConstraintName("FK__AcademicT__stude__59FA5E80");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.AcademicTranscripts)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK__AcademicT__subje__5AEE82B9");
            });

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Accounts__CB9A1CDF152CCCF7");

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
                    .HasConstraintName("FK__Classes__schoolY__38996AB5");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK__Classes__schoolY__36B12243");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Classes__userID__37A5467C");
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
