using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Tài khoản không được phép để trống")]
        [RegularExpression(@".{5,}", ErrorMessage = "Tài khoản ít nhất 5 ký tự")]
        public string id { get; set; }
        [Required(ErrorMessage = "Mật khẩu không được phép để trống")]
        [RegularExpression(@".{5,}", ErrorMessage = "Mật khẩu ít nhất 5 ký tự")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }
    }
}