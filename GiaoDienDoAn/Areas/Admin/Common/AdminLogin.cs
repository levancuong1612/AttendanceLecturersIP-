using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GiaoDienDoAn.Areas.Admin.Common
{
    [Serializable]//mã hóa

    public class AdminLogin
    {
        public long ID { get; set; }
        public string TaiKhoan { get; set; }
        public string HinhAnh { get; set; }
    }
}