using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrocadeIdeias.MVC.Models
{
    public class Turma
    {
        [Key]
        [Display(Name = "Código da Turma")]
        public int IdTurma { get; set; }
        [Display(Name = "Código do Curso")]
        public int IdCurso { get; set; }

        public virtual Curso Curso { get; set; }
        [Display(Name = "Nome do Responsável")]
        public string DescResponsavel { get; set; }
        [Display(Name = "Data de Início")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataCuso { get; set; }
        [Display(Name = "Horário de Início")]
        public TimeSpan HorarioInicio { get; set; }
        [Display(Name = "Horário de Fim")]
        public TimeSpan HorarioFim { get; set; }
        [Display(Name = "Status")]
        public bool IsInscricaoAberta { get; set; }

    }
}