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
    public class TurmaController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Turma
        public async Task<ActionResult> Index(int? id)
        {
            if (String.IsNullOrEmpty(id.ToString()))
            {

                var turmas = db.Turmas.Include(t => t.Curso);
                @ViewBag.IdCurso = "";
                return View(await turmas.ToListAsync());
            }
            else
            {
                var turmas = db.Turmas.Where(x => x.IdCurso == id).Include(t => t.Curso);
                @ViewBag.IdCurso = id;
                return View(await turmas.ToListAsync());
            }

        }

        // GET: Turma/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Turma turma = await db.Turmas.Include(c => c.Curso).Where(x=>x.IdTurma == id).FirstAsync();
            if (turma == null)
            {
                return HttpNotFound();
            }
            return View(turma);
        }

        // GET: Turma/Create
        public ActionResult Create(int? id)
        {
            ViewBag.IdCurso = new SelectList(db.Cursos, "IdCurso", "Titulo", id);
            return View();
        }

        // POST: Turma/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdTurma,IdCurso,DescResponsavel,DataCuso,HorarioInicio,HorarioFim,IsInscricaoAberta")] Turma turma)
        {
            if (ModelState.IsValid)
            {
                db.Turmas.Add(turma);
                await db.SaveChangesAsync();
                return RedirectToAction("Index/" + turma.IdCurso);
            }

            ViewBag.IdCurso = new SelectList(db.Cursos, "IdCurso", "Titulo", turma.IdCurso);
            return View(turma);
        }

        // GET: Turma/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Turma turma = await db.Turmas.FindAsync(id);
            if (turma == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCurso = new SelectList(db.Cursos, "IdCurso", "Titulo", turma.IdCurso);
            return View(turma);
        }

        // POST: Turma/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdTurma,IdCurso,DescResponsavel,DataCuso,HorarioInicio,HorarioFim,IsInscricaoAberta")] Turma turma)
        {
            if (ModelState.IsValid)
            {
                db.Entry(turma).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdCurso = new SelectList(db.Cursos, "IdCurso", "Titulo", turma.IdCurso);
            return View(turma);
        }

        // GET: Turma/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Turma turma = await db.Turmas.FindAsync(id);
            if (turma == null)
            {
                return HttpNotFound();
            }
            return View(turma);
        }

        // POST: Turma/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Turma turma = await db.Turmas.FindAsync(id);
            db.Turmas.Remove(turma);
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
