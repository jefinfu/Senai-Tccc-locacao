﻿using System.ComponentModel.DataAnnotations;

namespace lazergo.Dto
{
    public class LoginDto
    {
        [Required(ErrorMessage ="Insira um Email")]
        public string Email {  get; set; }
        [Required(ErrorMessage = "Insira uma Senha")]
        public string Senha {  get; set; }

    }
}
