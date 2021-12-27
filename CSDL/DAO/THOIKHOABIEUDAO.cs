using CSDL.EF;
using CSDL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDL.DAO
{
    public class THOIKHOABIEUDAO
    {
        QLGVDBContext db = null;
        public THOIKHOABIEUDAO()
        {
            db = new QLGVDBContext();
        }
        public bool InsertTKB(TBL_ChiTietThoiKhoaBieu info)
        {
            try
            {
                db.TBL_ChiTietThoiKhoaBieu.Add(info);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<ViewThoiKhoaBieu> getListTKB(string searchString,string TenPhong)
        {

            List<ViewThoiKhoaBieu> list = new List<ViewThoiKhoaBieu>();
            List<ViewThoiKhoaBieu> list2 = new List<ViewThoiKhoaBieu>();
            var data = from q in db.TBL_ChiTietThoiKhoaBieu
                       select q;
            foreach (var a in data)
            {
                ViewThoiKhoaBieu v = new ViewThoiKhoaBieu();
                v.MaCTTKB = a.MaCTTKB;
                v.Ngay = a.Ngay;
                v.MaLop = a.MaLop;
                var dataLop = from q in db.TBL_Lop
                              where q.MaLop == a.MaLop
                              select q;
                v.TenLop = dataLop.First().TenLop;
                v.Thu = a.Thu;
                v.Buoi = a.Buoi;
                v.Tuan = a.Tuan;
                v.MaTiet = a.MaTiet;
                var dataTietHoc = from q in db.TBL_TietHoc
                                  where q.MaTiet == a.MaTiet
                                  select q;
                v.TenTiet = dataTietHoc.First().Tiet;
                v.MaPhong = a.MaPhong;
                var dataPhong = from q in db.TBL_PhongHoc
                                where q.MaPhong == a.MaPhong
                                select q;
                v.TenPhong = dataPhong.First().TenPhong;
                v.MaPhanCong = a.MaPhanCong;
                var dataPhanCong = from q in db.TBL_PhanCongDay
                                   where q.MaPhanCong == a.MaPhanCong
                                   select q;
                long x = dataPhanCong.First().MaGiangVien;
                var dataGiangVien = from q in db.TBL_GiangVien
                                    where q.MaGiangVien == x
                                    select q;
                v.MaGiangVien = dataPhanCong.First().MaGiangVien;
                v.TenGiangVien = dataGiangVien.First().TenGiangVien;
                x = dataPhanCong.First().MaMonHoc;
                var dataMonHoc = from q in db.TBL_MonHoc
                                 where q.MaMonHoc == x
                                 select q;
                v.MaMonHoc = dataPhanCong.First().MaMonHoc;
                v.TenMonHoc = dataMonHoc.First().TenMonHoc;
                list.Add(v);
            }
            int i = 0;
            if (!string.IsNullOrEmpty(searchString)||!string.IsNullOrEmpty(TenPhong))
            {
                foreach (var item in list)
                {
                    if (item.TenGiangVien == searchString || item.Tuan == searchString ||
                        item.TenPhong == searchString || item.TenMonHoc == searchString ||
                        item.TenPhong==TenPhong)
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
        string ngayTrongTuan(DateTime dt)
        {
            if (dt.DayOfWeek == DayOfWeek.Monday)
            {
                return "Thứ 2";
            }
            if (dt.DayOfWeek == DayOfWeek.Tuesday)
            {
                return "Thứ 3";
            }
            if (dt.DayOfWeek == DayOfWeek.Wednesday)
            {
                return "Thứ 4";
            }
            if (dt.DayOfWeek == DayOfWeek.Thursday)
            {
                return "Thứ 5";
            }
            if (dt.DayOfWeek == DayOfWeek.Friday)
            {
                return "Thứ 6";
            }
            if (dt.DayOfWeek == DayOfWeek.Saturday)
            {
                return "Thứ 7";
            }
            if (dt.DayOfWeek == DayOfWeek.Sunday)
            {
                return "Chủ Nhật";
            }
            return "";
        }
        string buoi(long maTiet)
        {
            var data = db.TBL_TietHoc.Find(maTiet);
            string tiet = data.Tiet;
            if (tiet == "1-3" || tiet == "4-6" || tiet == "1-5" || tiet == "1-6")
            {
                return "Sáng";
            }
            if (tiet == "7-9" || tiet == "10-12" || tiet == "7-11" || tiet == "7-12")
            {
                return "Chiều";
            }
            else
            {
                return "Tổi";
            }
        }
        public bool InsertCTTKB(TBL_ChiTietThoiKhoaBieu info)
        {

            int i = 0;
            long maPC = info.MaPhanCong;
            var data = from q in db.TBL_PhanCongDay
                       where q.MaPhanCong == maPC
                       select q;
            info.MaLop = data.First().MaLop;
            DateTime dt = Convert.ToDateTime(info.Ngay);
            info.Thu = ngayTrongTuan(dt);
            info.Buoi = buoi(info.MaTiet);

            var datatkb = from q in db.TBL_ChiTietThoiKhoaBieu
                          select q;
            if (datatkb != null)
            {
                foreach (var item in datatkb)
                {
                    if (info.MaPhanCong == item.MaPhanCong && info.Ngay == item.Ngay && info.MaLop == item.MaLop && info.MaTiet == item.MaTiet)
                    {
                        i++;
                    }
                }
            }
            if (i == 0)
            {
                db.TBL_ChiTietThoiKhoaBieu.Add(info);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Insert(TBL_Tuan info, DateTime nbd, int? soTuan)
        {
            DateTime dt = nbd;
            string tuan;
            if (nbd.DayOfWeek == DayOfWeek.Monday)
            {
                for (int i = 1; i <= soTuan; i++)
                {
                    info.TrangThai = "Bình Thường";
                    info.TuNgay = dt;
                    tuan = "Tuần " + i;
                    info.DenNgay = dt.AddDays(6);
                    info.Tuan = tuan;
                    db.TBL_Tuan.Add(info);
                    db.SaveChanges();
                    dt = dt.AddDays(7);

                }
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<TBL_Tuan> listTuan()
        {
            DateTime dt = DateTime.Now;
            return db.TBL_Tuan.Where(x => x.TuNgay.Value.Year == dt.Year).ToList();
        }
        public List<TBL_TietHoc> listTietHoc()
        {
            return db.TBL_TietHoc.ToList();
        }
        public List<string> listNgay(string tuan)
        {
            DateTime dt = DateTime.Now;
            List<string> ngay = new List<string>();
            var data = from q in db.TBL_Tuan
                       where q.Tuan == tuan && q.TuNgay.Value.Year == dt.Year
                       select q;
            DateTime tuNgay = Convert.ToDateTime(data.First().TuNgay);
            DateTime denNgay = Convert.ToDateTime(data.First().DenNgay);
            for (DateTime d = tuNgay; d <= denNgay; d = d.AddDays(1))
            {
                string fmDay = d.Month.ToString() + "/" + d.Day.ToString() + "/" + d.Year.ToString();
                ngay.Add(fmDay);
            }
            ngay.Count();
            return ngay;
        }


        public static int y = 0;
        public static int z = 0;
     
        public  List<ViewThoiKhoaBieu> listCTTKBGV( long? maGV,int? ts)
        {
            List<ViewThoiKhoaBieu> v = new List<ViewThoiKhoaBieu>();
       
            DateTime dt =DateTime.Now;
            
            if (ts != 0)
            {
                int ngay = 7 *Convert.ToInt32( ts);
                y++;
                
                dt = dt.AddDays(ngay);
            }
            else
            {
           
                y = 0;
            }
            string daytime1 = dt.Month.ToString() + "-" + dt.Day.ToString() + "-" + dt.Year.ToString();
            DateTime daytime = Convert.ToDateTime(daytime1);
            var data = from q in db.TBL_Tuan
                       where q.TuNgay <= daytime && q.DenNgay >= daytime
                       select q;
           var info = data.First();
            List<DateTime> day = new List<DateTime>();
            for (DateTime x = Convert.ToDateTime(info.TuNgay); x <= Convert.ToDateTime(info.DenNgay); x = x.AddDays(1))
            {
                var datatkb = from q in db.TBL_ChiTietThoiKhoaBieu
                              join p in db.TBL_PhanCongDay
                              on q.MaPhanCong equals p.MaPhanCong
                              where p.MaGiangVien == maGV && q.Ngay.Value.Year == dt.Year && q.Ngay==x
                              select q;
                if (datatkb != null && datatkb.Count()>0)
                {
                    foreach (var item in datatkb)
                    {
                        ViewThoiKhoaBieu v1 = new ViewThoiKhoaBieu();
                        v1.MaCTTKB = item.MaCTTKB;
                        if (ts != 0)
                        {
                            v1.PhanTran = ts + 1;
                            v1.PhanTrantruoc = ts - 1;
                        }
                        else
                        {
                            v1.PhanTran = 1;
                            v1.PhanTrantruoc = -1;
                        }
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
                        var dataTietHoc = from q in db.TBL_TietHoc
                                          where q.MaTiet == item.MaTiet
                                          select q;
                        v1.TenTiet = dataTietHoc.First().Tiet;
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
                        j = dataPhanCong.First().MaMonHoc;
                        var dataMonHoc = from q in db.TBL_MonHoc
                                         where q.MaMonHoc == j
                                         select q;
                        v1.MaMonHoc = dataPhanCong.First().MaMonHoc;
                        v1.TenMonHoc = dataMonHoc.First().TenMonHoc;
                        v.Add(v1);

                    }
                    int l = v.Count();

                }
                else
                {
                    ViewThoiKhoaBieu v1 = new ViewThoiKhoaBieu();
                    if (ts != 0)
                    {
                        v1.PhanTran = ts + 1;
                        v1.PhanTrantruoc = ts - 1;
                    }
                    else
                    {
                        v1.PhanTran = 1;
                        v1.PhanTrantruoc = -1;
                    }
                    v1.MaGiangVien = maGV;
                    v1.Ngay = x;
                    v.Add(v1); 
                }   
            }
            var model = v;
            return model;
        }
        public bool Update(TBL_ChiTietThoiKhoaBieu info, long mk)
        {
            long maPC = info.MaPhanCong;
            var data = from q in db.TBL_PhanCongDay
                       where q.MaPhanCong == maPC
                       select q;
          
            var ph = db.TBL_ChiTietThoiKhoaBieu.Find(mk);
            ph.Ngay = info.Ngay;
            ph.Tuan = info.Tuan;
        
            DateTime dt = Convert.ToDateTime(info.Ngay);
            ph.Thu =ngayTrongTuan(dt) ;
            ph.Buoi = buoi(info.MaTiet);
            ph.MaTiet = info.MaTiet;
            ph.MaPhong = info.MaPhong;
            db.SaveChanges();
            return true;

        }
        public TBL_ChiTietThoiKhoaBieu ViewDetail(long magv)
        {
            return db.TBL_ChiTietThoiKhoaBieu.Find(magv);
        }
        public bool UpdateTuan(TBL_Tuan info, long mk)
        {
            long maPC = info.MaTuan;
            var ph = db.TBL_Tuan.Find(mk);
            ph.TrangThai = info.TrangThai;
            db.SaveChanges();
            DateTime? dt;
            if (info.TrangThai == "Nghỉ" )
            {
                var data = db.TBL_ChiTietThoiKhoaBieu.Where(x=>x.Ngay>=ph.TuNgay);
                foreach (var item in data)
                {
                    string cr = item.Tuan.Substring(5);
                    int newweek = Convert.ToInt32(cr) + 1;
                    item.Tuan = "Tuần " +newweek;
                    dt = item.Ngay;
                    item.Ngay = dt.Value.AddDays(7);
                   
                }
                db.SaveChanges();
            }


            return true;

        }
        public TBL_Tuan ViewDetailTuan(long magv)
        {
            return db.TBL_Tuan.Find(magv);
        }
        //public ViewThoiKhoaBieu ViewChiTietTKBGV(long magv)
        //{
        //    DateTime dt = DateTime.Now;
        //    var datagv = from q in db.TBL_GiangVien
        //                 where q.MaGiangVien==magv
        //               select q;
        //    long maGV = datagv.First().MaGiangVien;
        //    if (datagv != null)
        //    {
        //        var dataTKb = from q in db.TBL_ChiTietThoiKhoaBieu
        //                      join p in db.TBL_PhanCongDay
        //                      on q.MaPhanCong equals p.MaPhanCong
        //                      where p.MaGiangVien == maGV && q.Ngay.Value.Year == dt.Year
        //                      select q;
        //        foreach(var item in dataTKb)
        //        {
        //            ViewThoiKhoaBieu v1 = new ViewThoiKhoaBieu();
        //            v1.MaCTTKB = item.MaCTTKB;

        //            v1.Ngay = item.Ngay;
        //            v1.MaLop = item.MaLop;
        //            var dataLop = from q in db.TBL_Lop
        //                          where q.MaLop == item.MaLop
        //                          select q;
        //            v1.TenLop = dataLop.First().TenLop;
        //            v1.Thu = item.Thu;
        //            v1.Buoi = item.Buoi;
        //            v1.Tuan = item.Tuan;
        //            v1.MaTiet = item.MaTiet;
        //            var dataTietHoc = from q in db.TBL_TietHoc
        //                              where q.MaTiet == item.MaTiet
        //                              select q;
        //            v1.TenTiet = dataTietHoc.First().Tiet;
        //            v1.MaPhong = item.MaPhong;
        //            var dataPhong = from q in db.TBL_PhongHoc
        //                            where q.MaPhong == item.MaPhong
        //                            select q;
        //            v1.TenPhong = dataPhong.First().TenPhong;
        //            v1.MaPhanCong = item.MaPhanCong;
        //            var dataPhanCong = from q in db.TBL_PhanCongDay
        //                               where q.MaPhanCong == item.MaPhanCong
        //                               select q;
        //            long j = dataPhanCong.First().MaGiangVien;
        //            var dataGiangVien = from q in db.TBL_GiangVien
        //                                where q.MaGiangVien == j
        //                                select q;
        //            v1.MaGiangVien = dataPhanCong.First().MaGiangVien;
        //            v1.TenGiangVien = dataGiangVien.First().TenGiangVien;
        //            j = dataPhanCong.First().MaMonHoc;
        //            var dataMonHoc = from q in db.TBL_MonHoc
        //                             where q.MaMonHoc == j
        //                             select q;
        //            v1.MaMonHoc = dataPhanCong.First().MaMonHoc;
        //            v1.TenMonHoc = dataMonHoc.First().TenMonHoc;
        //        }
        //    }

        //    return db.TBL_ChiTietThoiKhoaBieu.Find(magv);
        //}
        public bool Delete(int id)
        {
            try
            {
                var gv = db.TBL_ChiTietThoiKhoaBieu.Find(id);
                db.TBL_ChiTietThoiKhoaBieu.Remove(gv);
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
