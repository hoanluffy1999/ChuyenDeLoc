using ChuyenDeLoc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChuyenDeLoc.Controllers
{
    public class AccountController : Controller
    {
        private readonly QLCayCanhEntities _dbcontext;
        public AccountController()
        {
            WebDbContext webDbContext = new WebDbContext();
            _dbcontext = webDbContext.GetDBContext();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel mode)
        {
            var data = _dbcontext.NhanViens.Where(x => x.TenDangNhap.Equals(mode.UserName) && x.MatKhau.Equals(mode.PassWord)).FirstOrDefault();

            if (data != null)
            {
                NhanVien nhanVien = new NhanVien()
                {
                    Ma=data.Ma,
                    HoTen=data.HoTen,
                    TenDangNhap=data.TenDangNhap,
                    CMND=data.CMND,
                    MatKhau=data.MatKhau,
                    NgaySinh=data.NgaySinh,
                    SDT=data.SDT
                };
                Session["Account"] = nhanVien;
                return Json(new { result = true });
            }
            return Json(new { result = false });
        }
    }
}