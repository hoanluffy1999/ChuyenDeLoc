using ChuyenDeLoc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChuyenDeLoc.Controllers
{
    public class PhanLoaiController : Controller
    {
        // GET: PhanLoai
        public ActionResult Index()
        {
            return View();
        }
        private readonly QLCayCanhEntities db;
        public PhanLoaiController()
        {
            WebDbContext webDbContext = new WebDbContext();
            db = webDbContext.GetDBContext();
        }
        [HttpGet]
        public ActionResult List()
        {
            List<PhanLoai> data = new List<PhanLoai>();
             data = db.PhanLoais.Where(x => true).ToList();
            return View(data);
        }
        [HttpPost]
        public ActionResult List(string name)
        {
            var data = db.PhanLoais.Where(x => x.Ten == name || string.IsNullOrEmpty(name)).ToList();
            return View(data);
        }
        public ActionResult Edit(PhanLoai model)
        {
            var data = db.PhanLoais.Where(x => x.Ma == model.Ma).FirstOrDefault();
            if (data == null)
            {
                model = db.PhanLoais.Add(model);
                db.SaveChanges();
                return View(model);
            }
            db.Entry(data).CurrentValues.SetValues(model);
            db.SaveChanges();
            return View(model);
        }
        public ActionResult Delete(int id)
        {
            var data = db.PhanLoais.Where(x => x.Ma == id).FirstOrDefault();
            if (data != null)
            {
                db.PhanLoais.Remove(data);
            }
            return View();
        }
    }
}