using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication37.Models
{
    public class Register
    {
        [Required]
        [Display(Name="Ad")]
        public string Name { get; set; }
        [Required]
        [Display(Name ="Soyad")]
        public string Surname { get; set; }
        [Required]
        [Display(Name ="Kullanıcı Adı")]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Display (Name ="Şifre")]
        public string Password { get; set; }
        [Required]
        [Display(Name ="Şifre Tekrar")]
        [Compare("Password",ErrorMessage ="Şifreler uyuşmuyor")]
        public string ConfirmPassword { get; set; }
    }
}