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
    
    public partial class KhuVuc
    {
        public KhuVuc()
        {
            this.BaiDangs = new HashSet<BaiDang>();
        }
    
        public int IDKhuVuc { get; set; }
        public string TenKhuVuc { get; set; }
    
        public virtual ICollection<BaiDang> BaiDangs { get; set; }
    }
}
