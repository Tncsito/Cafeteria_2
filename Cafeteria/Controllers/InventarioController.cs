using Cafeteria.Datos;
using Cafeteria.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cafeteria.Controllers
{
    public class InventarioController : Controller
    {
        InventarioDatos _InventarioDatos = new InventarioDatos();
        public IActionResult Index() //Esto es para el inicio de sesión (Esta obviamente es la pagina principal)
        {
            return View();
        }
        [HttpGet]
        public IActionResult ListarInventario(InventarioModel model) //Esta es la pagina para registrar al alumno (No hay para Inventario, se sube directamente desde la base de datos)
        {
            var respuesta = _InventarioDatos.ListarInventario();
            return View(respuesta);
        }
        [HttpGet]
        public IActionResult RegistrarInventario() //Esto es para el inicio de sesión (Esta obviamente es la pagina principal)
        {
            //Esta es para mostrar el formulario
            return View();
        }
        [HttpPost]
        public IActionResult RegistrarInventario(InventarioModel model) //Esto es para el inicio de sesión (Esta obviamente es la pagina principal)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            bool respuesta = _InventarioDatos.RegistrarInventario(model);
            if (respuesta)
            {
                return RedirectToAction("ListarInventario");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public IActionResult EditarInventario(int Id)
        {
            //Para obtener y mostrar el contacto a modificar
            InventarioModel _Inventario = _InventarioDatos.BuscarInventario(Id);

            return View(_Inventario);
        }
        [HttpPost]
        public IActionResult EditarInventario(InventarioModel model)
        {
            //para obtener los datos que se editaron del formulario y enviarlo en la base de datos
            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = _InventarioDatos.EditarInventario(model);
            if (respuesta)
            {
                return RedirectToAction("ListarInventario");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public IActionResult EliminarInventario(int Id)
        {
            //Para obtener y mostrar el contacto a eliminar
            InventarioModel _Inventario = _InventarioDatos.BuscarInventario(Id);

            return View(_Inventario);
        }
        [HttpPost]
        public IActionResult EliminarInventario(InventarioModel model)
        {
            //para obtener los datos que se van a eliminar del formulario y enviarlo en la base de datos
            var respuesta = _InventarioDatos.EliminarInventario(model.Id);
            if (respuesta)
            {
                return RedirectToAction("ListarInventario");
            }
            else
            {
                return View();
            }
        }
    }
}
