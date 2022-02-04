﻿using System.ComponentModel.DataAnnotations;

namespace EsercitazioneFinale.Cracco.MVC.Models
{
    public class UserViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }   
        public string ReturnUrl { get; set; }
    }
}