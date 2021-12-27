using CSDL.EF;
using CSDL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDL.DAO
{
    public class TAIKHOANDAO
    {
        QLGVDBContext db = null;
        public TAIKHOANDAO()
        {
            db = new QLGVDBContext();
        }
        public bool Login(String UserName, string PassWord)
        {
            var res = db.TBL_TaiKhoan.Count(x => x.TaiKhoan == UserName && x.MatKhau == PassWord && x.Quyen == "Admin");
            if (res > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool LoginUser(string TaiKhoan, string MatKhau)
        {
            var res = db.TBL_TaiKhoan.Count(x => x.TaiKhoan == TaiKhoan && x.MatKhau == MatKhau && x.Quyen == "User");
            if (res > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<ViewTaiKhoan> listAllTaiKhoan()
        {
            List<ViewTaiKhoan> list = new List<ViewTaiKhoan>();
            var data = db.TBL_TaiKhoan.ToList();
            foreach(var item in data)
            {
                ViewTaiKhoan v1 = new ViewTaiKhoan();
                v1.id = item.id;
                v1.MaGiangVien = item.MaGiangVien;
                var gv = db.TBL_GiangVien.Find(item.MaGiangVien);
                v1.TenGiangVien = gv.TenGiangVien;
                v1.HinhAnh = gv.HinhAnh;
                v1.TaiKhoan = item.TaiKhoan;
                v1.MatKhau = item.MatKhau;
                v1.Quyen = item.Quyen;
                list.Add(v1);
            }
            return list;
        }

        public List<ViewThoiKhoaBieu> getView(string tk)
        {

            var tkk = db.TBL_TaiKhoan.SingleOrDefault(x => x.TaiKhoan.Trim().ToString() == tk);
            long maGV = 0;
            if (tkk != null)
            {
                maGV = tkk.MaGiangVien;
                tkh = tkk.TaiKhoan;
                idd = tkk.id;
            }

            List<ViewThoiKhoaBieu> v = new List<ViewThoiKhoaBieu>();
            DateTime dt = DateTime.Now;
            var datatkb = from q in db.TBL_ChiTietThoiKhoaBieu
                          join p in db.TBL_PhanCongDay
                          on q.MaPhanCong equals p.MaPhanCong
                          where p.MaGiangVien == maGV && q.Ngay == dt.Date
                          select q;
            if (datatkb != null && datatkb.Count() > 0)
            {
                foreach (var item in datatkb)
                {
                    ViewThoiKhoaBieu v1 = new ViewThoiKhoaBieu();
                    v1.MaCTTKB = item.MaCTTKB;
                    v1.Ngay = item.Ngay;
                    v1.MaLop = item.MaLop;
                    var dataLop = from q in db.TBL_Lop
                                  where q.MaLop == item.MaLop
                                  select q;
                    v1.TenLop = dataLop.First().TenLop;
                    v1.Thu = item.Thu;
                    v1.Buoi = item.Buoi;
                    v1.Tuan = item.Tuan;
                    v1.MaTiet = item.MaTiet;
                    var dataTietHoc = db.TBL_TietHoc.Find(item.MaTiet);
                    v1.TenTiet = dataTietHoc.Tiet;
                    string tgbd = dataTietHoc.ThoiGianBatDau.ToString();
                    string tgkt = dataTietHoc.ThoiGianKetThuc.ToString();
                    v1.ThoiGianBatDau = Convert.ToDateTime(tgbd);
                    v1.ThoiGianKetThuc = Convert.ToDateTime(tgkt);
                    v1.MaPhong = item.MaPhong;
                    var dataPhong = from q in db.TBL_PhongHoc
                                    where q.MaPhong == item.MaPhong
                                    select q;
                    v1.TenPhong = dataPhong.First().TenPhong;
                    v1.MaPhanCong = item.MaPhanCong;
                    var dataPhanCong = from q in db.TBL_PhanCongDay
                                       where q.MaPhanCong == item.MaPhanCong
                                       select q;
                    long j = dataPhanCong.First().MaGiangVien;
                    var dataGiangVien = from q in db.TBL_GiangVien
                                        where q.MaGiangVien == j
                                        select q;
                    v1.MaGiangVien = dataPhanCong.First().MaGiangVien;
                    v1.TenGiangVien = dataGiangVien.First().TenGiangVien;
                    v1.HinhAnh = dataGiangVien.First().HinhAnh;
                    v1.ID = idd;
                    v1.TaiKhoan = tkh;
                    j = dataPhanCong.First().MaMonHoc;
                    var dataMonHoc = from q in db.TBL_MonHoc
                                     where q.MaMonHoc == j
                                     select q;
                    v1.MaMonHoc = dataPhanCong.First().MaMonHoc;
                    v1.TenMonHoc = dataMonHoc.First().TenMonHoc;
                    v1.TrangThai = item.TrangThai;

                    v.Add(v1);
                }
            }
            return v.ToList();
        }
        public static string tkh;
        public static long idd;
        public TBL_TaiKhoan getbyid(string id)
        {
            return db.TBL_TaiKhoan.SingleOrDefault(x => x.TaiKhoan == id);
        }


        public bool Update(TBL_TaiKhoan tk,long? idtk)
        {
            try
            {
                var taiKhoan = db.TBL_TaiKhoan.Find(idtk);
                taiKhoan.MatKhau = tk.MatKhau;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public TBL_TaiKhoan ViewDetail(long? id)
        {
            return db.TBL_TaiKhoan.Find(id);
        }
    }
}
