using Cafeteria.Datos;
using Cafeteria.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cafeteria.Controllers
{
    public class ProductosController : Controller
    {
        ProductosDatos _productoDatos = new ProductosDatos();
        public IActionResult Index() 
        {
            return View();
        }
        [HttpGet]
        public IActionResult ListarProducto(ProductosModel model) //Esta es la pagina para registrar al alumno (No hay para empleado, se sube directamente desde la base de datos)
        {
            var respuesta = _productoDatos.ListarProducto();
            return View(respuesta);
        }
        [HttpGet]
        public IActionResult RegistrarProducto() //Esto es para el inicio de sesión (Esta obviamente es la pagina principal)
        {
            //Esta es para mostrar el formulario
            return View();
        }
        [HttpPost]
        public IActionResult RegistrarProducto(ProductosModel model) //Esto es para el inicio de sesión (Esta obviamente es la pagina principal)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            bool respuesta = _productoDatos.RegistrarProducto(model);
            if (respuesta)
            {
                return RedirectToAction("ListarProducto");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public IActionResult EditarProducto(int id)
        {
            //Para obtener y mostrar el contacto a modificar
            ProductosModel _Producto= _productoDatos.BuscarProducto(id);

            return View(_Producto);
        }
        [HttpPost]
        public IActionResult EditarProducto(ProductosModel model)
        {
            //para obtener los datos que se editaron del formulario y enviarlo en la base de datos
            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = _productoDatos.EditarProducto(model);
            if (respuesta)
            {
                return RedirectToAction("ListarProducto");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public IActionResult EliminarProducto(int id)
        {
            //Para obtener y mostrar el contacto a eliminar
            ProductosModel _Producto = _productoDatos.BuscarProducto(id);

            return View(_Producto);
        }
        [HttpPost]
        public IActionResult EliminarProducto(ProductosModel model)
        {
            //para obtener los datos que se van a eliminar del formulario y enviarlo en la base de datos
            var respuesta = _productoDatos.EliminarProducto(model.Id);
            if (respuesta)
            {
                return RedirectToAction("ListarProducto");
            }
            else
            {
                return View();
            }
        }
    }
}

