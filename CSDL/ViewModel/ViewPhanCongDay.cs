using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDL.ViewModel
{
  public  class ViewPhanCongDay
    {
        public long? MaPhanCong { get; set; }
        public long? MaGiangVien { get; set; }
        public string TenGiangVien { get; set; }
        public long? MaMonHoc { get; set; }
        public string TenMonHoc { get; set; }
        public long? MaLop { get; set; }
        public string TenLop { get; set; }
        public long? MaHocKy { get; set; }
        public string TenHocKy { get; set; }
        public long? MaCTK { get; set; }
        public string GV_MH_LOP { get; set; }
    }
}
