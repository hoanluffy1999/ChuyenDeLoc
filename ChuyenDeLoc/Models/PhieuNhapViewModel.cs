using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChuyenDeLoc.Models
{
    public class PhieuNhapViewModel
    {
        public int Ma { get; set; }
        public long? tongTien { get; set; }
        public Nullable<int> MaNV { get; set; }
        public Nullable<System.DateTime> NgayNhap { get; set; }
        public Nullable<int> MaNCC { get; set; }
        public virtual NhaCungCap NhaCungCap { get; set; }
        public virtual NhanVien NhanVien { get; set; }
        public virtual ICollection<ChiTiepPhieuNhap> ChiTiepPhieuNhaps { get; set; }
    }
}