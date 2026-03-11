using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SchetinkinDemo06032026.Models;

public partial class SchetinkinContext : DbContext
{
    public SchetinkinContext()
    {
    }

    public SchetinkinContext(DbContextOptions<SchetinkinContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Agent> Agents { get; set; }

    public virtual DbSet<Agentpriorityhistory> Agentpriorityhistories { get; set; }

    public virtual DbSet<Agenttype> Agenttypes { get; set; }

    public virtual DbSet<Material> Materials { get; set; }

    public virtual DbSet<Materialcounthistory> Materialcounthistories { get; set; }

    public virtual DbSet<Materialsupplier> Materialsuppliers { get; set; }

    public virtual DbSet<Materialtype> Materialtypes { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Productcosthistory> Productcosthistories { get; set; }

    public virtual DbSet<Productmaterial> Productmaterials { get; set; }

    public virtual DbSet<Productsale> Productsales { get; set; }

    public virtual DbSet<Producttype> Producttypes { get; set; }

    public virtual DbSet<Shop> Shops { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=192.168.2.18;Port=5432;Username=schetinkin;Database=schetinkin;Password=81427");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Agent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("agent_pk");

            entity.ToTable("agent");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.Agenttypeid).HasColumnName("agenttypeid");
            entity.Property(e => e.Direcorname).HasColumnName("direcorname");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Inn).HasColumnName("inn");
            entity.Property(e => e.Kpp).HasColumnName("kpp");
            entity.Property(e => e.Login)
                .HasColumnType("character varying")
                .HasColumnName("login");
            entity.Property(e => e.Logo).HasColumnName("logo");
            entity.Property(e => e.Password)
                .HasColumnType("character varying")
                .HasColumnName("password");
            entity.Property(e => e.Phone).HasColumnName("phone");
            entity.Property(e => e.Prioriry).HasColumnName("prioriry");
            entity.Property(e => e.Title).HasColumnName("title");

            entity.HasOne(d => d.Agenttype).WithMany(p => p.Agents)
                .HasForeignKey(d => d.Agenttypeid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("agent_agenttype_fk");
        });

        modelBuilder.Entity<Agentpriorityhistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("agentpriorityhistory_pk");

            entity.ToTable("agentpriorityhistory");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Agentid).HasColumnName("agentid");
            entity.Property(e => e.Changedate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("changedate");
            entity.Property(e => e.Priorityvalue).HasColumnName("priorityvalue");

            entity.HasOne(d => d.Agent).WithMany(p => p.Agentpriorityhistories)
                .HasForeignKey(d => d.Agentid)
                .HasConstraintName("agentpriorityhistory_agent_fk");
        });

        modelBuilder.Entity<Agenttype>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("agenttype_pk");

            entity.ToTable("agenttype");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Image).HasColumnName("image");
            entity.Property(e => e.Title).HasColumnName("title");
        });

        modelBuilder.Entity<Material>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("material_pk");

            entity.ToTable("material");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Countinpack).HasColumnName("countinpack");
            entity.Property(e => e.Countinstock).HasColumnName("countinstock");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Image).HasColumnName("image");
            entity.Property(e => e.Materialtypeid).HasColumnName("materialtypeid");
            entity.Property(e => e.Mincount).HasColumnName("mincount");
            entity.Property(e => e.Title).HasColumnName("title");
            entity.Property(e => e.Unit).HasColumnName("unit");

            entity.HasOne(d => d.Materialtype).WithMany(p => p.Materials)
                .HasForeignKey(d => d.Materialtypeid)
                .HasConstraintName("material_materialtype_fk");
        });

        modelBuilder.Entity<Materialcounthistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("materialcounthistory_pk");

            entity.ToTable("materialcounthistory");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Changedate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("changedate");
            entity.Property(e => e.Countvalue).HasColumnName("countvalue");
            entity.Property(e => e.Materialid).HasColumnName("materialid");

            entity.HasOne(d => d.Material).WithMany(p => p.Materialcounthistories)
                .HasForeignKey(d => d.Materialid)
                .HasConstraintName("materialcounthistory_material_fk");
        });

        modelBuilder.Entity<Materialsupplier>(entity =>
        {
            entity.HasKey(e => e.Materialid).HasName("materialsupplier_pk");

            entity.ToTable("materialsupplier");

            entity.Property(e => e.Materialid)
                .ValueGeneratedOnAdd()
                .UseIdentityAlwaysColumn()
                .HasColumnName("materialid");
            entity.Property(e => e.Supplierid).HasColumnName("supplierid");

            entity.HasOne(d => d.Material).WithOne(p => p.Materialsupplier)
                .HasForeignKey<Materialsupplier>(d => d.Materialid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("materialsupplier_material_fk");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Materialsuppliers)
                .HasForeignKey(d => d.Supplierid)
                .HasConstraintName("materialsupplier_supplier_fk");
        });

        modelBuilder.Entity<Materialtype>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("materialtype_pk");

            entity.ToTable("materialtype");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Defectedpercent).HasColumnName("defectedpercent");
            entity.Property(e => e.Title).HasColumnName("title");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("product_pk");

            entity.ToTable("product");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Articlenumber).HasColumnName("articlenumber");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Image).HasColumnName("image");
            entity.Property(e => e.Mincostforagent).HasColumnName("mincostforagent");
            entity.Property(e => e.Productionpersoncount).HasColumnName("productionpersoncount");
            entity.Property(e => e.Productionworkshopnumber).HasColumnName("productionworkshopnumber");
            entity.Property(e => e.Producttypeid).HasColumnName("producttypeid");
            entity.Property(e => e.Title).HasColumnName("title");

            entity.HasOne(d => d.Producttype).WithMany(p => p.Products)
                .HasForeignKey(d => d.Producttypeid)
                .HasConstraintName("product_producttype_fk");
        });

        modelBuilder.Entity<Productcosthistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("productcosthistory_pk");

            entity.ToTable("productcosthistory");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Changedate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("changedate");
            entity.Property(e => e.Costvalue).HasColumnName("costvalue");
            entity.Property(e => e.Productid).HasColumnName("productid");

            entity.HasOne(d => d.Product).WithMany(p => p.Productcosthistories)
                .HasForeignKey(d => d.Productid)
                .HasConstraintName("productcosthistory_product_fk");
        });

        modelBuilder.Entity<Productmaterial>(entity =>
        {
            entity.HasKey(e => e.Productid).HasName("productmaterial_pk");

            entity.ToTable("productmaterial");

            entity.Property(e => e.Productid)
                .ValueGeneratedOnAdd()
                .UseIdentityAlwaysColumn()
                .HasColumnName("productid");
            entity.Property(e => e.Count).HasColumnName("count");
            entity.Property(e => e.Materialid).HasColumnName("materialid");

            entity.HasOne(d => d.Material).WithMany(p => p.Productmaterials)
                .HasForeignKey(d => d.Materialid)
                .HasConstraintName("productmaterial_material_fk");

            entity.HasOne(d => d.Product).WithOne(p => p.Productmaterial)
                .HasForeignKey<Productmaterial>(d => d.Productid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("productmaterial_product_fk");
        });

        modelBuilder.Entity<Productsale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("productsale_pk");

            entity.ToTable("productsale");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Agentid).HasColumnName("agentid");
            entity.Property(e => e.Productcount).HasColumnName("productcount");
            entity.Property(e => e.Productid).HasColumnName("productid");
            entity.Property(e => e.Saledate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("saledate");

            entity.HasOne(d => d.Agent).WithMany(p => p.Productsales)
                .HasForeignKey(d => d.Agentid)
                .HasConstraintName("productsale_agent_fk");

            entity.HasOne(d => d.Product).WithMany(p => p.Productsales)
                .HasForeignKey(d => d.Productid)
                .HasConstraintName("productsale_product_fk");
        });

        modelBuilder.Entity<Producttype>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("producttype_pk");

            entity.ToTable("producttype");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Defectedpercent).HasColumnName("defectedpercent");
            entity.Property(e => e.Title).HasColumnName("title");
        });

        modelBuilder.Entity<Shop>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("shop_pk");

            entity.ToTable("shop");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.Agentid).HasColumnName("agentid");
            entity.Property(e => e.Title).HasColumnName("title");

            entity.HasOne(d => d.Agent).WithMany(p => p.Shops)
                .HasForeignKey(d => d.Agentid)
                .HasConstraintName("shop_agent_fk");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("supplier_pk");

            entity.ToTable("supplier");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Inn).HasColumnName("inn");
            entity.Property(e => e.Qualityrating).HasColumnName("qualityrating");
            entity.Property(e => e.Startdate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("startdate");
            entity.Property(e => e.Suppliertype).HasColumnName("suppliertype");
            entity.Property(e => e.Title).HasColumnName("title");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
