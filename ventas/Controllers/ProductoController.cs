using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ventas.Models.Response;
using ventas.Models;
using ventas.Models.Request;

namespace ventas.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductoController : ControllerBase
	{
		//obtener (selec * from productos)


		[HttpGet]
		public IActionResult Get()
		{
			Respuesta oRespuesta = new Respuesta();
			oRespuesta.Exito = 0;

			try
			{
				using (ventasContext db = new ventasContext())
				{

					var lst = db.Productos.OrderByDescending(d => d.Id).ToList();
					oRespuesta.Exito = 1;
					oRespuesta.Data = lst;
				}
			}
			catch (Exception ex)
			{
				oRespuesta.Mensaje = ex.Message;
			}
			return Ok(oRespuesta);
		}

		//insertar

		[HttpPost]

		public IActionResult Add(ProductoRequest oModel)
		{

			Respuesta oRespuesta = new Respuesta();
			try
			{
				using (ventasContext db = new ventasContext())
				{
					Producto oProducto = new Producto();
					oProducto.Nombre = oModel.Nombre;
					oProducto.PrecioUnitario = oModel.PrecioUnitario;
					oProducto.Costo = oModel.Costo;
					db.Productos.Add(oProducto);
					db.SaveChanges();
					oRespuesta.Exito = 1;

				}

			}
			catch (Exception ex)
			{
				oRespuesta.Mensaje = ex.Message;

			}
			return Ok(oRespuesta);


		}

		//actualizar
		[HttpPut]
		public IActionResult Edit(ProductoRequest oModel)
		{

			Respuesta oRespuesta = new Respuesta();
			try
			{
				using (ventasContext db = new ventasContext())
				{
					Producto oProducto = db.Productos.Find(oModel.Id);
					oProducto.Nombre = oModel.Nombre;
					oProducto.PrecioUnitario = oModel.PrecioUnitario;
					oProducto.Costo = oModel.Costo;
					db.Entry(oProducto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
					db.SaveChanges();
					oRespuesta.Exito = 1;

				}

			}
			catch (Exception ex)
			{
				oRespuesta.Mensaje = ex.Message;

			}
			return Ok(oRespuesta);

		}

		//eliminar
		[HttpDelete("{Id}")]

		public IActionResult Delete(int Id)
		{

			Respuesta oRespuesta = new Respuesta();
			try
			{
				using (ventasContext db = new ventasContext())
				{
					Producto oProducto = db.Productos.Find(Id);
					db.Remove(oProducto);
					db.SaveChanges();
					oRespuesta.Exito = 1;

				
				}
			}
			catch (Exception ex)
			{

				oRespuesta.Mensaje = ex.Message;
			}
			return Ok(oRespuesta);
		}
	}
}
