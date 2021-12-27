using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace CSDL.EF
{
    public partial class QLGVDBContext : DbContext
    {
        public QLGVDBContext()
            : base("name=QLGVDBContext")
        {
        }

        public virtual DbSet<TBL_BoMon> TBL_BoMon { get; set; }
        public virtual DbSet<TBL_ChiTietCTK> TBL_ChiTietCTK { get; set; }
        public virtual DbSet<TBL_ChiTietDiemDanh> TBL_ChiTietDiemDanh { get; set; }
        public virtual DbSet<TBL_ChiTietThoiKhoaBieu> TBL_ChiTietThoiKhoaBieu { get; set; }
        public virtual DbSet<TBL_ChucVu> TBL_ChucVu { get; set; }
        public virtual DbSet<TBL_ChuongTrinhKhung> TBL_ChuongTrinhKhung { get; set; }
        public virtual DbSet<TBL_ChuyenNganh> TBL_ChuyenNganh { get; set; }
        public virtual DbSet<TBL_DiemDanh> TBL_DiemDanh { get; set; }
        public virtual DbSet<TBL_GiangVien> TBL_GiangVien { get; set; }
        public virtual DbSet<TBL_HocKy> TBL_HocKy { get; set; }
        public virtual DbSet<TBL_Khoa> TBL_Khoa { get; set; }
        public virtual DbSet<TBL_Lop> TBL_Lop { get; set; }
        public virtual DbSet<TBL_MonHoc> TBL_MonHoc { get; set; }
        public virtual DbSet<TBL_PhanCongDay> TBL_PhanCongDay { get; set; }
        public virtual DbSet<TBL_PhongHoc> TBL_PhongHoc { get; set; }
        public virtual DbSet<TBL_TaiKhoan> TBL_TaiKhoan { get; set; }
        public virtual DbSet<TBL_ThoiKhoaBieuGiangVien> TBL_ThoiKhoaBieuGiangVien { get; set; }
        public virtual DbSet<TBL_TietHoc> TBL_TietHoc { get; set; }
        public virtual DbSet<TBL_Tuan> TBL_Tuan { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TBL_ChiTietThoiKhoaBieu>()
                .HasMany(e => e.TBL_ChiTietDiemDanh)
                .WithRequired(e => e.TBL_ChiTietThoiKhoaBieu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TBL_ChucVu>()
                .HasMany(e => e.TBL_GiangVien)
                .WithRequired(e => e.TBL_ChucVu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TBL_ChuongTrinhKhung>()
                .HasMany(e => e.TBL_ChiTietCTK)
                .WithRequired(e => e.TBL_ChuongTrinhKhung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TBL_DiemDanh>()
                .HasMany(e => e.TBL_ChiTietDiemDanh)
                .WithRequired(e => e.TBL_DiemDanh)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TBL_GiangVien>()
                .Property(e => e.SDT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TBL_GiangVien>()
                .HasMany(e => e.TBL_DiemDanh)
                .WithRequired(e => e.TBL_GiangVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TBL_GiangVien>()
                .HasMany(e => e.TBL_PhanCongDay)
                .WithRequired(e => e.TBL_GiangVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TBL_GiangVien>()
                .HasMany(e => e.TBL_ThoiKhoaBieuGiangVien)
                .WithRequired(e => e.TBL_GiangVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TBL_GiangVien>()
                .HasMany(e => e.TBL_TaiKhoan)
                .WithRequired(e => e.TBL_GiangVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TBL_Khoa>()
                .HasMany(e => e.TBL_GiangVien)
                .WithRequired(e => e.TBL_Khoa)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TBL_Khoa>()
                .HasMany(e => e.TBL_Lop)
                .WithRequired(e => e.TBL_Khoa)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TBL_Lop>()
                .HasMany(e => e.TBL_ChiTietThoiKhoaBieu)
                .WithRequired(e => e.TBL_Lop)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TBL_Lop>()
                .HasMany(e => e.TBL_ChuongTrinhKhung)
                .WithRequired(e => e.TBL_Lop)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TBL_Lop>()
                .HasMany(e => e.TBL_PhanCongDay)
                .WithRequired(e => e.TBL_Lop)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TBL_MonHoc>()
                .HasMany(e => e.TBL_PhanCongDay)
                .WithRequired(e => e.TBL_MonHoc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TBL_PhanCongDay>()
                .HasMany(e => e.TBL_ChiTietThoiKhoaBieu)
                .WithRequired(e => e.TBL_PhanCongDay)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TBL_TaiKhoan>()
                .Property(e => e.TaiKhoan)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TBL_TaiKhoan>()
                .Property(e => e.MatKhau)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TBL_TietHoc>()
                .HasMany(e => e.TBL_ChiTietThoiKhoaBieu)
                .WithRequired(e => e.TBL_TietHoc)
                .WillCascadeOnDelete(false);
        }
    }
}
