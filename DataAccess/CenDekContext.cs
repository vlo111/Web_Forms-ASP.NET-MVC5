using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using DataAccess.Models;
using DataAccess.Models.Mapping;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DataAccess
{
    public partial class CenDekContext : DbContext
    {
        static CenDekContext()
        {
            Database.SetInitializer<CenDekContext>(null);
        }

        public CenDekContext()
            : base("Name=CenDekContext")
        {
        }

        public DbSet<AltPartID> AltPartIDs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Colour> Colours { get; set; }
        public DbSet<ContactInfo> ContactInfoes { get; set; }
        public DbSet<ContactInfoType> ContactInfoTypes { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerContact> CustomerContacts { get; set; }
        public DbSet<CustOrder> CustOrders { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<FileTmp> FilesTmp { get; set; }
        public DbSet<GroupUrgency> GroupUrgencies { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<MeasUnit> MeasUnits { get; set; }
        public DbSet<OrderPart> OrderParts { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<PartDependency> PartDependencies { get; set; }
        public DbSet<PartInventory> PartInventories { get; set; }
        public DbSet<PartStatu> PartStatus { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<ProductLine> ProductLines { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<ShippingAddress> ShippingAddresses { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Configurations.Add(new AltPartIDMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new ColourMap());
            modelBuilder.Configurations.Add(new ContactInfoMap());
            modelBuilder.Configurations.Add(new ContactInfoTypeMap());
            modelBuilder.Configurations.Add(new CurrencyMap());
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new CustomerContactMap());
            modelBuilder.Configurations.Add(new CustOrderMap());
            modelBuilder.Configurations.Add(new DocumentTypeMap());
            modelBuilder.Configurations.Add(new EmployeeMap());
            modelBuilder.Configurations.Add(new FileMap());
            modelBuilder.Configurations.Add(new FileTmpMap());
            modelBuilder.Configurations.Add(new GroupUrgencyMap());
            modelBuilder.Configurations.Add(new ImageMap());
            modelBuilder.Configurations.Add(new MeasUnitMap());
            modelBuilder.Configurations.Add(new OrderPartMap());
            modelBuilder.Configurations.Add(new PartMap());
            modelBuilder.Configurations.Add(new PartDependencyMap());
            modelBuilder.Configurations.Add(new PartInventoryMap());
            modelBuilder.Configurations.Add(new PartStatuMap());
            modelBuilder.Configurations.Add(new PriceMap());
            modelBuilder.Configurations.Add(new ProductLineMap());
            modelBuilder.Configurations.Add(new ShipmentMap());
            modelBuilder.Configurations.Add(new ShippingAddressMap());
            modelBuilder.Configurations.Add(new TagMap());
        }
    }
}
