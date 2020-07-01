namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PetStoreDbContext : DbContext
    {
        public PetStoreDbContext()
            : base("name=PetStoreDbContext")
        {
        }

        public virtual DbSet<DanhMuc> DanhMucs { get; set; }
        public virtual DbSet<GiongPet> GiongPets { get; set; }
        public virtual DbSet<Pet> Pets { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<DonHang> DonHangs{ get; set; }
        public virtual DbSet<Slide> Slides { get; set; }
        public virtual DbSet<DichVu> DichVus { get; set; }
        public virtual DbSet<LichHen> LichHens { get; set; }
        public virtual DbSet<LichHenDetail> LichHenDetails { get; set; }
        public virtual DbSet<LichKyGui> LichKyGuis { get; set; }
        public virtual DbSet<KhuyenMai> KhuyenMais { get; set; }
        public virtual DbSet<BaiViet> BaiViets { get; set; }
        public virtual DbSet<DonHangDetail> DonHangDetails { get; set; }
        public virtual DbSet<CapNhatKyGui> CapNhatKyGuis { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DanhMuc>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<GiongPet>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Pet>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Pet>()
                .Property(e => e.GiaTien)
                .HasPrecision(18, 0);

            modelBuilder.Entity<User>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);
        }
    }
}
