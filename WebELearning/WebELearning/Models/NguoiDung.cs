//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebELearning.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class NguoiDung
    {
        public NguoiDung()
        {
            this.BaiDangs = new HashSet<BaiDang>();
        }
    
        public int IDNguoiDung { get; set; }
        public byte[] Avatar { get; set; }
        public string HoTen { get; set; }
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public Nullable<System.DateTime> NgaySinh { get; set; }
        public Nullable<int> GioiTinh { get; set; }
        public string TrinhDo { get; set; }
        public string BangCap { get; set; }
        public string NgheNghiep { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public Nullable<int> SDT { get; set; }
        public Nullable<int> IDLoaiND { get; set; }
    
        public virtual ICollection<BaiDang> BaiDangs { get; set; }
        public virtual LoaiND LoaiND { get; set; }
    }
}
