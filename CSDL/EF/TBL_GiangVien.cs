namespace CSDL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_GiangVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_GiangVien()
        {
            TBL_ChiTietDiemDanh = new HashSet<TBL_ChiTietDiemDanh>();
            TBL_DiemDanh = new HashSet<TBL_DiemDanh>();
            TBL_PhanCongDay = new HashSet<TBL_PhanCongDay>();
            TBL_ThoiKhoaBieuGiangVien = new HashSet<TBL_ThoiKhoaBieuGiangVien>();
            TBL_TaiKhoan = new HashSet<TBL_TaiKhoan>();
        }

        [Key]
        public long MaGiangVien { get; set; }

        [StringLength(50)]
        public string TenGiangVien { get; set; }

        [StringLength(3)]
        public string GioiTinh { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgaySinh { get; set; }

        [StringLength(100)]
        public string DiaChi { get; set; }

        [StringLength(10)]
        public string SDT { get; set; }

        [Column(TypeName = "ntext")]
        public string HinhAnh { get; set; }

        public long MaChucVu { get; set; }

        public long MaKhoa { get; set; }

        public long MaBoMon { get; set; }

        [StringLength(20)]
        public string TrangThai { get; set; }

        public virtual TBL_BoMon TBL_BoMon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_ChiTietDiemDanh> TBL_ChiTietDiemDanh { get; set; }

        public virtual TBL_ChucVu TBL_ChucVu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_DiemDanh> TBL_DiemDanh { get; set; }

        public virtual TBL_Khoa TBL_Khoa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_PhanCongDay> TBL_PhanCongDay { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_ThoiKhoaBieuGiangVien> TBL_ThoiKhoaBieuGiangVien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_TaiKhoan> TBL_TaiKhoan { get; set; }
    }
}
