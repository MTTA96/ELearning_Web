using ELearning.Models;
using ELearning.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ELearning.Controllers
{
    public class KhoaHocController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public KhoaHocController()
        {
            _dbContext = new ApplicationDbContext();
        }

        // GET: KhoaHoc
        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new KhoaHocViewModel
            {
                DanhSachBuoi = _dbContext.DanhSachBuoi.ToList(),
                DanhSachThu = _dbContext.DanhSachThu.ToList()
            };
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(KhoaHocViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.DanhSachBuoi = _dbContext.DanhSachBuoi.ToList();
                return View("Create", viewModel);
            }
            var khoaHoc = new KhoaHoc
            {
                ThanhVienId = User.Identity.GetUserId(),
                Mon = viewModel.Mon,
                NgayDang = DateTime.Now,
                DiaDiem = viewModel.DiaDiem,
                BuoiId = viewModel.Buoi,
                ThuId = viewModel.Thu,
                SoBuoi = viewModel.SoBuoi,
                HocPhi = viewModel.HocPhi
            };
            _dbContext.DanhSachKhoaHoc.Add(khoaHoc);
            _dbContext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}