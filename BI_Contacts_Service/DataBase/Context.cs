using BI_Contacts_Service.Models;
using Microsoft.EntityFrameworkCore;

namespace BI_Contacts_Service.DataBase
{
    public class Context:DbContext
    {
        public Context(){}
        public Context(DbContextOptions<Context> options) : base(options){}

        public virtual DbSet<ContactTypes> ContactTypes { get; set; }
        public virtual DbSet<CustomerContacts> CustomerContacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactTypes>(entity =>
            {
                entity.HasKey(e => e.Type);

                entity.Property(e => e.Type).ValueGeneratedNever();
                entity.Property(e => e.ArabicDescription).HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(100);
            });
            modelBuilder.Entity<CustomerContacts>(entity =>
            {
                entity.HasKey(e => e.ContactID).HasName("PK_Customer Contacts");

                entity.Property(e => e.CellPhone).HasMaxLength(50);
                entity.Property(e => e.ContactArabicName).HasMaxLength(100);
                entity.Property(e => e.ContactName).HasMaxLength(100);
                entity.Property(e => e.CustomerID).HasMaxLength(15);
                entity.Property(e => e.E_Mail)
                    .HasMaxLength(100)
                    .HasColumnName("E-Mail");
                entity.Property(e => e.Tel).HasMaxLength(50);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
