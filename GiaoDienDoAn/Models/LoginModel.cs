using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GiaoDienDoAn.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Mời bạn nhập Tài Khoản")]//hiển thị thông báo khi không nhập username và password  
        public string TaiKhoan { set; get; }
        [Required(ErrorMessage = "Mời bạn nhập Mật Khẩu")]
        public string MatKhau { set; get; }
    }
}