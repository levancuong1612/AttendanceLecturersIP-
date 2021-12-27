using CSDL.EF;
using CSDL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDL.DAO
{
  public  class BOMON_CHUYENNGANHDAO
    {
        QLGVDBContext db = null;
        public BOMON_CHUYENNGANHDAO()
        {
            db = new QLGVDBContext();

        }
       //thêm bộ môn
        public bool InsertBM(TBL_MonHoc info)
        {
            try
            {
                db.TBL_MonHoc.Add(info);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
            
        }
        //thêm chuyên ngành
        public bool InsertCN (TBL_ChuyenNganh info)
        {
            try
            {
                db.TBL_ChuyenNganh.Add(info);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //hiển thị danh sách chuyên ngành
        public List<TBL_ChuyenNganh> getAllListCN(string searchString)
        {

            int i = 0;
            if (!string.IsNullOrEmpty(searchString))
            {
                var data = from q in db.TBL_ChuyenNganh
                           where q.TenChuyenNganh == searchString 
                           select q;
                if (data != null && data.Count() > 0)
                {
                    i++;
                }
            }
            if (i != 0)
            {
                return db.TBL_ChuyenNganh.Where(x => x.TenChuyenNganh.Contains(searchString)).ToList();
            }
            else
            {
                return db.TBL_ChuyenNganh.ToList();
            }

        }

        public List<TBL_MonHoc> getAllListBM(string searchString)
        {

            int i = 0;
            if (!string.IsNullOrEmpty(searchString))
            {
                var data = from q in db.TBL_MonHoc
                           where q.TenMonHoc == searchString
                           select q;
                if (data != null && data.Count() > 0)
                {
                    i++;
                }
            }
            if (i != 0)
            {
                return db.TBL_MonHoc.Where(x => x.TenMonHoc.Contains(searchString)).ToList();
            }
            else
            {
                return db.TBL_MonHoc.ToList();
            }

        }
        //Chỉnh sửa môn học
        public bool Update(TBL_MonHoc monhoc, long mk)
        {
            var kh = db.TBL_MonHoc.Find(mk);

            kh.TenMonHoc = monhoc.TenMonHoc;
            kh.SoTinChi = monhoc.SoTinChi;
            kh.MaChuyenNganh = monhoc.MaChuyenNganh;
            kh.Loai = monhoc.Loai;
            db.SaveChanges();
            return true;
        }

        public TBL_MonHoc ViewDetail(long mamonhoc)
        {
            return db.TBL_MonHoc.Find(mamonhoc);
        }
        //Xóa môn học
        public bool Delete(int id)
        {
            try
            {
                var gv = db.TBL_MonHoc.Find(id);
                db.TBL_MonHoc.Remove(gv);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //Xóa chuyên ngành

        public bool DeleteCN(int id)
        {
            try
            {
                var gv = db.TBL_ChuyenNganh.Find(id);
                db.TBL_ChuyenNganh.Remove(gv);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //load danh sách
        public List<ViewBoMon_ChuyenNganh> getAllList(string searchString)
        {
            int i = 0;
            if (!string.IsNullOrEmpty(searchString))
            {
                var model = from q in db.TBL_MonHoc
                            join p in db.TBL_ChuyenNganh
                            on q.MaChuyenNganh equals p.MaChuyenNganh
                            where q.TenMonHoc == searchString || p.TenChuyenNganh == searchString
                            select new ViewBoMon_ChuyenNganh()
                            {
                                MaChuyenNganh = p.MaChuyenNganh,
                                TenChuyenNganh = p.TenChuyenNganh,
                                MaMonHoc = q.MaMonHoc,
                                TenMonHoc = q.TenMonHoc,
                                SoTinChi =  q.SoTinChi,
                                Loai = q.Loai

                                
                            };
                if (model != null && model.Count() > 0)
                {
                    i++;
                }
            }
            if (i != 0)
            {
                var model = from q in db.TBL_MonHoc
                            join p in db.TBL_ChuyenNganh
                            on q.MaChuyenNganh equals p.MaChuyenNganh
                            where q.TenMonHoc == searchString || p.TenChuyenNganh == searchString
                            select new ViewBoMon_ChuyenNganh()
                            {
                                MaChuyenNganh = p.MaChuyenNganh,
                                TenChuyenNganh = p.TenChuyenNganh,
                                MaMonHoc = q.MaMonHoc,
                                TenMonHoc = q.TenMonHoc,
                                SoTinChi = q.SoTinChi,
                                Loai = q.Loai


                            };
                return model.ToList();
            }
            else
            {
                var model = from q in db.TBL_MonHoc
                            join p in db.TBL_ChuyenNganh
                            on q.MaChuyenNganh equals p.MaChuyenNganh
                         
                            select new ViewBoMon_ChuyenNganh()
                            {
                                MaChuyenNganh = p.MaChuyenNganh,
                                TenChuyenNganh = p.TenChuyenNganh,
                                MaMonHoc = q.MaMonHoc,
                                TenMonHoc = q.TenMonHoc,
                                SoTinChi = q.SoTinChi,
                                Loai = q.Loai


                            };
                return model.ToList();
            }
        }
    }
}
