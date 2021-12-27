namespace KNCSDL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_PhanCongDay
    {
        [Key]
        [StringLength(10)]
        public string MaPhanCong { get; set; }

        [Required]
        [StringLength(10)]
        public string MaGiangVien { get; set; }

        [Required]
        [StringLength(10)]
        public string MaMonHoc { get; set; }

        [Required]
        [StringLength(10)]
        public string MaLop { get; set; }

        [Required]
        [StringLength(10)]
        public string MaHocKy { get; set; }

        public virtual TBL_GiangVien TBL_GiangVien { get; set; }

        public virtual TBL_HocKy TBL_HocKy { get; set; }

        public virtual TBL_Lop TBL_Lop { get; set; }

        public virtual TBL_MonHoc TBL_MonHoc { get; set; }
    }
}
