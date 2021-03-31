using InmobiliariaHernandez.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InmobiliariaHernandez.Controllers
{
    public class PropietarioController : Controller
    {
        private PropietarioRepositorio propietarioRespositorio;

        // Var para el PropietarioRepositorio


        public PropietarioController()
        {
            propietarioRespositorio = new PropietarioRepositorio();
        }

        // GET: PropietarioController
        public ActionResult Index()
        {
            var listaPropietarios = propietarioRespositorio.ObtenerTodos();
            return View(listaPropietarios);
        }

        // GET: PropietarioController/Details/5
        public ActionResult Details(int id)
        {
            Propietario propietario = propietarioRespositorio.BuscarPropietario(id);
            return View(propietario);
        }

        // GET: PropietarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PropietarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Propietario propietario)
        {
            propietarioRespositorio.Alta(propietario);
            return RedirectToAction(nameof(Index));
        }

        // GET: PropietarioController/Edit/5
        public ActionResult Edit(int id)
        {
            Propietario propietario = propietarioRespositorio.BuscarPropietario(id);
            return View(propietario);
        }

        // POST: PropietarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Propietario propietario)
        {
            propietarioRespositorio.Modificacion(propietario);
            return RedirectToAction(nameof(Index));
            
        }

        // GET: PropietarioController/Delete/5
        public ActionResult Delete(int id)
        {
            Propietario propietario = propietarioRespositorio.BuscarPropietario(id);
            return View(propietario);
        }

        // POST: PropietarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Propietario propietario)
        {
            propietarioRespositorio.Baja(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
