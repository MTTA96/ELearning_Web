using ELearning.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ELearning.ViewModels
{
    public class KhoaHocViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Mon { get; set; }

        [Required]
        public byte DiaDiem { get; set; }

        [Required]
        public int SoBuoi { get; set; }

        [Required]
        public double HocPhi { get; set; }

        [Required]
        public byte Buoi { get; set; }
        [Required]
        public byte Thu { get; set; }
        public IEnumerable<Buoi> DanhSachBuoi { get; set; }
        public IEnumerable<Thu> DanhSachThu { get; set; }
        public IEnumerable<DiaDiem> DanhSachDiaDiem { get; set; }

        public string Heading { get; set; }
        public string Action
        {
            get { return (Id != 0) ? "CapNhatKhoaHoc" : "Create"; }
        }
    }
}