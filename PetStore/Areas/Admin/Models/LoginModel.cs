using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetStore.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Xin mời nhập Username")]
        public String Username { get; set; }
        [Required(ErrorMessage = "Xin mời nhập Password")]
        public String Password { get; set; }
        public bool RememberPass { get; set; }


    }
}