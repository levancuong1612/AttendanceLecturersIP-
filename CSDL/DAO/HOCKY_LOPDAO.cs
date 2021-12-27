using CSDL.EF;
using CSDL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDL.DAO
{
  public  class HOCKY_LOPDAO
    {
        QLGVDBContext db = null;
        public HOCKY_LOPDAO()
        {
            db = new QLGVDBContext();
        }
        //Thêm Lớp
        public bool InsertLop(TBL_Lop info)
        {
            try
            {
                db.TBL_Lop.Add(info);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //chỉnh sửa lớp
        public bool Update(TBL_Lop lop, long mk)
        {
            var kh = db.TBL_Lop.Find(mk);

            kh.TenLop = lop.TenLop;
            kh.SoLuong = lop.SoLuong;
            kh.MaChuyenNganh = lop.MaChuyenNganh;
            kh.MaKhoa = lop.MaKhoa;
            db.SaveChanges();
            return true;
        }

        public TBL_Lop ViewDetail(long mamonhoc)
        {
            return db.TBL_Lop.Find(mamonhoc);
        }
        //XÓa lớp
        public bool Delete(int id)
        {
            try
            {
                var gv = db.TBL_Lop.Find(id);
                db.TBL_Lop.Remove(gv);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<TBL_HocKy> getAllListHK()
        {
            return db.TBL_HocKy.ToList();
        }
        public List<ViewLop> getAllListLop(string searchString)
        {


            List<ViewLop> list = new List<ViewLop>();
            List<ViewLop> list2 = new List<ViewLop>();
            var data = from q in db.TBL_Lop
                       select q;
            foreach (var a in data)
            {
               ViewLop v = new ViewLop();
                v.MaLop = a.MaLop;
                v.TenLop = a.TenLop;
                v.SoLuong = a.SoLuong;
            
                v.MaKhoa = a.MaKhoa;
                var datacv = from q in db.TBL_Khoa
                             where q.MaKhoa == a.MaKhoa
                             select q;
                v.TenKhoa = datacv.First().TenKhoa;
               
             
                v.MaChuyenNganh = a.MaChuyenNganh;
                var databomon = from q in db.TBL_ChuyenNganh
                                where q.MaChuyenNganh == a.MaChuyenNganh
                                select q;
                v.TenChuyenNganh = databomon.First().TenChuyenNganh;
           
                list.Add(v);
            }
            int i = 0;
            if (!string.IsNullOrEmpty(searchString))
            {
                foreach (var item in list)
                {
                    if (item.TenLop == searchString || item.TenChuyenNganh == searchString || item.TenKhoa == searchString)
                    {
                        list2.Add(item);
                        i++;
                    }
                }

            }

            if (i != 0)
            {
                return list2.ToList();
            }
            else
            {
                return list.ToList();
            }

        }

    }
}
