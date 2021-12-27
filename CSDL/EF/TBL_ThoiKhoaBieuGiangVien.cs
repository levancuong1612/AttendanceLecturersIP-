namespace CSDL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_ThoiKhoaBieuGiangVien
    {
        [Key]
        public long MaTKB { get; set; }

        public long MaGiangVien { get; set; }

        public long MaMonHoc { get; set; }

        public virtual TBL_GiangVien TBL_GiangVien { get; set; }

        public virtual TBL_MonHoc TBL_MonHoc { get; set; }
    }
}
