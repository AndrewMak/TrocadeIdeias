using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrocadeIdeias.MVC.Models
{
    public class InteresseCurso
    {
        [Key]
        public int Matricula { get; set; }
        public string DescCursos { get; set; }
    }
}