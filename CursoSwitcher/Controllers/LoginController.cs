﻿using Microsoft.AspNetCore.Mvc;
using CursoSwitcher.Models;
using System.Diagnostics;

namespace CursoSwitcher.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        private bool UserValidation(String dni, String password)
        {
            /*Aqui vamos a hacer las validaciones con relación al usuario si está o no en la base de datos
             y si corresponde redirigirlo al dashboard.*/
            bool loged = false;
            if (!string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(dni))
            {
                if (dni == "123" && password == "123") {
                    loged = true;
                }
            }
            return loged;
        }


        [HttpPost]
        public IActionResult Index(String dni, String password)
        {
            Console.WriteLine("Component: {0} Message: {1} ", dni, password);

            if (UserValidation(dni, password))
            {
                TempData["Message"] = "Inicio de sesión correcto."; // Esto estaría bueno mostrarlo en un toast (bootstrap)
                return RedirectToAction("Index", "Dashboard");
            } else
            {
                TempData["Message"] = "No se encontró al alumno, verifique sus credenciales.";
                return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}