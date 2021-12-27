namespace CSDL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_ChiTietThoiKhoaBieu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_ChiTietThoiKhoaBieu()
        {
            TBL_ChiTietDiemDanh = new HashSet<TBL_ChiTietDiemDanh>();
        }

        [Key]
        public long MaCTTKB { get; set; }

        [StringLength(20)]
        public string Tuan { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Ngay { get; set; }

        public long MaLop { get; set; }

        [StringLength(20)]
        public string Thu { get; set; }

        [StringLength(50)]
        public string Buoi { get; set; }

        public long MaTiet { get; set; }

        public long MaPhong { get; set; }

        public long MaPhanCong { get; set; }

        [StringLength(20)]
        public string TrangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_ChiTietDiemDanh> TBL_ChiTietDiemDanh { get; set; }

        public virtual TBL_Lop TBL_Lop { get; set; }

        public virtual TBL_PhongHoc TBL_PhongHoc { get; set; }

        public virtual TBL_TietHoc TBL_TietHoc { get; set; }

        public virtual TBL_PhanCongDay TBL_PhanCongDay { get; set; }
    }
}
