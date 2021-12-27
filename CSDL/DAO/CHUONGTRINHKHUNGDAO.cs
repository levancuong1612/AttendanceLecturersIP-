using CSDL.EF;
using CSDL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDL.DAO
{
  public  class CHUONGTRINHKHUNGDAO
    {
        QLGVDBContext db = null;
        public CHUONGTRINHKHUNGDAO()
        {
            db = new QLGVDBContext();
        }
        public List<ViewCTCTK>listCTK (long? maCTK)
        {
            List<ViewCTCTK> list = new List<ViewCTCTK>();
            var data = from q in db.TBL_ChiTietCTK
                       where q.MaCTK == maCTK
                       select q;
            foreach(var a in data)
            {
                ViewCTCTK ct = new ViewCTCTK();
                ct.MaCTK = a.MaCTK;
                ct.MaMonHoc = a.MaMonHoc;
                var dtMH = from q in db.TBL_MonHoc
                           where q.MaMonHoc == a.MaMonHoc
                           select q;
                ct.TenMonHoc = dtMH.First().TenMonHoc;
                ct.TrangThai = a.TrangThai;
                list.Add(ct);
            }
            return list.ToList();
        }
        public List<ViewChuongTrinhKhung> listallGV(long? maLop)
        {

            List<ViewChuongTrinhKhung> list = new List<ViewChuongTrinhKhung>();
            List<ViewChuongTrinhKhung> list2 = new List<ViewChuongTrinhKhung>();
            var data = from q in db.TBL_ChuongTrinhKhung
                       select q;
            foreach (var a in data)
            {
                ViewChuongTrinhKhung v = new ViewChuongTrinhKhung();
                v.MaCTK = a.MaCTK;
                v.MaHocKy = a.MaHocKy;
                
                var datacv = from q in db.TBL_HocKy
                             where q.MaHocKy == a.MaHocKy
                             select q;
                v.TenHocKy = datacv.First().TenHocKy;
                v.MaLop = a.MaLop;

                var datakhoa = from q in db.TBL_Lop
                               where q.MaLop == a.MaLop
                               select q;
                v.TenLop = datakhoa.First().TenLop;
                string tenCTK = datakhoa.First().TenLop+"-" + datacv.First().TenHocKy;
                v.TenCTK = tenCTK;
                list.Add(v);
            }
            int i = 0;
            if ( maLop!=0)
            {
                foreach (var item in list)
                {
                    if ( item.MaLop == maLop )
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
