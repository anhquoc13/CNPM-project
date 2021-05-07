using Domain.Entities;
using Application.DTO;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Application.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Biệt danh không được phép để trống")]
        [RegularExpression(@".{5,}", ErrorMessage = "Biệt danh ít nhất 5 ký tự")]
        public string Tagname { get; set; }
        [Required(ErrorMessage = "Email không được phép để trống")]
        [RegularExpression(@"[a-zA-Z0-9\-_]+@+[a-zA-Z]+\.+[a-z]+$", ErrorMessage = "Email sai định dạng")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Mật khẩu không được phép để trống")]
        [RegularExpression(@".{5,}", ErrorMessage = "Mật khẩu ít nhất 5 ký tự")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Nhập lại mật khẩu không được phép để trống")]
        [RegularExpression(@".{5,}", ErrorMessage = "Mật khẩu ít nhất 5 ký tự")]
        public string ConfirmPassword { get; set; }
        public string contry { get; set; }
        public User user { get; set; }
        public User edit { get; set; }
        public UserDto owner { get; set; }
        [Required(ErrorMessage = "Phân quyền!")]
        public string userRole { get; set; }
        [Required(ErrorMessage = "Nhập tình trạng!")]
        public string userStatus { get; set; }
        public List<SetsViewModel> setList { get; set; }
        public List<FoldersViewModel> folderList { get; set; }
        public List<ClassesViewModel> classList { get; set; }

    }
}