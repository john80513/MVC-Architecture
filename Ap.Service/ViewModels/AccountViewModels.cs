using System.ComponentModel.DataAnnotations;

namespace AP.Service.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "帳號")]
        public string UserID { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "密碼")]
        public string Password { get; set; }

        [Display(Name = "記住我?")]
        public bool RememberMe { get; set; }
    }

    public class PasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "現有密碼")]
        public string OldPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "新密碼")]
        public string NewPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("NewPassword", ErrorMessage = "請輸入相同密碼")]
        [Display(Name = "確認密碼")]
        public string CheckPassword { get; set; }
    }
}
