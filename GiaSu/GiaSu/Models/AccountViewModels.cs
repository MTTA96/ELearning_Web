﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GiaSu.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Tài Khoản")]
        public string TaiKhoan { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Tài Khoản")]
        public string TaiKhoan { get; set; }
    }

    public class LoginViewModel
    {

        [Required]
        [Display(Name = "Tài Khoản")]
        public string TaiKhoan { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Mật Khẩu")]
        public string MatKhau { get; set; }

        [Display(Name = "Nhớ Tài Khoản")]
        public bool NhoTK { get; set; }
    }

    public class RegisterViewModel
    {
        [Key]
        public int IDThanhVien { get; set; }
        [Required]
        [Display(Name = "Avatar")]
        public string Avartar { get; set; }
        [Required]
        [Display(Name = "Họ và tên")]
        public string HoTen { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Tài Khoản")]
        public string TaiKhoan { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Mật Khẩu")]
        public string MatKhau { get; set; }
        //[DataType(DataType.Password)]
        //[Display(Name = "Nhập Lại Mật Khẩu")]
        //[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        //public string NhapLaiMK { get; set; }
        [Required]
        [Display(Name = "Năm Sinh")]
        public string NamSinh { get; set; }
        [Required]
        [Display(Name = "Giới Tính")]
        public string GioiTinh { get; set; }
        [Required]
        [Display(Name = "Trình Độ")]
        public string TrinhDo { get; set; }
        [Required]
        [Display(Name = "Bằng Cấp")]
        public string BangCap { get; set; }
        [Required]
        [Display(Name = "Nghề nghiệp")]
        public string NgheNghiep { get; set; }
        [Required]
        [Display(Name = "Địa Chỉ")]
        public string DiaChi { get; set; }
        [Required]
        [Display(Name = "SĐT")]
        public string SDT { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Tài Khoản")]
        public string TaiKhoan { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Mật Khẩu")]
        public string MatKhau { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Nhập Lại Mật Khẩu")]
        [Compare("MatKhau", ErrorMessage = "The password and confirmation password do not match.")]
        public string NhapLaiMK { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
