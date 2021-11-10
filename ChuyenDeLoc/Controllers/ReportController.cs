using ChuyenDeLoc.Models;
using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChuyenDeLoc.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report
        private readonly QLCayCanhEntities db;

        public ReportController()
        {
            WebDbContext webDbContext = new WebDbContext();
            db = webDbContext.GetDBContext();
        }
        public ActionResult Index()
        {
            var data = db.NhaCungCaps.ToList();
            return View(data);
        }

        [HttpPost]
        public ActionResult Download_PDF(int MaNCC, DateTime From, DateTime To)
        {
            var data = new List<BaoCaoNhapViewModel>();
            data.Add(new BaoCaoNhapViewModel() {
                GiaNhap=500
            });

            var query = from nv in db.NhanViens
                        join pn in db.PhieuNhaps on nv.Ma equals pn.MaNV
                        join ncc in db.NhaCungCaps on pn.MaNCC equals ncc.Ma
                        join ctpn in db.ChiTiepPhieuNhaps on pn.Ma equals ctpn.MaPhieuNhap
                        join sp in db.SanPhams on ctpn.MaSP equals sp.Ma
                        select new BaoCaoNhapViewModel()
                        {
                            MaNCC=ncc.Ma,
                            NCC = ncc.Ten,
                            NhanVien = nv.HoTen,
                            GiaNhap = ctpn.GiaNhap ?? 0,
                            NgayNhap = pn.NgayNhap??default,
                            SoLuong = ctpn.SoLuong ?? 0,
                            TenSanPham = sp.Ten
                        };
            data = query.Where(x => x.MaNCC == MaNCC && x.NgayNhap > From && x.NgayNhap < To).ToList();
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Report"), "BaoCaoNhap.rpt"));
            rd.SetDataSource(data);

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            rd.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
            rd.PrintOptions.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(5, 5, 5, 5));
            rd.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA5;

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);

            return File(stream, "application/pdf", "CustomerList.pdf");
        }
    }
}