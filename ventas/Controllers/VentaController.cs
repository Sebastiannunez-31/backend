using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ventas.Models.Request;
using ventas.Models.Response;
using ventas.Models;
using ventas.Services;

namespace ventas.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize] 
	public class VentaController : ControllerBase
	{
		private IVentaService _venta;

		public VentaController(IVentaService venta) 
		{
			this._venta = venta;
		}
		[HttpPost]
		public IActionResult Add(VentaRequest model) 
		{
			Respuesta respuesta = new Respuesta();

			try
			{
			
				_venta.Add(model);
				respuesta.Exito = 1;

			}
			catch (Exception ex)
			{
				respuesta.Mensaje = ex.Message;
			
			}

			return Ok(respuesta);
		}
			
	}
}
