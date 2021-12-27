namespace CSDL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_DiemDanh
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_DiemDanh()
        {
            TBL_ChiTietDiemDanh = new HashSet<TBL_ChiTietDiemDanh>();
        }

        [Key]
        public long MaDiemDanh { get; set; }

        public long MaGiangVien { get; set; }

        public long MaHocKy { get; set; }

        public int? SoNgayDay { get; set; }

        public int? SoNgayNghi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_ChiTietDiemDanh> TBL_ChiTietDiemDanh { get; set; }

        public virtual TBL_GiangVien TBL_GiangVien { get; set; }

        public virtual TBL_HocKy TBL_HocKy { get; set; }
    }
}
