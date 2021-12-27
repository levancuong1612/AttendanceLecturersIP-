namespace CSDL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_ChiTietCTK
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long MaCTK { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long MaMonHoc { get; set; }

        [StringLength(50)]
        public string TrangThai { get; set; }

        public virtual TBL_ChuongTrinhKhung TBL_ChuongTrinhKhung { get; set; }

        public virtual TBL_MonHoc TBL_MonHoc { get; set; }
    }
}
