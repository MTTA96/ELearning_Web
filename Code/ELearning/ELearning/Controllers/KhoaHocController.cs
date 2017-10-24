using ELearning.Models;
using ELearning.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
                DanhSachThu = _dbContext.DanhSachThu.ToList(),
                DanhSachDiaDiem=_dbContext.DanhSachDiaDiem.ToList(),
                Heading = "Them Khoa Hoc"
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
                DiaDiemId = viewModel.DiaDiem,
                BuoiId = viewModel.Buoi,
                ThuId = viewModel.Thu,
                SoBuoi = viewModel.SoBuoi,
                HocPhi = viewModel.HocPhi
            };
            _dbContext.DanhSachKhoaHoc.Add(khoaHoc);
            _dbContext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult KhoaHocCuaToi()
        {
            var thanhVienId = User.Identity.GetUserId();
            var danhSachKhoaHoc = _dbContext.DanhSachKhoaHoc
                .Where(c => c.ThanhVienId == thanhVienId && !c.IsCanceled)
                .Include(l => l.ThanhVien)
                .Include(c => c.Buoi)
                .Include(c => c.Thu)
                .ToList();

            return View(danhSachKhoaHoc);
        }

        [Authorize]
        public ActionResult SuaKhoaHoc(int id)
        {
            var thanhVienId = User.Identity.GetUserId();
            var khoaHoc = _dbContext.DanhSachKhoaHoc.Single(c => c.Id == id && c.ThanhVienId == thanhVienId);

            var viewModel = new KhoaHocViewModel
            {
                Mon = khoaHoc.Mon,
                DiaDiem = khoaHoc.DiaDiemId,
                Buoi = khoaHoc.BuoiId,
                Thu = khoaHoc.ThuId,
                SoBuoi = khoaHoc.SoBuoi,
                HocPhi = khoaHoc.HocPhi,
                DanhSachBuoi = _dbContext.DanhSachBuoi.ToList(),
                DanhSachThu = _dbContext.DanhSachThu.ToList(),
                Heading = "Sua Khoa Hoc",
                Id = khoaHoc.Id
            };

            return View( "Create", viewModel);
        }

        //Cập nhật khóa học
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CapNhatKhoaHoc(KhoaHocViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.DanhSachBuoi = _dbContext.DanhSachBuoi.ToList();
                viewModel.DanhSachThu = _dbContext.DanhSachThu.ToList();
                return View("Create", viewModel);
            }

            var thanhVienId = User.Identity.GetUserId();
            var khoaHoc = _dbContext.DanhSachKhoaHoc.Single(c => c.Id == viewModel.Id && c.ThanhVienId == thanhVienId);

            khoaHoc.Mon = viewModel.Mon;
            khoaHoc.DiaDiemId = viewModel.DiaDiem;
            khoaHoc.BuoiId = viewModel.Buoi;
            khoaHoc.ThuId = viewModel.Thu;
            khoaHoc.SoBuoi = viewModel.SoBuoi;
            khoaHoc.HocPhi = viewModel.HocPhi;

            _dbContext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}