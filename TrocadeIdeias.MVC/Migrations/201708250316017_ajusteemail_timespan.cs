namespace TrocadeIdeias.MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajusteemail_timespan : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Curso",
                c => new
                    {
                        IdCurso = c.Int(nullable: false, identity: true),
                        Titulo = c.String(),
                        DescCurso = c.String(),
                    })
                .PrimaryKey(t => t.IdCurso);
            
            CreateTable(
                "dbo.Inscricao",
                c => new
                    {
                        IdInscricao = c.Int(nullable: false, identity: true),
                        Matricula = c.Int(nullable: false),
                        Nome = c.String(),
                        IdCurso = c.Int(nullable: false),
                        IdTurma = c.Int(nullable: false),
                        DescArea = c.String(),
                        DescCargo = c.String(),
                        Telefone = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.IdInscricao)
                .ForeignKey("dbo.Curso", t => t.IdCurso)
                .ForeignKey("dbo.Turma", t => t.IdTurma)
                .Index(t => t.IdCurso)
                .Index(t => t.IdTurma);
            
            CreateTable(
                "dbo.Turma",
                c => new
                    {
                        IdTurma = c.Int(nullable: false, identity: true),
                        IdCurso = c.Int(nullable: false),
                        DescResponsavel = c.String(),
                        DataCuso = c.DateTime(nullable: false),
                        HorarioInicio = c.Time(nullable: false, precision: 7),
                        HorarioFim = c.Time(nullable: false, precision: 7),
                        IsInscricaoAberta = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdTurma)
                .ForeignKey("dbo.Curso", t => t.IdCurso)
                .Index(t => t.IdCurso);
            
            CreateTable(
                "dbo.InteresseCurso",
                c => new
                    {
                        Matricula = c.Int(nullable: false, identity: true),
                        DescCursos = c.String(),
                    })
                .PrimaryKey(t => t.Matricula);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inscricao", "IdTurma", "dbo.Turma");
            DropForeignKey("dbo.Turma", "IdCurso", "dbo.Curso");
            DropForeignKey("dbo.Inscricao", "IdCurso", "dbo.Curso");
            DropIndex("dbo.Turma", new[] { "IdCurso" });
            DropIndex("dbo.Inscricao", new[] { "IdTurma" });
            DropIndex("dbo.Inscricao", new[] { "IdCurso" });
            DropTable("dbo.InteresseCurso");
            DropTable("dbo.Turma");
            DropTable("dbo.Inscricao");
            DropTable("dbo.Curso");
        }
    }
}
