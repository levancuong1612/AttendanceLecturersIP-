using CSDL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDL.DAO
{
   public class PHONGHOCDAO
    {
        QLGVDBContext db = null;
        public PHONGHOCDAO()
        {
            db = new QLGVDBContext();
        }
        public bool Insert(TBL_PhongHoc info)
        {
            try
            {

                info.TrangThai = "Đang Hoạt Động";
                db.TBL_PhongHoc.Add(info);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
            

        }
        public bool Update(TBL_PhongHoc info,long mk)
        {
            var ph = db.TBL_PhongHoc.Find(mk);
            ph.TenPhong = info.TenPhong;
            ph.LoaiPhong = info.LoaiPhong;
            ph.ViTri = info.ViTri;
            ph.TrangThai = info.TrangThai;
            db.SaveChanges();
            return true;
        }
        public TBL_PhongHoc ViewDetail(long maphong)
        {
            return db.TBL_PhongHoc.Find(maphong);
        }
        public TBL_PhongHoc getbyID(long maphong)
        {

            return db.TBL_PhongHoc.SingleOrDefault(x => x.MaPhong == maphong);
        }

        public List<TBL_PhongHoc> getalllist(string searchString)
        {

            int i = 0;
            if (!string.IsNullOrEmpty(searchString))
            {
                var data = from q in db.TBL_PhongHoc
                           where q.TenPhong == searchString || q.LoaiPhong == searchString
                           select q;
                if(data!=null && data.Count() > 0)
                {
                    i++;
                }    
            }
            if (i != 0)
            {
                return db.TBL_PhongHoc.Where(x => x.TenPhong.Contains(searchString) || x.LoaiPhong.Contains(searchString)).ToList();
            }
            else
            {
                return db.TBL_PhongHoc.ToList();
            }
           
        }

        public bool xoa(int id)
        {
            try
            {
                var gv = db.TBL_PhongHoc.Find(id);
                db.TBL_PhongHoc.Remove(gv);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
