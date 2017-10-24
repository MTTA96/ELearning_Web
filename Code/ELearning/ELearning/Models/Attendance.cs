
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ELearning.Models
{
    public class Attendance
    {
        public KhoaHoc KhoaHoc { get; set; }

        [Key]
        [Column(Order = 1)]
        public int KhoaHocId { get; set; }

        public ApplicationUser Attendee { get; set; }

        [Key]
        [Column(Order = 2)]
        public string AttendeeId { get; set; }
    }
}