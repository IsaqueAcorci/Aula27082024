﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Aula27082024.Models
{
    public class Logradouro : Base
    {
        [Required]
        public string Cep { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        [Required]
        public string Cidade { get; set; }
        [Required]
        public string Estado { get; set; }
        [Required]
        public string Pais { get; set; }
        
    }
}