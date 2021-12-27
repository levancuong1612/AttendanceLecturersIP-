using CSDL.EF;
using CSDL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDL.DAO
{

    public class DIEMDANHDAO
    {
        QLGVDBContext db = null;
        public DIEMDANHDAO()
        {
            db = new QLGVDBContext();
        }
        int tinhSoTiet(long? MaMon)
        {
            var dt = db.TBL_MonHoc.Where(x => x.MaMonHoc == MaMon);
            int soTiet;
            int soTC = Convert.ToInt32(dt.First().SoTinChi);
            if (dt.First().Loai == "Lý Thuyết")
            {
                soTiet = soTC * 15;
            }
            else
            {
                soTiet = soTC * 30;
            }
            return soTiet;
        }
        public bool Update( long? mk,long? cttkb,string idad)
        {
            try
            {
                DateTime dt = DateTime.Now;
                var hocKy = db.TBL_HocKy.Where(x => x.ThoiGianBD <= dt && x.ThoiGianKT >= dt);
                var data = from q in db.TBL_DiemDanh
                           join p in db.TBL_HocKy
                           on q.MaHocKy equals p.MaHocKy
                           where q.MaGiangVien == mk && p.ThoiGianBD <= dt && p.ThoiGianKT >= dt
                           select q;
                if (data != null && data.Count() > 0)
                {
                    var ph = data.First();
                    int? soNgayDay = ph.SoNgayDay;
                    ph.SoNgayDay = soNgayDay + 1;
                    db.SaveChanges();
                }
                else
                {
                    var ph = new TBL_DiemDanh();
                    ph.MaGiangVien = Convert.ToInt64(mk);
                    ph.MaHocKy = hocKy.First().MaHocKy;
                    ph.SoNgayDay = 1;
                    db.TBL_DiemDanh.Add(ph);
                    db.SaveChanges();
                }
                var data2 = from q in db.TBL_DiemDanh
                            join p in db.TBL_HocKy
                            on q.MaHocKy equals p.MaHocKy
                            where q.MaGiangVien == mk && p.ThoiGianBD <= dt && p.ThoiGianKT >= dt
                            select q;
                TBL_ChiTietDiemDanh ct = new TBL_ChiTietDiemDanh();
                ct.MaDiemDanh = data2.First().MaDiemDanh;
                ct.MaCTTKB = Convert.ToInt64(cttkb);
                ct.MaGiangVien = data2.First().MaGiangVien;
                ct.Ngay = dt;
                ct.Gio = dt.TimeOfDay;
                ct.DiaChiIP = idad;
                db.TBL_ChiTietDiemDanh.Add(ct);
                db.SaveChanges();
                var ttcttkb = db.TBL_ChiTietThoiKhoaBieu.Find(cttkb);
                ttcttkb.TrangThai = "Đã dạy";
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
               
         
         
          
           
        }
        public TBL_ChiTietDiemDanh ViewDetail(long magv)
        {
            return db.TBL_ChiTietDiemDanh.Find(magv);
        }
        public List<ViewDiemDanh> getAllListDiemDanh(long?MaHK)
        {
            List<ViewDiemDanh> list = new List<ViewDiemDanh>();
            var data = from q in db.TBL_DiemDanh
                       where q.MaHocKy==MaHK
                       select q;
            if (data != null)
            {
                foreach (var item in data)
                {
                    ViewDiemDanh v = new ViewDiemDanh();
                    v.MaDiemDanh = item.MaDiemDanh;
                    v.MaGiangVien = item.MaGiangVien;
                    var gv = db.TBL_GiangVien.Find(item.MaGiangVien);
                    v.TenGiangVien = gv.TenGiangVien;
                    v.MaHocKy = item.MaHocKy;
                    var hk = db.TBL_HocKy.Find(item.MaHocKy);
                    v.TenHocKy = hk.TenHocKy;
                    var pc = db.TBL_PhanCongDay.Where(x => x.MaGiangVien == item.MaGiangVien && x.MaHocKy==MaHK);
                    int soBuoi = 0;
                    foreach(var it in pc)
                    {
                        var cttkb = db.TBL_ChiTietThoiKhoaBieu.Where(x => x.MaPhanCong == it.MaPhanCong);
                        soBuoi += cttkb.Count();
                    }
                    v.SoBuoiPhanCong = soBuoi;
                    v.SoLopPhanCong = pc.Count();
                    int soTiet = 0;
                    foreach(var soTc in pc)
                    {
                        soTiet += tinhSoTiet(soTc.MaMonHoc);
                    }
                    v.SoTietPhanCong = soTiet;
                    list.Add(v);
                }
            }
            return list.ToList();
        }
        public static int cht, onl, off;
        public List<ViewChiTietDiemDanh> getAllListDiemDanhGV(long? MaDD,long?MaHK)
        {
            List<ViewChiTietDiemDanh> list = new List<ViewChiTietDiemDanh>();
            var data = from q in db.TBL_ChiTietThoiKhoaBieu
                          join p in db.TBL_PhanCongDay
                          on q.MaPhanCong equals p.MaPhanCong
                          where p.MaGiangVien == MaDD && p.MaHocKy==MaHK
                          select q;
            if (data != null)
            {
                foreach (var info in data)
                {
                    if(info.TrangThai== "Đã dạy")
                    {
                        var ct = db.TBL_ChiTietDiemDanh.Where(x => x.MaCTTKB == info.MaCTTKB);
                        foreach(var item in ct)
                        {
                            ViewChiTietDiemDanh v = new ViewChiTietDiemDanh();
                            v.MaCTDD = item.MaCTDD;
                            v.MaDiemDanh = item.MaDiemDanh;
                            v.MaGiangVien = item.MaGiangVien;
                            var gv = db.TBL_GiangVien.Find(item.MaGiangVien);
                            v.TenGiangVien = gv.TenGiangVien;
                            v.MaCTTKB = item.MaCTTKB;
                            var tkb = db.TBL_ChiTietThoiKhoaBieu.Find(item.MaCTTKB);
                            long maLop = tkb.MaLop;
                            var lop = db.TBL_Lop.Find(maLop);
                            v.MaLop = maLop;
                            v.TenLop = lop.TenLop;
                            v.Thu = tkb.Thu;
                            v.Buoi = tkb.Buoi;
                            var maTiet = tkb.MaTiet;
                            v.MaTiet = maTiet;
                            var tiet = db.TBL_TietHoc.Find(maTiet);
                            v.TenTiet = tiet.Tiet;
                            var phancong = db.TBL_PhanCongDay.Find(tkb.MaPhanCong);
                            var monHoc = db.TBL_MonHoc.Find(phancong.MaMonHoc);
                            v.MaMonHoc = monHoc.MaMonHoc;
                            v.TenMonHoc = monHoc.TenMonHoc;
                            v.Ngay = info.Ngay;
                            string gio = item.Gio.Value.Hours + ":" + item.Gio.Value.Minutes;
                            v.Gio = gio;
                            v.IP = item.DiaChiIP;
                            var diemDanh = db.TBL_DiemDanh.Find(item.MaDiemDanh);

                            var pc = db.TBL_PhanCongDay.Where(x => x.MaGiangVien == item.MaGiangVien && x.MaHocKy == diemDanh.MaHocKy);
                            int soBuoi = 0;
                            foreach (var it in pc)
                            {
                                var cttkb = db.TBL_ChiTietThoiKhoaBieu.Where(x => x.MaPhanCong == it.MaPhanCong);
                                soBuoi += cttkb.Count();
                            }
                            v.ChiTieu = soBuoi;
                            v.Online = diemDanh.SoNgayDay;
                            int of = soBuoi - Convert.ToInt32(diemDanh.SoNgayDay);
                            v.Ofline = of;
                      
                            v.TrangThai = "Đã Dạy";
                            list.Add(v);
                        }
                       
                    }
                    else
                    {
                       
                            ViewChiTietDiemDanh v = new ViewChiTietDiemDanh();
                        v.MaGiangVien = MaDD;
                            var gv = db.TBL_GiangVien.Find(MaDD);
                            v.TenGiangVien = gv.TenGiangVien;
                            v.MaCTTKB = info.MaCTTKB;
                            var tkb = db.TBL_ChiTietThoiKhoaBieu.Find(info.MaCTTKB);
                            long maLop = tkb.MaLop;
                            var lop = db.TBL_Lop.Find(maLop);
                            v.MaLop = maLop;
                            v.TenLop = lop.TenLop;
                            v.Thu = tkb.Thu;
                            v.Buoi = tkb.Buoi;
                            var maTiet = tkb.MaTiet;
                            v.MaTiet = maTiet;
                            var tiet = db.TBL_TietHoc.Find(maTiet);
                            v.TenTiet = tiet.Tiet;
                            var phancong = db.TBL_PhanCongDay.Find(tkb.MaPhanCong);
                            var monHoc = db.TBL_MonHoc.Find(phancong.MaMonHoc);
                            v.MaMonHoc = monHoc.MaMonHoc;
                            v.TenMonHoc = monHoc.TenMonHoc;

                      

                        v.TrangThai = "Chưa Dạy";
                            list.Add(v);
                        
                    }
                   
                   
                   
                }
            }
            return list.ToList();
        }
        public List<ViewChiTietDiemDanh> TrangChu( long? MaHK)
        {
            List<ViewChiTietDiemDanh> list = new List<ViewChiTietDiemDanh>();
            DateTime dt = DateTime.Now;
            var data = from q in db.TBL_ChiTietThoiKhoaBieu
                       join p in db.TBL_PhanCongDay
                       on q.MaPhanCong equals p.MaPhanCong
                       where  q.Ngay==dt.Date
                       select q;
            if (data != null)
            {
                foreach (var info in data)
                {
                    if (info.TrangThai == "Đã dạy")
                    {
                        var ct = db.TBL_ChiTietDiemDanh.Where(x => x.MaCTTKB == info.MaCTTKB);
                        foreach (var item in ct)
                        {
                            ViewChiTietDiemDanh v = new ViewChiTietDiemDanh();
                            v.MaCTDD = item.MaCTDD;
                            v.MaDiemDanh = item.MaDiemDanh;
                            v.MaGiangVien = item.MaGiangVien;
                            var gv = db.TBL_GiangVien.Find(item.MaGiangVien);
                            v.TenGiangVien = gv.TenGiangVien;
                            v.MaCTTKB = item.MaCTTKB;
                            var tkb = db.TBL_ChiTietThoiKhoaBieu.Find(item.MaCTTKB);
                            long maLop = tkb.MaLop;
                            var lop = db.TBL_Lop.Find(maLop);
                            v.MaLop = maLop;
                            v.TenLop = lop.TenLop;
                            v.Thu = tkb.Thu;
                            v.Buoi = tkb.Buoi;
                            var maTiet = tkb.MaTiet;
                            v.MaTiet = maTiet;
                            var tiet = db.TBL_TietHoc.Find(maTiet);
                            v.TenTiet = tiet.Tiet;
                            var phancong = db.TBL_PhanCongDay.Find(tkb.MaPhanCong);
                            var monHoc = db.TBL_MonHoc.Find(phancong.MaMonHoc);
                            v.MaMonHoc = monHoc.MaMonHoc;
                            v.TenMonHoc = monHoc.TenMonHoc;
                            v.Ngay = item.Ngay;
                            string gio = item.Gio.Value.Hours + ":" + item.Gio.Value.Minutes;
                            v.Gio = gio;
                            v.IP = item.DiaChiIP;
                            var diemDanh = db.TBL_DiemDanh.Find(item.MaDiemDanh);
                            var pc = db.TBL_PhanCongDay.Where(x => x.MaGiangVien == item.MaGiangVien && x.MaHocKy == diemDanh.MaHocKy);
                            int soBuoi = 0;
                            foreach (var it in pc)
                            {
                                var cttkb = db.TBL_ChiTietThoiKhoaBieu.Where(x => x.MaPhanCong == it.MaPhanCong);
                                soBuoi += cttkb.Count();
                            }
                            v.ChiTieu = soBuoi;
                            v.Online = diemDanh.SoNgayDay;
                            int of = soBuoi - Convert.ToInt32(diemDanh.SoNgayDay);
                            v.Ofline = of;

                            v.TrangThai = "Đã Dạy";
                            list.Add(v);
                        }

                    }
                    else
                    {

                        ViewChiTietDiemDanh v = new ViewChiTietDiemDanh();
                        var pc = db.TBL_PhanCongDay.Find(info.MaPhanCong);
                        v.MaGiangVien =pc.MaGiangVien ;
                        var gv = db.TBL_GiangVien.Find(pc.MaGiangVien);
                        v.TenGiangVien = gv.TenGiangVien;
                        v.MaCTTKB = info.MaCTTKB;
                        var tkb = db.TBL_ChiTietThoiKhoaBieu.Find(info.MaCTTKB);
                        long maLop = tkb.MaLop;
                        var lop = db.TBL_Lop.Find(maLop);
                        v.MaLop = maLop;
                        v.TenLop = lop.TenLop;
                        v.Thu = tkb.Thu;
                        v.Buoi = tkb.Buoi;
                        var maTiet = tkb.MaTiet;
                        v.MaTiet = maTiet;
                        var tiet = db.TBL_TietHoc.Find(maTiet);
                        v.TenTiet = tiet.Tiet;
                        var phancong = db.TBL_PhanCongDay.Find(tkb.MaPhanCong);
                        var monHoc = db.TBL_MonHoc.Find(phancong.MaMonHoc);
                        v.MaMonHoc = monHoc.MaMonHoc;
                        v.TenMonHoc = monHoc.TenMonHoc;
                        v.TrangThai = "Chưa Dạy";
                        list.Add(v);
                    }
                }
            }
            return list.ToList();
        }
    }
}
