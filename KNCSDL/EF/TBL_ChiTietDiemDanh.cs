namespace KNCSDL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_ChiTietDiemDanh
    {
        [Key]
        public int MaCTDD { get; set; }

        [Required]
        [StringLength(10)]
        public string MaDiemDanh { get; set; }

        [Required]
        [StringLength(10)]
        public string MaCTTKB { get; set; }

        [Required]
        [StringLength(10)]
        public string MaGiangVien { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Ngay { get; set; }

        public TimeSpan? Gio { get; set; }

        [StringLength(50)]
        public string DiaChiIP { get; set; }

        public virtual TBL_ChiTietThoiKhoaBieu TBL_ChiTietThoiKhoaBieu { get; set; }

        public virtual TBL_DiemDanh TBL_DiemDanh { get; set; }

        public virtual TBL_GiangVien TBL_GiangVien { get; set; }
    }
}
