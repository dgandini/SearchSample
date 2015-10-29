using SearchSampleApp.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SearchSampleApp.Data.Configurations
{
    public class OrderConfiguration : EntityTypeConfiguration<Order>
    {
        public OrderConfiguration()
        {
            ToTable("Order");
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasColumnName("OrderId")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(x => x.Date)
                .HasColumnName("OrderDate")
                .IsRequired();

            Property(x => x.Total)
                .HasColumnName("OrderTotal")
                .IsRequired();

            Property(x => x.Status)
                .HasColumnName("OrderStatus")
                .HasMaxLength(20)
                .IsRequired();

            // fk relationship
            HasRequired(a => a.Customer).WithMany(b => b.Orders).HasForeignKey(c => c.CustomerId);

        }

    }
}