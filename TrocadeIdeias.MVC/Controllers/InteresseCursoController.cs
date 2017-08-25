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
    public class InteresseCursoController : Controller
    {
        private Contexto db = new Contexto();

        // GET: InteresseCurso
        public async Task<ActionResult> Index()
        {
            return View(await db.InteresseCursoes.ToListAsync());
        }

        // GET: InteresseCurso/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InteresseCurso interesseCurso = await db.InteresseCursoes.FindAsync(id);
            if (interesseCurso == null)
            {
                return HttpNotFound();
            }
            return View(interesseCurso);
        }

        // GET: InteresseCurso/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InteresseCurso/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Matricula,DescCursos")] InteresseCurso interesseCurso)
        {
            if (ModelState.IsValid)
            {
                db.InteresseCursoes.Add(interesseCurso);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(interesseCurso);
        }

        // GET: InteresseCurso/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InteresseCurso interesseCurso = await db.InteresseCursoes.FindAsync(id);
            if (interesseCurso == null)
            {
                return HttpNotFound();
            }
            return View(interesseCurso);
        }

        // POST: InteresseCurso/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Matricula,DescCursos")] InteresseCurso interesseCurso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(interesseCurso).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(interesseCurso);
        }

        // GET: InteresseCurso/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InteresseCurso interesseCurso = await db.InteresseCursoes.FindAsync(id);
            if (interesseCurso == null)
            {
                return HttpNotFound();
            }
            return View(interesseCurso);
        }

        // POST: InteresseCurso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            InteresseCurso interesseCurso = await db.InteresseCursoes.FindAsync(id);
            db.InteresseCursoes.Remove(interesseCurso);
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
