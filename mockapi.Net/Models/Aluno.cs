using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mockapi.Net.Models
{
    public class Aluno
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Logradouro { get; set; }
        [Required]
        public int? Numero { get; set; }
        [Required]
        public string  Bairro {get; set;}
        [Required]
        public string Cidade { get;set; }
        [Required]
        public string Estado { get; set; }
        
    }
}