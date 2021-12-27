namespace CSDL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_PhanCongDay
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_PhanCongDay()
        {
            TBL_ChiTietThoiKhoaBieu = new HashSet<TBL_ChiTietThoiKhoaBieu>();
        }

        [Key]
        public long MaPhanCong { get; set; }

        public long MaGiangVien { get; set; }

        public long MaMonHoc { get; set; }

        public long MaLop { get; set; }

        public long MaHocKy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_ChiTietThoiKhoaBieu> TBL_ChiTietThoiKhoaBieu { get; set; }

        public virtual TBL_GiangVien TBL_GiangVien { get; set; }

        public virtual TBL_HocKy TBL_HocKy { get; set; }

        public virtual TBL_Lop TBL_Lop { get; set; }

        public virtual TBL_MonHoc TBL_MonHoc { get; set; }
    }
}
