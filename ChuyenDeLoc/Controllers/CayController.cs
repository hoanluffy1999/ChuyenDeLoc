﻿using ChuyenDeLoc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChuyenDeLoc.Controllers
{
    public class CayController : Controller
    {
        private readonly QLCayCanhEntities db;
        public CayController()
        {
            WebDbContext webDbContext = new WebDbContext();
            db = webDbContext.GetDBContext();
        }
        public ActionResult Index()
        {
            ViewBag.title = "Danh sách cây ";
            return View();
        }
        [HttpGet]
        public ActionResult GetList(string name)
        {
            var data = db.PhanLoais.Where(x => x.Ten.ToLower().Contains(name.ToLower()) || string.IsNullOrEmpty(name)).ToList();
            return PartialView(data);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Create(PhanLoai inputModel)
        {
            db.PhanLoais.Add(inputModel);
            db.SaveChanges();
            return Json(new { result = true }); ;
        }
        [HttpGet]
        public ActionResult Update(int Ma)
        {
            var entity = db.PhanLoais.Find(Ma);
            return PartialView(entity);
        }
        [HttpPost]
        public ActionResult Update(PhanLoai inputModel)
        {


            var entity = db.PhanLoais.Find(inputModel.Ma);
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


            var entity = db.PhanLoais.Find(Ma);

            if (entity == null)
            {
                return Json(new { result = false });
            }
            db.PhanLoais.Remove(entity);

            db.SaveChanges();
            return Json(new { result = true }); ;
        }
    }
}