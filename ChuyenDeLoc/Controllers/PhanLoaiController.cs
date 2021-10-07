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
        public ActionResult List(string name)
        {
            var data = db.PhanLoais.Where(x => x.Ten == name || string.IsNullOrEmpty(name)).ToList();
            return View(data);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult Create(PhanLoai model)
        {
            model = db.PhanLoais.Add(model);
            db.SaveChanges();
            return View();
        }
        public ActionResult Update(PhanLoai model)
        {
            
            model = db.PhanLoais.Add(model);
            db.SaveChanges();
            return View();
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