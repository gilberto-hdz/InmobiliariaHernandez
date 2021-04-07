using InmobiliariaBase.Models;
using InmobiliariaHernandez.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InmobiliariaHernandez.Controllers
{
    public class InmuebleController : Controller
    {
        private InmuebleRepositorio inmuebleRepositorio;
        private PropietarioRepositorio propietarioRepositorio;
        private readonly IConfiguration configuration;

        public InmuebleController(IConfiguration configuration)
        {
            this.configuration = configuration;
            inmuebleRepositorio = new InmuebleRepositorio(configuration);
            propietarioRepositorio = new PropietarioRepositorio(configuration);
        }
        // GET: InmuebleController
        public ActionResult Index()
        {
            List<Inmueble> lista = inmuebleRepositorio.ObtenerTodos();
            return View(lista);
        }

        // GET: InmuebleController/Details/5
        public ActionResult Details(int id)
        {
            Inmueble inmueble = inmuebleRepositorio.ObtenerInmueble(id);
            return View(inmueble);
        }

        // GET: InmuebleController/Create
        public ActionResult Create()
        {
            ViewData["Propietarios"] = propietarioRepositorio.ObtenerTodos();
            return View();
        }

        // POST: InmuebleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Inmueble inmueble)
        {
            try
            {
                inmuebleRepositorio.Alta(inmueble);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewData["Propietarios"] = propietarioRepositorio.ObtenerTodos();
                return View();
            }
        }

        // GET: InmuebleController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewData["Propietarios"] = propietarioRepositorio.ObtenerTodos();
            Inmueble inmueble = inmuebleRepositorio.ObtenerInmueble(id);
            return View(inmueble);
        }

        // POST: InmuebleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Inmueble inmueble)
        {
            try
            {
                inmuebleRepositorio.Modificar(inmueble);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(inmueble);
            }
        }

        // GET: InmuebleController/Delete/5
        public ActionResult Delete(int id)
        {
            Inmueble inmueble = inmuebleRepositorio.ObtenerInmueble(id);
            return View(inmueble);
        }

        // POST: InmuebleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Inmueble inmueble)
        {
            try
            {
                inmuebleRepositorio.Baja(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(inmueble);
            }
        }
    }
}
