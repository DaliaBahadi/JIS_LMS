using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace JIS_LMS.Model
{
    public partial class LMSDbContext : DbContext
    {
        public LMSDbContext()
        {
        }

        public LMSDbContext(DbContextOptions<LMSDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Author> Author { get; set; }
        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<Borrowing> Borrowing { get; set; }
        public virtual DbSet<CD_DVD_BR> CD_DVD_BR { get; set; }
        public virtual DbSet<Donor> Donor { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Hold> Hold { get; set; }
        public virtual DbSet<Journal> Journal { get; set; }
        public virtual DbSet<Library> Library { get; set; }
        public virtual DbSet<LibraryMaterial_Author> LibraryMaterial_Author { get; set; }
        public virtual DbSet<Library_Material> Library_Material { get; set; }
        public virtual DbSet<List_Borrowing> List_Borrowing { get; set; }
        public virtual DbSet<List_Donor> List_Donor { get; set; }
        public virtual DbSet<List_Hold> List_Hold { get; set; }
        public virtual DbSet<List_Library> List_Librarie { get; set; }
        public virtual DbSet<List_Parent> List_Parent { get; set; }
        public virtual DbSet<List_Student> List_Student { get; set; }
        public virtual DbSet<List_Teacher> List_Teacher { get; set; }
        public virtual DbSet<Notification> Notification { get; set; }
        public virtual DbSet<Parent> Parent { get; set; }
        public virtual DbSet<Patron> Patron { get; set; }
        public virtual DbSet<Publisher> Publisher { get; set; }
        public virtual DbSet<Schedule> Schedule { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Student_Parent> Student_Parent { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }
        public virtual DbSet<Time_Slot> Time_Slot { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-O2J4161;Database=LibraryManagementSystem;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(e => e.LibraryMaterialId).ValueGeneratedOnAdd();

                entity.Property(e => e.BookType).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.LibraryMaterial)
                    .WithOne(p => p.Book)
                    .HasForeignKey<Book>(d => d.LibraryMaterialId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Book_LibraryMaterial");
            });

            modelBuilder.Entity<Borrowing>(entity =>
            {
                entity.HasOne(d => d.LibraryMaterial)
                    .WithMany(p => p.Borrowings)
                    .HasForeignKey(d => d.LibraryMaterialId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Borrowing_LibraryMaterial");

                entity.HasOne(d => d.Patron)
                    .WithMany(p => p.Borrowings)
                    .HasForeignKey(d => d.PatronId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Borrowing_Patron");
            });

            modelBuilder.Entity<CD_DVD_BR>(entity =>
            {
                entity.Property(e => e.LibraryMaterialId).ValueGeneratedOnAdd();

                entity.Property(e => e.Type).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.LibraryMaterial)
                    .WithOne(p => p.CD_DVD_BR)
                    .HasForeignKey<CD_DVD_BR>(d => d.LibraryMaterialId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CD_DVD_BR_LibraryMaterial");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Language).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Hold>(entity =>
            {
                entity.HasOne(d => d.LibraryMaterial)
                    .WithMany(p => p.Holds)
                    .HasForeignKey(d => d.LibraryMaterialId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Hold_LibraryMaterial");

                entity.HasOne(d => d.Patron)
                    .WithMany(p => p.Holds)
                    .HasForeignKey(d => d.PatronId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Hold_Patron");
            });

            modelBuilder.Entity<Journal>(entity =>
            {
                entity.Property(e => e.LibraryMaterialId).ValueGeneratedOnAdd();

                entity.Property(e => e.JournalType).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.LibraryMaterial)
                    .WithOne(p => p.Journal)
                    .HasForeignKey<Journal>(d => d.LibraryMaterialId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Journal_LibraryMaterial");
            });

            modelBuilder.Entity<Library>(entity =>
            {
                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Libraries)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Library_Address");

                entity.HasOne(d => d.Librarian)
                    .WithMany(p => p.Libraries)
                    .HasForeignKey(d => d.LibrarianId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Library_Librarian");
            });

            modelBuilder.Entity<LibraryMaterial_Author>(entity =>
            {
                entity.HasKey(e => new { e.LibraryMaterialId, e.AuthorId });

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.LibraryMaterial_Authors)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LibraryMaterial_Author_Author");

                entity.HasOne(d => d.LibraryMaterial)
                    .WithMany(p => p.LibraryMaterial_Authors)
                    .HasForeignKey(d => d.LibraryMaterialId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LibraryMaterial_Author_LibraryMaterial");
            });

            modelBuilder.Entity<Library_Material>(entity =>
            {
                entity.HasKey(e => e.LibraryMaterialId)
                    .HasName("PK_LibraryMaterial");

                entity.Property(e => e.Language).HasDefaultValueSql("((1))");

                entity.Property(e => e.LibraryMaterialType).HasDefaultValueSql("((1))");

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Donor)
                    .WithMany(p => p.Library_Materials)
                    .HasForeignKey(d => d.DonorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LibraryMaterial_Donor");

                entity.HasOne(d => d.Library)
                    .WithMany(p => p.Library_Materials)
                    .HasForeignKey(d => d.LibraryId)
                    .HasConstraintName("FK_LibraryMaterial_Library");

                entity.HasOne(d => d.Publisher)
                    .WithMany(p => p.Library_Materials)
                    .HasForeignKey(d => d.PublisherId)
                    .HasConstraintName("FK_LibraryMaterial_Publisher");
            });

            modelBuilder.Entity<List_Borrowing>(entity =>
            {
                entity.ToView("List_Borrowing");
            });

            modelBuilder.Entity<List_Donor>(entity =>
            {
                entity.ToView("List_Donor");
            });

            modelBuilder.Entity<List_Hold>(entity =>
            {
                entity.ToView("List_Hold");
            });

            modelBuilder.Entity<List_Library>(entity =>
            {
                entity.ToView("List_Library");
            });

            modelBuilder.Entity<List_Parent>(entity =>
            {
                entity.ToView("List_Parent");
            });

            modelBuilder.Entity<List_Student>(entity =>
            {
                entity.ToView("List_Student");
            });

            modelBuilder.Entity<List_Teacher>(entity =>
            {
                entity.ToView("List_Teacher");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.HasOne(d => d.Librarian)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.LibrarianId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Notification_Librarian");

                entity.HasOne(d => d.Patron)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.PatronId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Notification_Patron");

                entity.HasOne(d => d.TimeSlot)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.TimeSlotId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Notification_Time_Slot");
            });

            modelBuilder.Entity<Parent>(entity =>
            {
                entity.Property(e => e.Language).HasDefaultValueSql("((2))");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Parents)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Parent_Address");
            });

            modelBuilder.Entity<Patron>(entity =>
            {
                entity.Property(e => e.Language).HasDefaultValueSql("((1))");

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Patrons)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Patron_Address");

                entity.HasOne(d => d.Library)
                    .WithMany(p => p.Patrons)
                    .HasForeignKey(d => d.LibraryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Patron_Library");
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.HasOne(d => d.Patron)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.PatronId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Schedule_Patron");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.PatronId).ValueGeneratedNever();

                entity.HasOne(d => d.Patron)
                    .WithOne(p => p.Student)
                    .HasForeignKey<Student>(d => d.PatronId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Student_Patron");
            });

            modelBuilder.Entity<Student_Parent>(entity =>
            {
                entity.HasKey(e => new { e.PatronId, e.ParentId });

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.Student_Parents)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Student_Parent_Parent");

                entity.HasOne(d => d.Patron)
                    .WithMany(p => p.Student_Parents)
                    .HasForeignKey(d => d.PatronId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Student_Parent_Student");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.Property(e => e.PatronId).ValueGeneratedNever();

                entity.HasOne(d => d.Patron)
                    .WithOne(p => p.Teacher)
                    .HasForeignKey<Teacher>(d => d.PatronId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Teacher_Patron");
            });

            modelBuilder.Entity<Time_Slot>(entity =>
            {
                entity.HasOne(d => d.Library)
                    .WithMany(p => p.Time_Slots)
                    .HasForeignKey(d => d.LibraryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Time_Slot_Library");

                entity.HasOne(d => d.Schedule)
                    .WithMany(p => p.Time_Slots)
                    .HasForeignKey(d => d.ScheduleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Time_Slot_Schedule");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
