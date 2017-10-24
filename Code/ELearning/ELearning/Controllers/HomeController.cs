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
                .Include(c => c.Thu);

            var viewModel = new DanhSachKhoaHocViewModel
            {
                UpCommingCourses = danhSachKhoaHoc,
                DanhSachBuoi = _dbContext.DanhSachBuoi.ToList()
                //DanhSachThu = _dbContext.DanhSachThu.ToList()
            };

            //ViewBag.Search = danhSachKhoaHoc;
            return View(viewModel);
        }

        //[HttpPost]
        //public ActionResult Index(DanhSachKhoaHocViewModel skhoaHocViewModel,string searchKey)
        //{
        //    var viewModel = new KhoaHocViewModel
        //    {
        //        DanhSachBuoi = _dbContext.DanhSachBuoi.ToList()
        //        //DanhSachThu = _dbContext.DanhSachThu.ToList()
        //    };
        //    var khoaHoc = new KhoaHoc
        //    {
        //        BuoiId = khoaHocViewModel.Buoi 
        //        //ThuId = khoaHocViewModel.Thu
          
        //    };

        //    var danhSachKhoaHoc = _dbContext.DanhSachKhoaHoc
        //       .Where(c => !c.IsCanceled)
        //       .Include(c => c.ThanhVien)
        //       .Include(c => c.Buoi)
        //       .Include(c => c.Thu).Where(kh => kh.Mon.Contains(searchKey)).Where(kh => kh.BuoiId == khoaHoc.BuoiId);
            
        //    ViewBag.Search = danhSachKhoaHoc;
        //    return View(viewModel);
        //}
        

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