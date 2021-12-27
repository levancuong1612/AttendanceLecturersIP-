using CSDL.EF;
using CSDL.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDL.DAO
{
  public  class GIANGVIENDAO
    {
        QLGVDBContext db = null;
        public GIANGVIENDAO()
        {
            db = new QLGVDBContext();
        }
       public bool Insert(TBL_GiangVien info,string filename)
        {
          
                info.HinhAnh = filename;
            
                db.TBL_GiangVien.Add(info);
                db.SaveChanges();
                return true;

            
        }
        public List<ViewGiangVien> listallGV(string searchString)
        {
            
            List<ViewGiangVien> list = new List<ViewGiangVien>();
            List<ViewGiangVien> list2 = new List<ViewGiangVien>();
            var data = from q in db.TBL_GiangVien
                       select q;
            foreach(var a in data)
            {
                ViewGiangVien v = new ViewGiangVien();
                v.MaGV = a.MaGiangVien;
                v.TenGiangVien = a.TenGiangVien;
                v.GioiTinh = a.GioiTinh;
                v.NgaySinh =Convert.ToDateTime( a.NgaySinh);
                v.DiaChi = a.DiaChi;
                v.SDT = a.SDT;
                v.HinhAnh = a.HinhAnh;
                v.MaChucVu = a.MaChucVu;
                var datacv = from q in db.TBL_ChucVu
                             where q.MaChucVu == a.MaChucVu
                             select q;
                v.TenChucVu = datacv.First().TenChucVu;
                v.MaKhoa = a.MaKhoa;
                var datakhoa = from q in db.TBL_Khoa
                               where q.MaKhoa == a.MaKhoa
                               select q;
                v.TenKhoa = datakhoa.First().TenKhoa;
                v.MaBoMon = a.MaBoMon;
                var databomon = from q in db.TBL_BoMon
                                where q.MaBoMon == a.MaBoMon
                                select q;
                v.TenBoMon = databomon.First().TenBoMon;
                v.TrangThai = a.TrangThai;
                list.Add(v);
            }
            int i = 0;
            if (!string.IsNullOrEmpty(searchString))
            {
                foreach (var item in list)
                {
                    if (item.TenGiangVien == searchString|| item.TenChucVu ==searchString|| item.TenKhoa == searchString )
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
        public ViewGiangVien chinhSua(int id)
        {
            ViewGiangVien info = new ViewGiangVien();
            var data = from q in db.TBL_GiangVien
                       where q.MaGiangVien == id
                       select q;
            var a = data.First();
                ViewGiangVien v = new ViewGiangVien();
                v.MaGV = a.MaGiangVien;
                v.TenGiangVien = a.TenGiangVien;
                v.GioiTinh = a.GioiTinh;
                v.NgaySinh = Convert.ToDateTime(a.NgaySinh);
                v.DiaChi = a.DiaChi;
                v.SDT = a.SDT;
                v.HinhAnh = a.HinhAnh;
                v.MaChucVu = a.MaChucVu;
                var datacv = from q in db.TBL_ChucVu
                             where q.MaChucVu == a.MaChucVu
                             select q;
                v.TenChucVu = datacv.First().TenChucVu;
                v.MaKhoa = a.MaKhoa;
                var datakhoa = from q in db.TBL_Khoa
                               where q.MaKhoa == a.MaKhoa
                               select q;
                v.TenKhoa = datakhoa.First().TenKhoa;
                v.MaBoMon = a.MaBoMon;
                var databomon = from q in db.TBL_BoMon
                                where q.MaBoMon == a.MaBoMon
                                select q;
                v.TenBoMon = databomon.First().TenBoMon;
                v.TrangThai = a.TrangThai;
                info = v;
            
            return info;
        }
        public bool xoa(int id)
        {
            try
            {
                var gv = db.TBL_GiangVien.Find(id);
                db.TBL_GiangVien.Remove(gv);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Update(TBL_GiangVien info, long mk,string filename)
        {
            var ph = db.TBL_GiangVien.Find(mk);
            ph.TenGiangVien = info.TenGiangVien;
            ph.GioiTinh = info.GioiTinh;
            ph.NgaySinh = info.NgaySinh;
            ph.DiaChi = info.DiaChi;
            ph.SDT = info.SDT;
            ph.HinhAnh = filename;
            ph.MaChucVu = info.MaChucVu;
            ph.MaKhoa = info.MaKhoa;
            ph.MaBoMon = info.MaBoMon;
            ph.TrangThai = info.TrangThai;
            db.SaveChanges();
            return true;
        }
        public TBL_GiangVien ViewDetail(long magv)
        {
            return db.TBL_GiangVien.Find(magv);
        }
    }
}
