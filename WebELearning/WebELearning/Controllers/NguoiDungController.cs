using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebELearning.Models;

namespace WebELearning.Controllers
{
    public class NguoiDungController :Controller
    {
        GIASUEntities db=new GIASUEntities();
        // GET: NguoiDung
        [HttpGet]
        public ActionResult DangNhap()
        {

            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
            String sTaiKhoan = f["txtTaiKhoan"].ToString();
            String sMatKhau = f.Get("txtMatKhau").ToString();
            NguoiDung nd = db.NguoiDungs.SingleOrDefault(n => n.TaiKhoan == sTaiKhoan && n.MatKhau == sMatKhau);
            if (nd != null && sTaiKhoan != "Admin" && sMatKhau != "123456")
            {
                ViewBag.ThongBao = "Chúc mừng đăng nhập thành công!";
                Session["TaiKhoan"] = nd.HoTen;
                Session["MaKhachHang"] = nd.IDNguoiDung;
                Session["TaiKhoan1"] = nd;
                return RedirectToAction("WebELearning", "Home");
            }
            else
            {
                Admin am = db.Admins.SingleOrDefault(n => n.TaikhoanAdmin == sTaiKhoan && n.MatkhauAdmin == sMatKhau);

                if (am != null)
                {
                    ViewBag.ThongBao = "Chúc mừng đăng nhập thành công!";
                    Session["TaiKhoanAdmin"] = am;
                    return RedirectToAction("TrangAdmin", "Admin");
                }
            }
            ViewBag.ThongBao = "Tên tài khoản hoặc mật khẩu không đúng";
            return View();
        }
        public ActionResult DangXuat()
        {
            Session["TaiKhoan"] = null;
            Session["MaKhachHang"] = null;
            return RedirectToAction("WebELearning","Home");
        }

        public ActionResult Dangki()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Dangki(NguoiDung model)
        {
            try
            {


                db.NguoiDung.Add(model);
                db.SaveChanges();
                ModelState.AddModelError("", "Đăng ký thành công !");



            }
            catch
            {
                ModelState.AddModelError("", "Đăng ký thất bại !");
            }
            return View();
        }

    }
    }
}