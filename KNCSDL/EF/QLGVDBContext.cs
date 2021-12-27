using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace KNCSDL.EF
{
    public partial class QLGVDBContext : DbContext
    {
        public QLGVDBContext()
            : base("name=QLGVDBContext1")
        {
        }

        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TBL_BoMon> TBL_BoMon { get; set; }
        public virtual DbSet<TBL_ChiTietDiemDanh> TBL_ChiTietDiemDanh { get; set; }
        public virtual DbSet<TBL_ChiTietThoiKhoaBieu> TBL_ChiTietThoiKhoaBieu { get; set; }
        public virtual DbSet<TBL_ChucVu> TBL_ChucVu { get; set; }
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
        public virtual DbSet<TBL_TinTuc> TBL_TinTuc { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TBL_BoMon>()
                .Property(e => e.MaBoMon)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TBL_ChiTietDiemDanh>()
                .Property(e => e.MaDiemDanh)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TBL_ChiTietDiemDanh>()
                .Property(e => e.MaCTTKB)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TBL_ChiTietDiemDanh>()
                .Property(e => e.MaGiangVien)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TBL_ChiTietThoiKhoaBieu>()
                .Property(e => e.MaCTTKB)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TBL_ChiTietThoiKhoaBieu>()
                .Property(e => e.MaTKB)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TBL_ChiTietThoiKhoaBieu>()
                .Property(e => e.Tuan)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TBL_ChiTietThoiKhoaBieu>()
                .Property(e => e.MaLop)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TBL_ChiTietThoiKhoaBieu>()
                .Property(e => e.MaTiet)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TBL_ChiTietThoiKhoaBieu>()
                .Property(e => e.MaPhong)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TBL_ChiTietThoiKhoaBieu>()
                .HasMany(e => e.TBL_ChiTietDiemDanh)
                .WithRequired(e => e.TBL_ChiTietThoiKhoaBieu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TBL_ChucVu>()
                .Property(e => e.MaChucVu)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TBL_ChucVu>()
                .HasMany(e => e.TBL_GiangVien)
                .WithRequired(e => e.TBL_ChucVu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TBL_ChuyenNganh>()
                .Property(e => e.MaChuyenNganh)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TBL_DiemDanh>()
                .Property(e => e.MaDiemDanh)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TBL_DiemDanh>()
                .Property(e => e.MaGiangVien)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TBL_DiemDanh>()
                .Property(e => e.MaHocKy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TBL_DiemDanh>()
                .HasMany(e => e.TBL_ChiTietDiemDanh)
                .WithRequired(e => e.TBL_DiemDanh)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TBL_GiangVien>()
                .Property(e => e.MaGiangVien)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TBL_GiangVien>()
                .Property(e => e.SDT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TBL_GiangVien>()
                .Property(e => e.MaChucVu)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TBL_GiangVien>()
                .Property(e => e.MaKhoa)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TBL_GiangVien>()
                .Property(e => e.MaBoMon)
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

            modelBuilder.Entity<TBL_HocKy>()
                .Property(e => e.MaHocKy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TBL_Khoa>()
                .Property(e => e.MaKhoa)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TBL_Khoa>()
                .HasMany(e => e.TBL_GiangVien)
                .WithRequired(e => e.TBL_Khoa)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TBL_Khoa>()
                .HasMany(e => e.TBL_Lop)
                .WithRequired(e => e.TBL_Khoa)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TBL_Lop>()
                .Property(e => e.MaLop)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TBL_Lop>()
                .Property(e => e.MaKhoa)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TBL_Lop>()
                .Property(e => e.MaChuyenNganh)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TBL_Lop>()
                .HasMany(e => e.TBL_ChiTietThoiKhoaBieu)
                .WithRequired(e => e.TBL_Lop)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TBL_Lop>()
                .HasMany(e => e.TBL_PhanCongDay)
                .WithRequired(e => e.TBL_Lop)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TBL_MonHoc>()
                .Property(e => e.MaMonHoc)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TBL_MonHoc>()
                .Property(e => e.MaChuyenNganh)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TBL_MonHoc>()
                .HasMany(e => e.TBL_PhanCongDay)
                .WithRequired(e => e.TBL_MonHoc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TBL_PhanCongDay>()
                .Property(e => e.MaPhanCong)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TBL_PhanCongDay>()
                .Property(e => e.MaGiangVien)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TBL_PhanCongDay>()
                .Property(e => e.MaMonHoc)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TBL_PhanCongDay>()
                .Property(e => e.MaLop)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TBL_PhanCongDay>()
                .Property(e => e.MaHocKy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TBL_PhongHoc>()
                .Property(e => e.MaPhong)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TBL_TaiKhoan>()
                .Property(e => e.MatKhau)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TBL_TaiKhoan>()
                .Property(e => e.MaGiangVien)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TBL_ThoiKhoaBieuGiangVien>()
                .Property(e => e.MaTKB)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TBL_ThoiKhoaBieuGiangVien>()
                .Property(e => e.MaGiangVien)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TBL_ThoiKhoaBieuGiangVien>()
                .Property(e => e.MaMonHoc)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TBL_ThoiKhoaBieuGiangVien>()
                .HasMany(e => e.TBL_ChiTietThoiKhoaBieu)
                .WithRequired(e => e.TBL_ThoiKhoaBieuGiangVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TBL_TietHoc>()
                .Property(e => e.MaTiet)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TBL_TietHoc>()
                .HasMany(e => e.TBL_ChiTietThoiKhoaBieu)
                .WithRequired(e => e.TBL_TietHoc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TBL_TinTuc>()
                .Property(e => e.MaTin)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
