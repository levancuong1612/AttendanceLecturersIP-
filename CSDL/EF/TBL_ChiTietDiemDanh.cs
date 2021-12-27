namespace CSDL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_ChiTietDiemDanh
    {
        [Key]
        public long MaCTDD { get; set; }

        public long MaDiemDanh { get; set; }

        public long MaCTTKB { get; set; }

        public long MaGiangVien { get; set; }

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
