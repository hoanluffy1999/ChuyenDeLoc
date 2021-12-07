using ChuyenDeLoc.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChuyenDeLoc.Controllers
{
    /// <summary>
    /// quản lý cây 
    /// </summary>
    public class CayController : Controller
    {
        private readonly QLCayCanhEntities db;
        public CayController()
        {
            WebDbContext webDbContext = new WebDbContext();
            db = webDbContext.GetDBContext();
        }
        /// <summary>
        /// danh sách
        /// </summary>
        /// <returns></returns>
        [CustomAuthen]
        public ActionResult Index()
        {
            ViewBag.title = "Danh sách cây ";
            return View();
        }
        /// <summary>
        /// lấy danh sách
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetList(string name)
        {
            var data = db.SanPhams.Where(x => x.Ten.ToLower().Contains(name.ToLower()) || string.IsNullOrEmpty(name)).ToList();
            return PartialView(data);
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewData["PhanLoai"] = db.PhanLoais.Where(x => true).ToList();
            return PartialView();
        }
        /// <summary>
        /// thêm mới  cây
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(SanPham inputModel)
        {
            try
            {
                inputModel.SoLuong = 0;
                inputModel.PhanLoai = db.PhanLoais.Where(x => x.Ma == inputModel.MaPhanLoai).FirstOrDefault();
                db.SanPhams.Add(inputModel);
                db.SaveChanges();
                return Json(new { result = true });
            }
            catch (Exception ex)
            {
                return Json(new { result = false });
            }
        }
        /// <summary>
        /// cập nhập
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Update(int id)
        {
            ViewData["PhanLoai"] = db.PhanLoais.Where(x => true).ToList();
            var entity = db.SanPhams.Find(id);
            return PartialView(entity);
        }
        [HttpPost]
        public ActionResult Update(SanPham inputModel)
        {


            var entity = db.SanPhams.Find(inputModel.Ma);
            if (entity == null)
            {
                return Json(new { result = false });
            }
            db.Entry(entity).CurrentValues.SetValues(inputModel);
            db.SaveChanges();
            return Json(new { result = true, message = "Thêm mới thành công" });
        }
        [HttpPost]
        public ActionResult Delete(int Ma)
        {
            try
            {
                var entity = db.SanPhams.Find(Ma);

                if (entity == null)
                {
                    return Json(new { result = false });
                }
                db.SanPhams.Remove(entity);

                db.SaveChanges();
                return Json(new { result = true });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, message = "Lỗi" });
            }
        }

        [HttpGet]
        public ActionResult CreateFast()
        {
            ViewData["PhanLoai"] = db.PhanLoais.Where(x => true).ToList();
            return PartialView();
        }
        [HttpPost]
        public ActionResult CreateFast(SanPham inputModel, string LoaiCay)
        {
            using (DbContextTransaction transaction = db.Database.BeginTransaction())
            {
                try
                {
                    int result = SetData(inputModel, LoaiCay);
                    if (result == 0)
                    {
                        transaction.Rollback();
                        return Json(new { result = false });
                    }
                    else
                    {
                        transaction.Commit();
                        return Json(new { result = true });
                    }
                }
                catch(Exception e)
                {
                    transaction.Rollback();
                    return Json(new { result = false });
                }
            }
        }

        private int SetData(SanPham inputModel, string LoaiCay)
        {
            int result = 1;

            if (!string.IsNullOrEmpty(LoaiCay))
            {
                PhanLoai p = new PhanLoai()
                {
                    Ten = LoaiCay,
                    MoTa = string.Empty,
                };
                db.PhanLoais.Add(p);
                result = db.SaveChanges();
                if (result == 0) return result;
                inputModel.MaPhanLoai = p.Ma;
                db.SanPhams.Add(inputModel);
                return db.SaveChanges();
            }
            else
            {
                db.SanPhams.Add(inputModel);
                result = db.SaveChanges();

            }
            return result;
        }
    }
}