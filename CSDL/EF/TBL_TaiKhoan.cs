namespace CSDL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_TaiKhoan
    {
        public long id { get; set; }

        [Required]
        [StringLength(30)]
        public string TaiKhoan { get; set; }

        [Required]
        [StringLength(50)]
        public string MatKhau { get; set; }

        public long MaGiangVien { get; set; }

        [StringLength(20)]
        public string Quyen { get; set; }

        public virtual TBL_GiangVien TBL_GiangVien { get; set; }
    }
}
