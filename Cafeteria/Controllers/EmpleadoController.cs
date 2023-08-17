using Cafeteria.Datos;
using Cafeteria.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cafeteria.Controllers
{
    public class EmpleadoController : Controller
    {
        //Como no usamos el controlador para los sp cambiamos a que solo use datos
        EmpleadoDatos _EmpleadoDatos = new EmpleadoDatos();

        public IActionResult Index() //Esto es para el inicio de sesión (Esta obviamente es la pagina principal)
        {
            return View();
        }
        [HttpGet]
        public IActionResult ListarEmpleado(EmpleadoModel model) //Esta es la pagina para registrar al alumno (No hay para empleado, se sube directamente desde la base de datos)
        {
            var respuesta = _EmpleadoDatos.ListarEmpleado();
            return View(respuesta);
        }
        [HttpGet]
        public IActionResult RegistrarEmpleado() //Esto es para el inicio de sesión (Esta obviamente es la pagina principal)
        {
            //Esta es para mostrar el formulario
            return View();
        }
        [HttpPost]
        public IActionResult RegistrarEmpleado(EmpleadoModel model) //Esto es para el inicio de sesión (Esta obviamente es la pagina principal)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            bool respuesta = _EmpleadoDatos.RegistrarEmpleado(model);
            if (respuesta)
            {
                return RedirectToAction("ListarEmpleado");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public IActionResult EditarEmpleado(int Id)
        {
            //Para obtener y mostrar el contacto a modificar
            EmpleadoModel _Empleado = _EmpleadoDatos.BuscarEmpleado(Id);

            return View(_Empleado);
        }
        [HttpPost]
        public IActionResult EditarEmpleado(EmpleadoModel model)
        {
            //para obtener los datos que se editaron del formulario y enviarlo en la base de datos
            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = _EmpleadoDatos.EditarEmpleado(model);
            if (respuesta)
            {
                return RedirectToAction("ListarEmpleado");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public IActionResult EliminarEmpleado(int Id)
        {
            //Para obtener y mostrar el contacto a eliminar
            EmpleadoModel _Empleado = _EmpleadoDatos.BuscarEmpleado(Id);

            return View(_Empleado);
        }
        [HttpPost]
        public IActionResult EliminarEmpleado(EmpleadoModel model)
        {
            //para obtener los datos que se van a eliminar del formulario y enviarlo en la base de datos
            var respuesta = _EmpleadoDatos.EliminarEmpleado(model.Id);
            if (respuesta)
            {
                return RedirectToAction("ListarEmpleado");
            }
            else
            {
                return View();
            }
        }

    }
}
