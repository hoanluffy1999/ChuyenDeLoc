﻿using ChuyenDeLoc.Models;
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
        [CustomAuthen]
        public ActionResult Index()
        {
            ViewBag.title = "Danh sách nhà cung cấp";
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
            ViewData["NhanVien"] = db.PhanLoais.Where(x => true).ToList();
            ViewData["NhaCungCap"] = db.PhanLoais.Where(x => true).ToList();
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
            NhaCungCapViewModel nhaCungCap = new NhaCungCapViewModel()
            {
                DiaChi = entity.DiaChi,
                Ma = entity.Ma,
                Email = entity.Email,
                SDT = entity.SDT,
                Ten = entity.Ten,
               
            };
            return PartialView(nhaCungCap);
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
            try
            {
                var entity = db.NhaCungCaps.Find(Ma);

                if (entity == null)
                {
                    return Json(new { result = false });
                }

                db.NhaCungCaps.Remove(entity);
                db.SaveChanges();
                return Json(new { result = true });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, message = "Lỗi" });
            }
        }
    }
}