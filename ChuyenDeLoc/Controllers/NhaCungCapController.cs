using ChuyenDeLoc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChuyenDeLoc.Controllers
{
    public class NhaCungCapController : Controller
    {
        private readonly QLCayCanhEntities db;
        public NhaCungCapController()
        {
            WebDbContext webDbContext = new WebDbContext();
            db = webDbContext.GetDBContext();
        }
        public ActionResult Index()
        {
            ViewBag.title = "Danh sách nhóm cây";
            return View();
        }
        [HttpGet]
        public ActionResult GetList(string name)
        {
            var data = db.NhaCungCaps.Where(x => x.Ten.ToLower().Contains(name.ToLower()) || string.IsNullOrEmpty(name)).ToList();
            return PartialView(data);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Create(NhaCungCap inputModel)
        {
            db.NhaCungCaps.Add(inputModel);
            db.SaveChanges();
            return Json(new { result = true }); ;
        }
        [HttpGet]
        public ActionResult Update(int Ma)
        {
            var entity = db.NhaCungCaps.Find(Ma);
            return PartialView(entity);
        }
        [HttpPost]
        public ActionResult Update(NhaCungCap inputModel)
        {


            var entity = db.NhaCungCaps.Find(inputModel.Ma);
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


            var entity = db.NhaCungCaps.Find(Ma);

            if (entity == null)
            {
                return Json(new { result = false });
            }
            db.NhaCungCaps.Remove(entity);

            db.SaveChanges();
            return Json(new { result = true }); ;
        }
    }
}