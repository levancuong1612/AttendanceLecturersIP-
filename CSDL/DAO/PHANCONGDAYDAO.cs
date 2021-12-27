using CSDL.EF;
using CSDL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDL.DAO
{
   public class PHANCONGDAYDAO
    {
        QLGVDBContext db = null;
        public PHANCONGDAYDAO()
        {
            db = new QLGVDBContext();
        }
        public bool Insert(TBL_PhanCongDay info)
        {
            try
            {
                int x = 0;
                var data = from q in db.TBL_PhanCongDay
                           select q;
                if(data!=null && data.Count() > 0)
                {
                    foreach(var item in data.ToList())
                    {
                        if(info.MaGiangVien==item.MaGiangVien && info.MaMonHoc==item.MaMonHoc && info.MaLop==item.MaLop && info.MaHocKy == item.MaHocKy)
                        {
                            x++;
                        }
                    }
                }
                if (x != 0)
                {
                    return false;
                }
                else
                {
                    db.TBL_PhanCongDay.Add(info);
                    db.SaveChanges();
                    return true;
                }
                
            }
            catch
            {
                return false;
            }
            
        }
        public bool Update(TBL_PhanCongDay info, long mk)
        {
            int x = 0;
            var data = from q in db.TBL_PhanCongDay
                       select q;
            if (data != null && data.Count() > 0)
            {
                foreach (var item in data.ToList())
                {
                    if (info.MaGiangVien == item.MaGiangVien && info.MaMonHoc == item.MaMonHoc && info.MaLop == item.MaLop && info.MaHocKy == item.MaHocKy)
                    {
                        x++;
                    }
                }
            }
            if (x != 0)
            {
                return false;
            }
            else
            {
                var ph = db.TBL_PhanCongDay.Find(mk);
                ph.MaGiangVien = info.MaGiangVien;
                ph.MaMonHoc = info.MaMonHoc;
                ph.MaLop = info.MaLop;
                ph.MaHocKy = info.MaHocKy;
                db.SaveChanges();
                return true;
            }
        }
        public TBL_PhanCongDay ViewDetail(long magv)
        {
            return db.TBL_PhanCongDay.Find(magv);
        }


        public bool Delete(int id)
        {
            try
            {
                var gv = db.TBL_PhanCongDay.Find(id);
                db.TBL_PhanCongDay.Remove(gv);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<ViewPhanCongDay> listAllPhanCong(string searchString,string TenHocKy)
        {
            long ma=0;
            try
            {
                ma = Convert.ToInt64(searchString);
            }
            catch
            {

            }
        
            List<ViewPhanCongDay> list = new List<ViewPhanCongDay>();
            List<ViewPhanCongDay> list2 = new List<ViewPhanCongDay>();
            var data = from q in db.TBL_PhanCongDay
                       select q;
            foreach (var a in data)
            {
                ViewPhanCongDay v = new ViewPhanCongDay();
                v.MaPhanCong = a.MaPhanCong;
                v.MaGiangVien = a.MaGiangVien;
            
                var datacv = from q in db.TBL_GiangVien
                             where q.MaGiangVien==a.MaGiangVien
                             select q;
                v.TenGiangVien = datacv.First().TenGiangVien;
                v.MaMonHoc = a.MaMonHoc;
                var datakhoa = from q in db.TBL_MonHoc
                               where q.MaMonHoc == a.MaMonHoc
                               select q;
                v.TenMonHoc = datakhoa.First().TenMonHoc;
                v.MaLop = a.MaLop;
                var databomon = from q in db.TBL_Lop
                                where q.MaLop == a.MaLop
                                select q;
                v.TenLop = databomon.First().TenLop;
                v.MaHocKy = a.MaHocKy;
                var databomonHK = from q in db.TBL_HocKy
                                where q.MaHocKy == a.MaHocKy
                                select q;
                v.TenHocKy = databomonHK.First().TenHocKy;
                v.GV_MH_LOP = datacv.First().TenGiangVien + "-" + databomon.First().TenLop + "-" + datakhoa.First().TenMonHoc;
                list.Add(v);
            }
            int i = 0;
            if (!string.IsNullOrEmpty(searchString)||!string.IsNullOrEmpty(TenHocKy)||searchString!="")
            {
                foreach (var item in list)
                {
                    if (item.TenGiangVien == searchString||item.MaGiangVien==ma||item.MaMonHoc==ma ||item.TenLop == searchString || item.TenMonHoc == searchString || item.TenHocKy== searchString||item.TenHocKy== TenHocKy)
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
