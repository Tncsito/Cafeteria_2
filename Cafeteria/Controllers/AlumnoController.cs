using Cafeteria.Datos;
using Cafeteria.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cafeteria.Controllers
{
    public class AlumnoController : Controller
    {
        UsuarioDatos _UsuarioDatos = new UsuarioDatos();
        CarreraDatos _CarreraDatos = new CarreraDatos();
        public IActionResult Index() //Esto es para el inicio de sesión (Esta obviamente es la pagina principal)
        {
            return View();
        }
        [HttpGet]
        public IActionResult ListarAlumno(AlumnoModel model) //Esta es la pagina para registrar al alumno (No hay para empleado, se sube directamente desde la base de datos)
        {
            var respuesta = _UsuarioDatos.ListarAlumno();
            return View(respuesta);
        }
        [HttpGet]
        public IActionResult Registrarse() //Esto es para el inicio de sesión (Esta obviamente es la pagina principal)
        {
            ViewBag.Carreras = _CarreraDatos.ListarCarrera();
            //Esta es para mostrar el formulario
            return View();
        }
        [HttpPost]
        public IActionResult Registrarse(AlumnoModel model) //Esto es para el inicio de sesión (Esta obviamente es la pagina principal)
        {
            if(!ModelState.IsValid)
            {
                ViewBag.Carreras = _CarreraDatos.ListarCarrera();
                return View();
            }
            bool respuesta = _UsuarioDatos.RegistrarAlumno(model);
            if(respuesta)
            {
                return RedirectToAction("ListarAlumno");
            } else
            {
                ViewBag.Carreras = _CarreraDatos.ListarCarrera();
                return View();
            }
        }
        [HttpGet]
        public IActionResult EditarAlumno(int Nss)
        {
            //Para obtener y mostrar el contacto a modificar
            AlumnoModel _Alumno = _UsuarioDatos.BuscarAlumno(Nss);

            return View(_Alumno);
        }
        [HttpPost]
        public IActionResult EditarAlumno(AlumnoModel model) 
        { 
            //para obtener los datos que se editaron del formulario y enviarlo en la base de datos
            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = _UsuarioDatos.EditarAlumno(model);
            if (respuesta) 
            {
                return RedirectToAction("ListarAlumno");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public IActionResult EliminarAlumno(int Nss)
        {
            //Para obtener y mostrar el contacto a eliminar
            AlumnoModel _Alumno = _UsuarioDatos.BuscarAlumno(Nss);

            return View(_Alumno);
        }
        [HttpPost]
        public IActionResult EliminarAlumno(AlumnoModel model)
        {
            //para obtener los datos que se van a eliminar del formulario y enviarlo en la base de datos
            var respuesta = _UsuarioDatos.EliminarAlumno(model.Nss);
            if (respuesta)
            {
                return RedirectToAction("ListarAlumno");
            }
            else
            {
                return View();
            }
        }
    }
}
