using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Fabi.Core.Entity;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<AccountPermissionPageCategory> AccountPermissionPageCategories { get; set; }

    public virtual DbSet<AccountRole> AccountRoles { get; set; }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<AddressBase> AddressBases { get; set; }

    public virtual DbSet<AddressType> AddressTypes { get; set; }

    public virtual DbSet<ApartDaire> ApartDaires { get; set; }

    public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }

    public virtual DbSet<Area> Areas { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<City1> Cities1 { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<CompanyPrePaid> CompanyPrePaids { get; set; }

    public virtual DbSet<CompanyShowRoom> CompanyShowRooms { get; set; }

    public virtual DbSet<CompanyUser> CompanyUsers { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<DeliveryGroup> DeliveryGroups { get; set; }

    public virtual DbSet<DeliveryGroupCompany> DeliveryGroupCompanies { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeRole> EmployeeRoles { get; set; }

    public virtual DbSet<Friend> Friends { get; set; }

    public virtual DbSet<Neighborhood> Neighborhoods { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDelivery> OrderDeliveries { get; set; }

    public virtual DbSet<OrderDeliveryCompany> OrderDeliveryCompanies { get; set; }

    public virtual DbSet<OrderDeliveryCompanyProduct> OrderDeliveryCompanyProducts { get; set; }

    public virtual DbSet<OrderDeliveryGroup> OrderDeliveryGroups { get; set; }

    public virtual DbSet<OrderProduct> OrderProducts { get; set; }

    public virtual DbSet<OrderStatus> OrderStatuses { get; set; }

    public virtual DbSet<Page> Pages { get; set; }

    public virtual DbSet<PageCategory> PageCategories { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Price> Prices { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductPart> ProductParts { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Token> Tokens { get; set; }

    public virtual DbSet<Town> Towns { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRefreshToken> UserRefreshTokens { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=94.73.144.21;;Database=u0628558_myfabi;User Id=u0628558_myfabi;Password=Q3==5wvE=k_hT42O;Pooling=false;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Account__3214EC07A52F0801");

            entity.ToTable("Account");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.IdActive)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.Password)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.HasOne(d => d.AccountRole).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.AccountRoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Account_FKK");

            entity.HasOne(d => d.User).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Account_FK");
        });

        modelBuilder.Entity<AccountPermissionPageCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AccountPermissionPageCategory__3214EC07A52F0801");

            entity.ToTable("AccountPermissionPageCategory");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.AccountPermissionPageCategory)
                .HasForeignKey<AccountPermissionPageCategory>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("AccountPermissionPageCategory_FK");

            entity.HasOne(d => d.PageCategory).WithMany(p => p.AccountPermissionPageCategories)
                .HasForeignKey(d => d.PageCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("AccountPermissionPageCategory_FK_1");
        });

        modelBuilder.Entity<AccountRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AccountR__3214EC078155D7ED");

            entity.ToTable("AccountRole");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Address__3214EC07347F2575");

            entity.ToTable("Address");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.AddressDetail)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.CoordinatesX)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CoordinatesY)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.AddressType).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.AddressTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Address_FK");

            entity.HasOne(d => d.City).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Address_FKK");

            entity.HasOne(d => d.Town).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.TownId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Address_FK_1");
        });

        modelBuilder.Entity<AddressBase>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_YeniAdresTablosu");

            entity.ToTable("AddressBase");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AddressId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Maxlatitude).HasColumnName("maxlatitude");
            entity.Property(e => e.Maxlongitude).HasColumnName("maxlongitude");
            entity.Property(e => e.Minlatitude).HasColumnName("minlatitude");
            entity.Property(e => e.Minlongitude).HasColumnName("minlongitude");
        });

        modelBuilder.Entity<AddressType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AddressT__3214EC0711F13306");

            entity.ToTable("AddressType");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ApartDaire>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ApartDaire__3214EC07FB7D4D5E");

            entity.ToTable("ApartDaire");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.KiraBedeli).HasColumnType("numeric(10, 2)");
            entity.Property(e => e.KiraciAdı)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.KiraciCikis).HasColumnType("datetime");
            entity.Property(e => e.KiraciGiris).HasColumnType("datetime");
            entity.Property(e => e.KiraciTelefon)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.KiracıSoyadi)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ApplicationUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ApplicationUser__3214EC07A52F0801");

            entity.ToTable("ApplicationUser");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasOne(d => d.User).WithMany(p => p.ApplicationUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ApplicationUser_FK");
        });

        modelBuilder.Entity<Area>(entity =>
        {
            entity.HasKey(e => e.AreaId).HasName("PK__Areas__70B82028BC3C9454");

            entity.HasIndex(e => e.CountyId, "FK_Area_CountyID");

            entity.Property(e => e.AreaId)
                .ValueGeneratedNever()
                .HasColumnName("AreaID");
            entity.Property(e => e.AreaName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CountyId).HasColumnName("CountyID");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.CityId).HasName("PK__Cities__F2D21A963A7A8719");

            entity.HasIndex(e => e.CountryId, "FK_Cities_CountryID");

            entity.Property(e => e.CityId)
                .ValueGeneratedNever()
                .HasColumnName("CityID");
            entity.Property(e => e.CityName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CountryId).HasColumnName("CountryID");
            entity.Property(e => e.PhoneCode)
                .HasMaxLength(7)
                .IsUnicode(false);
            entity.Property(e => e.PlateNo)
                .HasMaxLength(2)
                .IsUnicode(false);
        });

        modelBuilder.Entity<City1>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__City__3214EC07E62C4FB3");

            entity.ToTable("City");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Company__3214EC07166E417A");

            entity.ToTable("Company");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Phone2)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TaxNumber)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TaxOffice)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Address).WithMany(p => p.Companies)
                .HasForeignKey(d => d.AddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Company_FK");
        });

        modelBuilder.Entity<CompanyPrePaid>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CompanyPrePaids__3214EC07A52F0801");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.BalanceAmount).HasColumnType("numeric(10, 2)");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.IdActive)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.TotalAmount).HasColumnType("numeric(10, 2)");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("updatedDate");
        });

        modelBuilder.Entity<CompanyShowRoom>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CompanyS__3214EC073A508554");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("((1))");

            entity.HasOne(d => d.Address).WithMany(p => p.CompanyShowRooms)
                .HasForeignKey(d => d.AddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("CompanyShowRooms_FK_1");

            entity.HasOne(d => d.Company).WithMany(p => p.CompanyShowRooms)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("CompanyShowRooms_FK");

            entity.HasOne(d => d.ContactUser).WithMany(p => p.CompanyShowRooms)
                .HasForeignKey(d => d.ContactUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("CompanyShowRooms_FKK");
        });

        modelBuilder.Entity<CompanyUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CompanyU__3214EC07CD86DD59");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("((1))");

            entity.HasOne(d => d.User).WithMany(p => p.CompanyUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("CompanyUsers_FK");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Country__3214EC078092103E");

            entity.ToTable("Country");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DeliveryGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Delivery__3214EC07074A0F06");

            entity.ToTable("DeliveryGroup");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.City).WithMany(p => p.DeliveryGroups)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("DeliveryGroup_FK");
        });

        modelBuilder.Entity<DeliveryGroupCompany>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Delivery__3214EC07914FED91");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.Company).WithMany(p => p.DeliveryGroupCompanies)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("DeliveryGroupCompanies_FK_1");

            entity.HasOne(d => d.DeliveryGroup).WithMany(p => p.DeliveryGroupCompanies)
                .HasForeignKey(d => d.DeliveryGroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("DeliveryGroupCompanies_FK");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC0710A8089C");

            entity.ToTable("Employee");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.EndDate)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnType("datetime");
            entity.Property(e => e.StartDate)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.User).WithMany(p => p.Employees)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Employee_FK");

            entity.HasOne(d => d.UserRole).WithMany(p => p.Employees)
                .HasForeignKey(d => d.UserRoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Employee_FKK");
        });

        modelBuilder.Entity<EmployeeRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC077BC7E799");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.EndDate)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnType("datetime");
            entity.Property(e => e.StartDate)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.User).WithMany(p => p.EmployeeRoles)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("EmployeeRoles_FK");

            entity.HasOne(d => d.UserRole).WithMany(p => p.EmployeeRoles)
                .HasForeignKey(d => d.UserRoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("EmployeeRoles_FK_1");
        });

        modelBuilder.Entity<Friend>(entity =>
        {
            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.BeFriendAt).HasColumnType("datetime");

            entity.HasOne(d => d.User).WithMany(p => p.Friends)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("Friends_FKK");
        });

        modelBuilder.Entity<Neighborhood>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Neighbor__3214EC07EACDA658");

            entity.ToTable("Neighborhood");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Xcoordinate)
                .HasMaxLength(100)
                .HasColumnName("XCoordinate");
            entity.Property(e => e.XcoordinateMax)
                .HasMaxLength(200)
                .HasColumnName("XCoordinateMax");
            entity.Property(e => e.Ycoordinate)
                .HasMaxLength(100)
                .HasColumnName("YCoordinate");
            entity.Property(e => e.YcoordinateMax)
                .HasMaxLength(200)
                .HasColumnName("YCoordinateMax");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Orders__3214EC077958FD96");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Amount).HasColumnType("numeric(10, 2)");
            entity.Property(e => e.Balance).HasColumnType("numeric(10, 2)");
            entity.Property(e => e.DeliveryDate).HasColumnType("datetime");
            entity.Property(e => e.Discount).HasColumnType("numeric(10, 2)");
            entity.Property(e => e.OrderComplateDate).HasColumnType("datetime");
            entity.Property(e => e.OrderDate)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.Company).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orders__CompanyI__72910220");

            entity.HasOne(d => d.CompanyShowRoom).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CompanyShowRoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orders__CompanyS__756D6ECB");

            entity.HasOne(d => d.CompanyUser).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CompanyUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orders__CompanyU__73852659");

            entity.HasOne(d => d.ConfirmedByNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ConfirmedBy)
                .HasConstraintName("Orders_FK_Confirmed");

            entity.HasOne(d => d.Employee).WithMany(p => p.Orders)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orders__Employee__74794A92");

            entity.HasOne(d => d.OrderStatus).WithMany(p => p.Orders)
                .HasForeignKey(d => d.OrderStatusId)
                .HasConstraintName("Orders_FK");
        });

        modelBuilder.Entity<OrderDelivery>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderDel__3214EC074CECAAD2");

            entity.ToTable("OrderDelivery");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnType("datetime");
            entity.Property(e => e.PlanedDate)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.Status)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Employee).WithMany(p => p.OrderDeliveries)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("OrderDelivery_FK_1");

            entity.HasOne(d => d.OrderDeliveryGroup).WithMany(p => p.OrderDeliveries)
                .HasForeignKey(d => d.OrderDeliveryGroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("OrderDelivery_FK");
        });

        modelBuilder.Entity<OrderDeliveryCompany>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderDel__3214EC07638CF9A8");

            entity.ToTable("OrderDeliveryCompany");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.Company).WithMany(p => p.OrderDeliveryCompanies)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("OrderDeliveryCompany_FK_1");

            entity.HasOne(d => d.OrderDelivery).WithMany(p => p.OrderDeliveryCompanies)
                .HasForeignKey(d => d.OrderDeliveryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("OrderDeliveryCompany_FK");
        });

        modelBuilder.Entity<OrderDeliveryCompanyProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderDel__3214EC077A497F36");

            entity.ToTable("OrderDeliveryCompanyProduct");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.OrderDeliveryCompany).WithMany(p => p.OrderDeliveryCompanyProducts)
                .HasForeignKey(d => d.OrderDeliveryCompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("OrderDeliveryCompanyProduct_FK");

            entity.HasOne(d => d.OrderProduct).WithMany(p => p.OrderDeliveryCompanyProducts)
                .HasForeignKey(d => d.OrderProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("OrderDeliveryCompanyProduct_FK_1");
        });

        modelBuilder.Entity<OrderDeliveryGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("OrderDeliveryGroup_PK");

            entity.ToTable("OrderDeliveryGroup");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.City).WithMany(p => p.OrderDeliveryGroups)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("OrderDeliveryGroup_FK");
        });

        modelBuilder.Entity<OrderProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderDet__3214EC07EA72EEA7");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Color)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Counts).HasDefaultValueSql("((1))");
            entity.Property(e => e.Discount).HasColumnType("numeric(10, 2)");
            entity.Property(e => e.IsDelivered).HasDefaultValueSql("((0))");
            entity.Property(e => e.ProductDetail).IsUnicode(false);
            entity.Property(e => e.TotalAmount).HasColumnType("numeric(10, 2)");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderProducts)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("OrderProducts_FK");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderProducts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("OrderProducts_FK_1");

            entity.HasOne(d => d.ProductPart).WithMany(p => p.OrderProducts)
                .HasForeignKey(d => d.ProductPartId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("OrderProducts_FK_2");
        });

        modelBuilder.Entity<OrderStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderStatus__3214EC077958FD96");

            entity.ToTable("OrderStatus");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.OrderStatusName)
                .HasMaxLength(2)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Page>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Paged__3214EC07A52F0801");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.PageName)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PageCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PageCategory__3214EC07A52F0801");

            entity.ToTable("PageCategory");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Payments__3213E83F60D1CBC3");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.Amount).HasColumnType("numeric(10, 2)");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnType("datetime");
            entity.Property(e => e.PaymentDate)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.Company).WithMany(p => p.Payments)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Payments_FK_1");

            entity.HasOne(d => d.CompanyUser).WithMany(p => p.Payments)
                .HasForeignKey(d => d.CompanyUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Payments_FK_2");

            entity.HasOne(d => d.Employee).WithMany(p => p.Payments)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Payments_FK_3");

            entity.HasOne(d => d.Order).WithMany(p => p.Payments)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Payments_FK");
        });

        modelBuilder.Entity<Price>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Prices__3214EC07A52F0801");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Amount).HasColumnType("numeric(10, 2)");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.IdActive)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("updatedDate");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Products__3214EC076D235598");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Color)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ProductPartCount).HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<ProductPart>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProductP__3214EC07E5F04190");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ProductPartCount).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductParts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ProductParts_FK");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Status__3214EC07166E417A");

            entity.ToTable("Status");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Token>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.AccessToken).HasMaxLength(100);
            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.RefreshToken).HasMaxLength(100);
        });

        modelBuilder.Entity<Town>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Town__3214EC07D437DC08");

            entity.ToTable("Town");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07FB7D4D5E");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CompanyId).HasDefaultValueSql("((1))");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SurName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Address).WithMany(p => p.Users)
                .HasForeignKey(d => d.AddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Users_FKK");
        });

        modelBuilder.Entity<UserRefreshToken>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.RefreshToken).HasMaxLength(100);
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserRole__3214EC07BE6F40AA");

            entity.ToTable("UserRole");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
