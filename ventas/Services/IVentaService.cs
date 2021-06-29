using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ventas.Models.Request;

namespace ventas.Services
{
	public interface IVentaService
	{
		public void Add(VentaRequest model);
	}
}
