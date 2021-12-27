using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDL.ViewModel
{
  public  class ViewBoMon_ChuyenNganh
    {

        public long MaChuyenNganh { get; set; }
        public string TenChuyenNganh { get; set; }
        public long MaMonHoc { get; set; }
        public string TenMonHoc { get; set; }
        public int? SoTinChi { get; set; }
       
        public string Loai { get; set; }
    }
}
