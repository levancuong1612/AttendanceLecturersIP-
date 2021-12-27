using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDL.ViewModel
{
   public class ViewDiemDanh
    {
        public long? MaDiemDanh { get; set; }
        public long? MaGiangVien { get; set; }
        public string TenGiangVien { get; set; }
        public long? MaHocKy { get; set; }
        public string TenHocKy { get; set; }
        public int SoLopPhanCong { get; set; }
        public int SoBuoiPhanCong { get; set; }
       
        public int SoTietPhanCong { get; set; }

        public int SoTietHoanThanh { get; set; }
        public int SoGioHoanThanh { get; set; }
        public int SoBuoiDay { get; set; }
        public int SoBuoiNghi { get; set; }
    }
}
