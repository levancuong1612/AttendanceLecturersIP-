using CSDL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDL.DAO
{
   public class CHUCVUDAO
    {
        QLGVDBContext db = null;
        public CHUCVUDAO()
        {
            db = new QLGVDBContext();
        }
        public List<TBL_ChucVu> getalllist()
        {
            return db.TBL_ChucVu.ToList();
        }
        public List<TBL_BoMon> getlistbomon()
        {
            return db.TBL_BoMon.ToList();
        }
    }
}
