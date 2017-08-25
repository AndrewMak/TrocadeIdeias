using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrocadeIdeias.MVC.Models
{
    public class Curso
    {
        [Key]
        [Display(Name = "Código do Curso")]
        public int IdCurso { get; set; }
        [Display(Name = "Título do Curso")]

        public string Titulo { get; set; }
        [Display(Name = "Descrição")]

        public string DescCurso { get; set; }
    }
}