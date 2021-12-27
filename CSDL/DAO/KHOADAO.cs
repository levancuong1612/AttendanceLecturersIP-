using CSDL.EF;
using CSDL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDL.DAO
{
  public class KHOADAO
    {
         QLGVDBContext db = null;
        public static List<TBL_PhongHoc> list = new List<TBL_PhongHoc>();
        public KHOADAO()
        {
            
            db = new QLGVDBContext();
        }
        public bool Insert(TBL_Khoa info)
        {
            try
            {        
                db.TBL_Khoa.Add(info);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Update(TBL_Khoa khoa,long mk)
        { 
            var kh = db.TBL_Khoa.Find(mk);
            string x = khoa.TenKhoa;
            kh.TenKhoa = khoa.TenKhoa;
            kh.MaPhong = khoa.MaPhong;
            db.SaveChanges();
            return true;
        }
        public TBL_Khoa ViewDetail(long MaKhoa)
        {
            return db.TBL_Khoa.Find(MaKhoa);
        }
        public TBL_Khoa getbyID(long makhoa)
        {

            return db.TBL_Khoa.SingleOrDefault(x => x.MaKhoa == makhoa);
        }
        public List<ViewKhoa> getalllist(string searchString)
        {
            int i = 0;
            if (!string.IsNullOrEmpty(searchString))
            {
                var model = from q in db.TBL_Khoa
                            join p in db.TBL_PhongHoc
                            on q.MaPhong equals p.MaPhong
                            where q.TenKhoa == searchString || p.TenPhong == searchString
                            select new ViewKhoa()
                            {
                                MaKhoa = q.MaKhoa,
                                TenKhoa = q.TenKhoa,
                                MaPhong = p.MaPhong,
                                TenPhong = p.TenPhong
                            };
                if(model!=null && model.Count() > 0)
                {
                    i++;
                }
            }
            if (i != 0)
            {
                var model = from q in db.TBL_Khoa
                            join p in db.TBL_PhongHoc
                            on q.MaPhong equals p.MaPhong
                            where q.TenKhoa == searchString || p.TenPhong == searchString
                            select new ViewKhoa()
                            {
                                MaKhoa = q.MaKhoa,
                                TenKhoa = q.TenKhoa,
                                MaPhong = p.MaPhong,
                                TenPhong = p.TenPhong
                            };
                return model.ToList();
            }
            else
            {
                var model = from q in db.TBL_Khoa
                            join p in db.TBL_PhongHoc
                            on q.MaPhong equals p.MaPhong
                            select new ViewKhoa()
                            {
                                MaKhoa = q.MaKhoa,
                                TenKhoa = q.TenKhoa,
                                MaPhong = p.MaPhong,
                                TenPhong = p.TenPhong
                            };
                return model.ToList();
            }
        }
        public bool xoa(int id)
        {
            try
            {
                var gv = db.TBL_Khoa.Find(id);
                db.TBL_Khoa.Remove(gv);
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
