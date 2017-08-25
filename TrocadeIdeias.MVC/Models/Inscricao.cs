using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrocadeIdeias.MVC.Models
{
    public class Inscricao
    {
        [Key]
        [Display(Name = "Código da Inscrição")]
        public int IdInscricao { get; set; }
        public int Matricula { get; set; }
        public string Nome { get; set; }
        public virtual Curso Curso { get; set; }
        [Display(Name = "Curso")]
        public int IdCurso { get; set; }
        public virtual Turma Turma { get; set; }
        [Display(Name = "Turma")]
        public int IdTurma { get; set; }
        [Display(Name = "Nome da Área")]
        public string DescArea { get; set; }
        [Display(Name = "Cargo")]
        public string DescCargo { get; set; }
        [Display(Name = "Ramal")]
        public string Telefone { get; set; }
        public string Email { get; set; }
        //adicionar o email.
    }
}