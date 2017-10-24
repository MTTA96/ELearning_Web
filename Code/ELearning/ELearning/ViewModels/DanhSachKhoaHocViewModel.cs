﻿using ELearning.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ELearning.ViewModels
{
    public class DanhSachKhoaHocViewModel
    {
        public byte DiaDiem { get; set; }
        [Required]
        public double HocPhi { get; set; }
        [Required]
        public byte Buoi { get; set; }
        [Required]
        public byte Thu { get; set; }
        public IEnumerable<Buoi> DanhSachBuoi { get; set; }
        public IEnumerable<Thu> DanhSachThu { get; set; }
        public IEnumerable<KhoaHoc> UpCommingCourses { get; set; }
        public IEnumerable<DiaDiem> DanhSachDiaDiem { get; set; }
        public bool ShowAction { get; set; }
    }
}