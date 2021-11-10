using System;

namespace ChuyenDeLoc.Models
{
    public class BaoCaoNhapViewModel
    {
        public string TenSanPham { get; set; }

        public int SoLuong { get; set; }

        public long GiaNhap { get; set; }

        public DateTime NgayNhap { get; set; }

        public int MaNCC { get; set; }
        public string NCC { get; set; }

        public string NhanVien { get; set; }

        public long ThanhTien
        {
            get
            {
                return SoLuong * GiaNhap;
            }
        }
    }
}