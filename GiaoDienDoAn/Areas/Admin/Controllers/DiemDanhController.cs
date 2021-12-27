using CSDL.DAO;
using CSDL.EF;
using GiaoDienDoAn.Areas.Admin.Report;
using GiaoDienDoAn.QLGiangVienDataSetTableAdapters;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GiaoDienDoAn.Areas.Admin.Controllers
{
    public class DiemDanhController : Controller
    {
        // GET: Admin/DiemDanh
        QLGVDBContext db = new QLGVDBContext();
        QLGiangVienDataSet dbx = new QLGiangVienDataSet();
        public ActionResult Index()
        {
            DateTime dt = DateTime.Now;
            var data = db.TBL_HocKy.Where(x => x.ThoiGianBD <= dt && x.ThoiGianKT >= dt);
            var dao = new DIEMDANHDAO();
            long? ma = data.First().MaHocKy;
            maHK = ma;
            var model = dao.getAllListDiemDanh(ma);
            return View(model);
        }
        static long? maHK;
        public ActionResult ChiTietDiemDanh(long? MaDD)
        {
            DateTime dt = DateTime.Now;
            var dao = new DIEMDANHDAO();
            var hocKy = db.TBL_HocKy.Where(x => x.ThoiGianBD <= dt && x.ThoiGianKT >= dt);
            long MaHK = hocKy.First().MaHocKy;
            var model = dao.getAllListDiemDanhGV(MaDD, MaHK);
            return View(model);
        }
        public ActionResult Report(string id)
        {
            LocalReport lr = new LocalReport();
            lr.ReportPath = Server.MapPath("~/Areas/Admin/Report/RPDiemDanh.rdlc");
         

            ReportDataSource rd = new ReportDataSource();
            rd.Name = "DataSet1";
            List<CSReport> list = new List<CSReport>();

            var data = db.TBL_DiemDanh.Where(x => x.MaHocKy == maHK);
            if (data != null)
            {
                foreach(var item in data)
                {
                    CSReport csp = new CSReport();
                    var gv = db.TBL_GiangVien.Find(item.MaGiangVien);
                    var hk = db.TBL_HocKy.Find(item.MaHocKy);
                    csp.MaDiemDanh = item.MaDiemDanh;
                    csp.MaGiangVien = item.MaGiangVien;
                    csp.TenGiangVien = gv.TenGiangVien;
                    csp.TenHocKy = hk.TenHocKy;
                    csp.SoNgayDay = item.SoNgayDay;
                    csp.SoNgayNghi = item.SoNgayNghi;
                    list.Add(csp);
                }
            }
            rd.Value = list;
           
            lr.DataSources.Add(rd);
            string reportType = id;
            string mimeType;
            string encoding;
            string fileNameExtension;



            if (id == "Excel")
            {
                fileNameExtension = "xlsx";
            }
            if (id == "Word")
            {
                fileNameExtension = "docx";
            }
            if (id == "PDF")
            {
                fileNameExtension = "pdf";
            }
            else
            {
                fileNameExtension = "jpg";
            }
            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;
            string deviceInfo =

   "<DeviceInfo>" +
   "  <OutputFormat>" + id + "</OutputFormat>" +
   "  <PageWidth>8.5in</PageWidth>" +
   "  <PageHeight>11in</PageHeight>" +
   "  <MarginTop>0.5in</MarginTop>" +
   "  <MarginLeft>1in</MarginLeft>" +
   "  <MarginRight>1in</MarginRight>" +
   "  <MarginBottom>0.5in</MarginBottom>" +
   "</DeviceInfo>";
            renderedBytes = lr.Render(
                reportType,
                deviceInfo,
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,
                out warnings);
            return File(renderedBytes, mimeType);
        }
    }
}