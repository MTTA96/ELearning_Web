using ELearning.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ELearning.Controllers.Api
{
    public class KhoaHocController : ApiController
    {
        public ApplicationDbContext _dbContext { get; set; }
        public KhoaHocController()
        {
            _dbContext = new ApplicationDbContext();
        }

        [HttpDelete]
        public IHttpActionResult HuyKhoaHoc (int id)
        {
            var thanhVienId = User.Identity.GetUserId();
            var khoaHoc = _dbContext.DanhSachKhoaHoc.Single(c => c.Id == id && c.ThanhVienId == thanhVienId);

            if (khoaHoc.IsCanceled)
                return NotFound();
            khoaHoc.IsCanceled = true;
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
