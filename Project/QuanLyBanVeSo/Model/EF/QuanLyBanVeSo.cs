namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QuanLyBanVeSoDbContext: DbContext
    {
        public QuanLyBanVeSoDbContext()
            : base("name=QuanLyBanVeSo")
        {
        }

        public virtual DbSet<DAILY> DAILies { get; set; }
        public virtual DbSet<GIAI> GIAIs { get; set; }
        public virtual DbSet<KETQUA> KETQUAs { get; set; }
        public virtual DbSet<PHANPHOI> PHANPHOIs { get; set; }
        public virtual DbSet<PHIEUCHI> PHIEUCHIs { get; set; }
        public virtual DbSet<PHIEUTHU> PHIEUTHUs { get; set; }
        public virtual DbSet<SOLUONGDANGKY> SOLUONGDANGKies { get; set; }
        public virtual DbSet<VESO> VESOes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KETQUA>()
                .Property(e => e.SOTRUNG)
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUCHI>()
                .Property(e => e.TIEN)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PHIEUTHU>()
                .Property(e => e.TIEN)
                .HasPrecision(19, 4);
        }
    }
}
