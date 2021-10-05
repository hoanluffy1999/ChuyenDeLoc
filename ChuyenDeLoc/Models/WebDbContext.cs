using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChuyenDeLoc.Models
{
    public  class WebDbContext
    {
        public QLCayCanhEntities Instanse { get; }
        public WebDbContext()
        {
            if(Instanse == null)
            {
               Instanse = new QLCayCanhEntities();
            } 
        }
    }
}