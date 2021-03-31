using InmobiliariaHernandez.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InmobiliariaHernandez.Controllers
{
    public class InquilinoController : Controller
    {
        private InquilinoRepositorio inquilinoRepositorio;

        public InquilinoController()
        {
            inquilinoRepositorio = new InquilinoRepositorio();
        }

        // GET: InquilinoController
        public ActionResult Index()
        {
            var listaInquilinos = inquilinoRepositorio.ObtenerTodos();
            return View(listaInquilinos);
        }

        // GET: InquilinoController/Details/5
        public ActionResult Details(int id)
        {
            Inquilino inquilino = inquilinoRepositorio.BuscarInquilino(id);
            return View(inquilino);
        }

        // GET: InquilinoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InquilinoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Inquilino inquilino)
        {
            inquilinoRepositorio.Alta(inquilino);
            return RedirectToAction(nameof(Index));
        }

        // GET: InquilinoController/Edit/5
        public ActionResult Edit(int id)
        {
            Inquilino inquilino = inquilinoRepositorio.BuscarInquilino(id);
            return View(inquilino);
        }

        // POST: InquilinoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Inquilino inquilino)
        {
            inquilinoRepositorio.Modificacion(inquilino);
            return RedirectToAction(nameof(Index));

        }

        // GET: InquilinoController/Delete/5
        public ActionResult Delete(int id)
        {
            Inquilino inquilino = inquilinoRepositorio.BuscarInquilino(id);
            return View(inquilino);
        }

        // POST: InquilinoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Inquilino inquilino)
        {
            inquilinoRepositorio.Baja(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
