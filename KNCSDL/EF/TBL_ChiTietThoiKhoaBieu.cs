namespace KNCSDL.EF
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
        [StringLength(10)]
        public string MaCTTKB { get; set; }

        [Required]
        [StringLength(10)]
        public string MaTKB { get; set; }

        [StringLength(20)]
        public string Tuan { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Ngay { get; set; }

        [Required]
        [StringLength(10)]
        public string MaLop { get; set; }

        [StringLength(20)]
        public string Thu { get; set; }

        [StringLength(50)]
        public string Buoi { get; set; }

        [Required]
        [StringLength(10)]
        public string MaTiet { get; set; }

        [Required]
        [StringLength(10)]
        public string MaPhong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_ChiTietDiemDanh> TBL_ChiTietDiemDanh { get; set; }

        public virtual TBL_Lop TBL_Lop { get; set; }

        public virtual TBL_PhongHoc TBL_PhongHoc { get; set; }

        public virtual TBL_ThoiKhoaBieuGiangVien TBL_ThoiKhoaBieuGiangVien { get; set; }

        public virtual TBL_TietHoc TBL_TietHoc { get; set; }
    }
}
