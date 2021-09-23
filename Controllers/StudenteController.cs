using StudentiMVC_CRUD.Models;
using StudentiMVC_CRUD.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentiMVC_CRUD.Controllers
{
    public class StudenteController : Controller
    {
        private readonly StudentService studentService;

        public StudenteController()
        {
            studentService = new StudentService();
        }

        // GET: Studente
        public ActionResult Index()
        {
            List<Studente> studenti = studentService.GetAll();

            return View();
        }

        // GET: Studente/Details/5
        public ActionResult Details(int id)
        {
            Studente studente = studentService.GetStudente(id);

            if (studente != null)
            {
                return View(studente);
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }

        // GET: Studente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Studente/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Studente/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Studente/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Studente/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Studente/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
