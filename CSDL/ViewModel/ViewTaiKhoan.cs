using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDL.ViewModel
{
   public class ViewTaiKhoan
    {
        public long? id { get; set; }
        public long? MaGiangVien { get; set; }
        public string TenGiangVien { get; set; }
        public string HinhAnh { get; set; }
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public string Quyen { get; set; }
    }
}
