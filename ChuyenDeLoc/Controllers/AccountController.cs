using ChuyenDeLoc.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ChuyenDeLoc.Controllers
{
    public class AccountController
    {
        private readonly QLCayCanhEntities db;
        public AccountController()
        {
            WebDbContext webDbContext = new WebDbContext();
            db = webDbContext.GetDBContext();
        }
       
    }
}