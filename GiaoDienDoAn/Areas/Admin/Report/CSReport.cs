using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GiaoDienDoAn.Areas.Admin.Report
{
    public class CSReport
    {
        public long? MaDiemDanh { get; set; }
        public long? MaGiangVien { get; set; }
        public string TenGiangVien { get; set; }
        public long? MaHocKy { get; set; }
        public string TenHocKy { get; set; }
        public int? SoNgayNghi { get; set; }
        public int? SoNgayDay { get; set; }
    }
}