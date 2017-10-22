using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ELearning.Models
{
    public class KhoaHoc
    {
        public int Id { get; set; }

        public bool IsCanceled { get; set; }

        public ApplicationUser ThanhVien { get; set; }

        [Required]
        public string ThanhVienId { get; set; }

        [Required]
        public string Mon { get; set; }

        [Required]
        [StringLength(255)]
        public string DiaDiem { get; set; }

        public DateTime NgayDang { get; set; }

        [Required]
        public byte BuoiId { get; set; }
        public Buoi Buoi { get; set; }
        public int SoBuoi { get; set; }

        [Required]
        public byte ThuId { get; set; }
        public Thu Thu { get; set; }

        [Required]
        public double HocPhi { get; set; }
    }
}