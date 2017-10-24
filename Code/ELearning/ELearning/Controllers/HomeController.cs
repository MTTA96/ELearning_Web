using ELearning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ELearning.ViewModels;
using Microsoft.AspNet.Identity;

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
                .Where(c => !c.IsCanceled)
                .Include(c => c.ThanhVien)
                .Include(c => c.Buoi)
                .Include(c =>c.DiaDiem)
                .Include(c => c.Thu);

            var viewModel = new DanhSachKhoaHocViewModel
            {
                UpCommingCourses = danhSachKhoaHoc,
                DanhSachBuoi = _dbContext.DanhSachBuoi.ToList(),
                DanhSachDiaDiem = _dbContext.DanhSachDiaDiem.ToList(),
                DanhSachThu = _dbContext.DanhSachThu.ToList()
            };

            //ViewBag.Search = danhSachKhoaHoc;
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(DanhSachKhoaHocViewModel khoaHocViewModel, string searchKey)
        {
            var viewModel = new DanhSachKhoaHocViewModel
            {
                DanhSachBuoi = _dbContext.DanhSachBuoi.ToList(),
                DanhSachThu = _dbContext.DanhSachThu.ToList(),
                DanhSachDiaDiem = _dbContext.DanhSachDiaDiem.ToList()
            };

            if (searchKey == null)
            {
                return View(viewModel);
            }
            else {
                var danhSachKhoaHoc = _dbContext.DanhSachKhoaHoc
                   .Where(c => !c.IsCanceled)
                   .Include(c => c.ThanhVien)
                   .Include(c => c.Buoi)
                   .Include(c => c.Thu).Where(kh => kh.Mon.Contains(searchKey));
                viewModel.UpCommingCourses = danhSachKhoaHoc;
                ViewBag.Search = danhSachKhoaHoc;
            }
  
            return View(viewModel);
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