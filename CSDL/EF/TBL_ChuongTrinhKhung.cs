namespace CSDL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_ChuongTrinhKhung
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_ChuongTrinhKhung()
        {
            TBL_ChiTietCTK = new HashSet<TBL_ChiTietCTK>();
        }

        [Key]
        public long MaCTK { get; set; }

        public long MaLop { get; set; }

        public long MaHocKy { get; set; }

        [StringLength(40)]
        public string TrangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_ChiTietCTK> TBL_ChiTietCTK { get; set; }

        public virtual TBL_HocKy TBL_HocKy { get; set; }

        public virtual TBL_Lop TBL_Lop { get; set; }
    }
}
