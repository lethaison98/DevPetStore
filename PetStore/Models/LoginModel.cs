using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetStore.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "UserName không được để trống")]
        public String Username { get; set; }
        [Required(ErrorMessage = "Password không được để trống")]
        public String Password { get; set; }
        public bool RememberPass { get; set; }


    }
}