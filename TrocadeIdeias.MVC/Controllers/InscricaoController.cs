using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrocadeIdeias.MVC.Models;

namespace TrocadeIdeias.MVC.Controllers
{
    public class InscricaoController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Inscricao
        public async Task<ActionResult> Index()
        {
            var inscricoes = db.Inscricoes.Include(i => i.Curso).Include(i => i.Turma);
            return View(await inscricoes.ToListAsync());
        }

        // GET: Inscricao/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inscricao inscricao = await db.Inscricoes.FindAsync(id);
            if (inscricao == null)
            {
                return HttpNotFound();
            }
            return View(inscricao);
        }

        // GET: Inscricao/Create
        public ActionResult Create(int Id)
        {
            ViewBag.IdCurso = new SelectList(db.Turmas.Include(x => x.Curso).Where(x => x.IdTurma == Id).ToList(), "Curso.IdCurso", "Curso.Titulo");
            ViewBag.IdTurma = new SelectList(db.Turmas.Where(x => x.IdTurma == Id).ToList(), "IdTurma", "DescResponsavel", Id);
            return View();
        }

        public ActionResult InscricaoSucess(int Id)
        {
            @ViewBag.Id = Id;
            return View();
        }

        // POST: Inscricao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdInscricao,Matricula,IdCurso,IdTurma,DescArea,DescCargo,Telefone")] Inscricao inscricao)
        {
            if (ModelState.IsValid)
            {
                var verificacao = db.Inscricoes.Where(x => x.Matricula == inscricao.Matricula && x.IdTurma == inscricao.IdTurma && x.IdCurso == inscricao.IdCurso).ToList();
                if (verificacao.Count == 0)
                {
                    db.Inscricoes.Add(inscricao);
                    await db.SaveChangesAsync();
                    @ViewBag.Erro = "";
                    return RedirectToAction("InscricaoSucess/" + inscricao.IdInscricao);
                }
                else {
                    TempData["Erro"] = "Prezado(a), sua inscrição já foi realizada anteriormente.";
                    return RedirectToAction("InscricaoSucess/" + 0);
                }
            }

            ViewBag.IdCurso = new SelectList(db.Cursos, "IdCurso", "Titulo", inscricao.IdCurso);
            ViewBag.IdTurma = new SelectList(db.Turmas, "IdTurma", "HorarioInicio", inscricao.IdTurma);
            return View(inscricao);
        }

        // GET: Inscricao/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inscricao inscricao = await db.Inscricoes.FindAsync(id);
            if (inscricao == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCurso = new SelectList(db.Cursos, "IdCurso", "DescCurso", inscricao.IdCurso);
            ViewBag.IdTurma = new SelectList(db.Turmas, "IdTurma", "DescResponsavel", inscricao.IdTurma);
            return View(inscricao);
        }

        // POST: Inscricao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdInscricao,Matricula,IdCurso,IdTurma,DescArea,DescCargo,Telefone")] Inscricao inscricao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inscricao).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdCurso = new SelectList(db.Cursos, "IdCurso", "DescCurso", inscricao.IdCurso);
            ViewBag.IdTurma = new SelectList(db.Turmas, "IdTurma", "DescResponsavel", inscricao.IdTurma);
            return View(inscricao);
        }

        // GET: Inscricao/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inscricao inscricao = await db.Inscricoes.FindAsync(id);
            if (inscricao == null)
            {
                return HttpNotFound();
            }
            return View(inscricao);
        }

        // POST: Inscricao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Inscricao inscricao = await db.Inscricoes.FindAsync(id);
            db.Inscricoes.Remove(inscricao);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
