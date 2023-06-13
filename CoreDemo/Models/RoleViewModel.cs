﻿using System.ComponentModel.DataAnnotations;

namespace CoreDemo.Models
{
    public class RoleViewModel
    {
        [Required(ErrorMessage="Lütfen Role Adı Giriniz.")]
        public string name{ get; set; }
    }
}
