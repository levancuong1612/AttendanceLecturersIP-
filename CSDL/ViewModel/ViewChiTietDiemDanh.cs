using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDL.ViewModel
{
    public class ViewChiTietDiemDanh
    {
        public long? MaCTDD { get; set; }
        public long? MaDiemDanh { get; set; }
        public long? MaCTTKB { get; set; }
        public long? MaLop { get; set; }
        public string TenLop { get; set; }
        public string Thu { get; set; }
        public string Buoi { get; set; }
        public long? MaTiet { get; set; }
        public string TenTiet { get; set; }
        public long? MaGiangVien { get; set; }
        public string TenGiangVien { get; set; }
        public long? MaMonHoc { get; set; }
        public string TenMonHoc { get; set; }
        public DateTime? Ngay { get; set; }
        public string Gio { get; set; }
        public string IP { get; set; }
        public int? ChiTieu { get; set; }
        public int? Online { get; set; }
        public int? Ofline { get; set; }
        public string TrangThai { get; set; }
    }
}
