using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDL.ViewModel
{
   public class ViewThoiKhoaBieu
    {
        public long? MaCTTKB { get; set; }
        public string Tuan { get; set; }
        public DateTime? Ngay { get; set; }
        public long? MaLop { get; set; }
        public string TenLop { get; set; }
        public string Thu { get; set; }
        public string Buoi { get; set; }
        public long? MaTiet { get; set; }
        public string TenTiet { get; set; }
        public DateTime ThoiGianBatDau { get; set; }
        public DateTime ThoiGianKetThuc { get; set; }
        public long? MaPhong { get; set; }
        public string TenPhong { get; set; }
        public long? MaPhanCong { get; set; }
        public long? MaGiangVien { get; set; }
        public string TenGiangVien { get; set; }
        public string HinhAnh { get; set; }
        public long? MaMonHoc { get; set; }
        public string TenMonHoc { get; set; }
        public int? PhanTran { get; set; }
        public int? PhanTrantruoc { get; set; }
        public long? ID { get; set; }
        public string TaiKhoan { get; set; }
        public string TrangThai { get; set; }
    }
}
