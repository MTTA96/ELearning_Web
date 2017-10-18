using ELearning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace ELearning.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _dbContext;

        public HomeController()
        {
            _dbContext = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var danhSachKhoaHoc = _dbContext.DanhSachKhoaHoc
                .Include(c => c.ThanhVien)
                .Include(c => c.Buoi)
                .Include(c => c.Thu);

            return View(danhSachKhoaHoc);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Developed by EWays.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Email: eways.elearning@gmail.com.";

            return View();
        }
    }
}