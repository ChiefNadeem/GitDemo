using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Assignment2.Models
{
    public partial class ShoppingContext : DbContext
    {
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //  #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        // optionsBuilder.UseSqlServer(@"Server=(localdb)\ProjectsV13;Database=Shopping;Trusted_Connection=True;"); 
        //}

        public ShoppingContext(DbContextOptions<ShoppingContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblCategory>(entity =>
            {
                entity.HasKey(e => e.Categoryid)
                    .HasName("PK__tblCateg__23CDE590489179DE");

                entity.ToTable("tblCategory");

                entity.Property(e => e.Categoryid).HasColumnName("categoryid");

                entity.Property(e => e.CategoryName)
                    .HasColumnName("category_name")
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("created_date")
                    .HasMaxLength(50);

                entity.Property(e => e.ModifyBy)
                    .HasColumnName("modify_by")
                    .HasMaxLength(50);

                entity.Property(e => e.ModifyDate)
                    .HasColumnName("modify_date")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblProduct>(entity =>
            {
                entity.HasKey(e => e.Productid)
                    .HasName("PK__tblProdu__2D172D32D35FD71D");

                entity.ToTable("tblProduct");

                entity.Property(e => e.Productid).HasColumnName("productid");

                entity.Property(e => e.Categoryid).HasColumnName("categoryid");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("created_date")
                    .HasMaxLength(50);

                entity.Property(e => e.ModifyBy)
                    .HasColumnName("modify_by")
                    .HasMaxLength(50);

                entity.Property(e => e.ModifyDate)
                    .HasColumnName("modify_date")
                    .HasMaxLength(50);

                entity.Property(e => e.ProductDiscription)
                    .HasColumnName("product_discription")
                    .HasMaxLength(50);

                entity.Property(e => e.ProductImage)
                    .HasColumnName("product_image")
                    .HasMaxLength(50);

                entity.Property(e => e.ProductName)
                    .HasColumnName("product_name")
                    .HasMaxLength(50);

                entity.Property(e => e.ProductPrice).HasColumnName("product_price");

                entity.Property(e => e.Scategoryid).HasColumnName("scategoryid");
            });

            modelBuilder.Entity<TblSubCategory>(entity =>
            {
                entity.HasKey(e => e.Scategoryid)
                    .HasName("PK__tmp_ms_x__21FD755E41D9B61E");

                entity.ToTable("tblSubCategory");

                entity.Property(e => e.Scategoryid).HasColumnName("scategoryid");

                entity.Property(e => e.Categoryid).HasColumnName("categoryid");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("created_date")
                    .HasMaxLength(50);

                entity.Property(e => e.ModifyBy)
                    .HasColumnName("modify_by")
                    .HasMaxLength(50);

                entity.Property(e => e.ModifyDate)
                    .HasColumnName("modify_date")
                    .HasMaxLength(50);

                entity.Property(e => e.ScategoryName)
                    .HasColumnName("scategory_name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.HasKey(e => e.Userid)
                    .HasName("PK__tblUser__CBA1B2571D86F72F");

                entity.ToTable("tblUser");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("created_date")
                    .HasMaxLength(50);

                entity.Property(e => e.ModifyBy)
                    .HasColumnName("modify_by")
                    .HasMaxLength(50);

                entity.Property(e => e.ModifyDate)
                    .HasColumnName("modify_date")
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(50);

                entity.Property(e => e.UserName)
                    .HasColumnName("user_name")
                    .HasMaxLength(50);
                entity.Property(e => e.Type)
                   .HasColumnName("type")
                   .HasMaxLength(50);
            });
        }

        public virtual DbSet<TblCategory> TblCategory { get; set; }
        public virtual DbSet<TblProduct> TblProduct { get; set; }
        public virtual DbSet<TblSubCategory> TblSubCategory { get; set; }
        public virtual DbSet<TblUser> TblUser { get; set; }
    }
}