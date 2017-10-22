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
            var viewModel = new KhoaHocViewModel
            {
                DanhSachBuoi = _dbContext.DanhSachBuoi.ToList(),
                DanhSachThu = _dbContext.DanhSachThu.ToList()
            };
            var listCourse = from kh in _dbContext.DanhSachKhoaHoc select kh;
            ViewBag.Search = listCourse;
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Index(KhoaHocViewModel khoaHocViewModel,string searchKey)
        {
            var viewModel = new KhoaHocViewModel
            {
                DanhSachBuoi = _dbContext.DanhSachBuoi.ToList(),
                DanhSachThu = _dbContext.DanhSachThu.ToList()
            };
            var khoaHoc = new KhoaHoc
            {
                BuoiId = khoaHocViewModel.Buoi ,
                ThuId = khoaHocViewModel.Thu
          
            };

            var listSearch = from kh in _dbContext.DanhSachKhoaHoc select kh;
            if (!String.IsNullOrEmpty(searchKey) || khoaHoc.BuoiId != null)
            {
                listSearch = listSearch.Where(kh => kh.Mon.Contains(searchKey)).Where(kh=>kh.BuoiId==khoaHoc.BuoiId).Where(kh=>kh.ThuId==khoaHoc.ThuId);
            }
            ViewBag.Search = listSearch;
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