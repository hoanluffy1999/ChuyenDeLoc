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

        public ActionResult Download_PDF()
        {
            var list = new List<BaoCaoNhapViewModel>();
            list.Add(new BaoCaoNhapViewModel() {
                NgayNhap=DateTime.Now,
                SoLuong=1,
                GiaNhap=500
            }); 
            list.Add(new BaoCaoNhapViewModel()
            {
                NgayNhap = DateTime.Now,
                SoLuong = 12,
                GiaNhap = 500
            });
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Report"), "BaoCaoNhap.rpt"));
            rd.SetDataSource(list);

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