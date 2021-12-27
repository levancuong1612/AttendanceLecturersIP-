namespace KNCSDL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_TaiKhoan
    {
        [Key]
        [StringLength(50)]
        public string TenTaiKhoan { get; set; }

        [Required]
        [StringLength(50)]
        public string MatKhau { get; set; }

        [StringLength(20)]
        public string Quyen { get; set; }

        [StringLength(10)]
        public string MaGiangVien { get; set; }

        public virtual TBL_GiangVien TBL_GiangVien { get; set; }
    }
}
