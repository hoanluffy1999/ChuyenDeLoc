using ChuyenDeLoc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChuyenDeLoc.Controllers
{
    public class PhieuNhapController : Controller
    {
        private readonly QLCayCanhEntities db;
        public PhieuNhapController()
        {
            WebDbContext webDbContext = new WebDbContext();
            db = webDbContext.GetDBContext();
        }
        public ActionResult Index()
        {
            ViewBag.title = "Danh sách nhà phiếu nhập";
            return View();
        }
        [HttpGet]
        public ActionResult GetList(string name)
        {
            var data = db.PhieuNhaps.Where(x =>/* x.Ma.ToLower().Contains(name.ToLower()) ||*//* string.IsNullOrEmpty(name)*/ true).ToList();
            return PartialView(data);
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewData["NhanVien"] = db.NhanViens.Where(x => true).ToList();
            ViewData["NhaCungCap"] = db.NhaCungCaps.Where(x => true).ToList();
            return PartialView();
        }
        [HttpPost]
        public ActionResult Create(PhieuNhap inputModel)
        {
            db.PhieuNhaps.Add(inputModel);
            db.SaveChanges();
            return Json(new { result = true }); ;
        }
        [HttpGet]
        public ActionResult Update(int Ma)
        {
            ViewData["NhanVien"] = db.NhanViens.Where(x => true).ToList();
            ViewData["NhaCungCap"] = db.NhaCungCaps.Where(x => true).ToList();
            var entity = db.PhieuNhaps.Find(Ma);
            return PartialView(entity);
        }
        [HttpPost]
        public ActionResult Update(PhieuNhap inputModel)
        {


            var entity = db.PhieuNhaps.Find(inputModel.Ma);
            if (entity == null)
            {
                return Json(new { result = false });
            }
            db.Entry(entity).CurrentValues.SetValues(inputModel);
            db.SaveChanges();
            return Json(new { result = true });
        }
        [HttpPost]
        public ActionResult Delete(int Ma)
        {


            var entity = db.PhieuNhaps.Find(Ma);

            if (entity == null)
            {
                return Json(new { result = false });
            }
            db.PhieuNhaps.Remove(entity);

            db.SaveChanges();
            return Json(new { result = true }); ;
        }
    }
}