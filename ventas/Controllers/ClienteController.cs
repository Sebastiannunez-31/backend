
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using ventas.Models;
using ventas.Models.Request;
using ventas.Models.Response;

namespace ventas.Controllers
{
	[Route("api/[controller]")]
	
	[ApiController]
	[Authorize]
	public class ClienteController : ControllerBase
	{
		 
		//obtener (select * from clientes)
	
		


		[HttpGet]
		public IActionResult Get()
		{
			Respuesta oRespuesta = new Respuesta();
			oRespuesta.Exito = 0;
			try
			{

				using (ventasContext db = new ventasContext())
				{

					var lst = db.Clientes.OrderByDescending(d=>d.Id).ToList();
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
		public IActionResult Add(ClienteRequest oModel)
		{
			Respuesta oRespuesta = new Respuesta();
			try
			{
				using (ventasContext db = new ventasContext())
				{

					Cliente oCliente = new Cliente();
					oCliente.Nombre = oModel.Nombre;
					db.Clientes.Add(oCliente);
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
		public IActionResult Edit(ClienteRequest oModel)
		{
			Respuesta oRespuesta = new Respuesta();
			try
			{
				using (ventasContext db = new ventasContext())
				{

					Cliente oCliente = db.Clientes.Find(oModel.Id);
					oCliente.Nombre = oModel.Nombre;
					db.Entry(oCliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
		public IActionResult Delete(int Id )
		{
			Respuesta oRespuesta = new Respuesta();
			try
			{
				using (ventasContext db = new ventasContext())
				{

					Cliente oCliente = db.Clientes.Find(Id);
					db.Remove(oCliente);
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

