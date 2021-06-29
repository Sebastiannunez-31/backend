using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ventas.Models.Request;
using ventas.Models.Response;

namespace ventas.Services
{
	public interface IUserService
	{
		UserResponse  Auth(AuthRequest model);
	}
}
