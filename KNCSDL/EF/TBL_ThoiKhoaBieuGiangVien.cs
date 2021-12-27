namespace KNCSDL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_ThoiKhoaBieuGiangVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_ThoiKhoaBieuGiangVien()
        {
            TBL_ChiTietThoiKhoaBieu = new HashSet<TBL_ChiTietThoiKhoaBieu>();
        }

        [Key]
        [StringLength(10)]
        public string MaTKB { get; set; }

        [Required]
        [StringLength(10)]
        public string MaGiangVien { get; set; }

        [Required]
        [StringLength(10)]
        public string MaMonHoc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_ChiTietThoiKhoaBieu> TBL_ChiTietThoiKhoaBieu { get; set; }

        public virtual TBL_GiangVien TBL_GiangVien { get; set; }

        public virtual TBL_MonHoc TBL_MonHoc { get; set; }
    }
}
