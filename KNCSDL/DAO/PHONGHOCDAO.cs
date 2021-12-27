using KNCSDL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNCSDL.DAO
{
    
    class PHONGHOCDAO
    {
        QLGVDBContext db = null;
        public PHONGHOCDAO()
        {
            db = new QLGVDBContext();
        }
        public string Insert(TBL_PhongHoc info)
        {
            db.TBL_PhongHoc.Add(info);
            db.SaveChanges();
            return info.MaPhong;

        }
        public TBL_PhongHoc getbyID(string maphong)
        {

            return db.TBL_PhongHoc.SingleOrDefault(x => x.MaPhong == maphong);
        }
    }
  
}
