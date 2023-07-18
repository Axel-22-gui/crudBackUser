using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDUser.Entity
{
	public class Usuario
	{
		public Int64 Id {get;set;}
		public String nombre { get; set; }
		public String apellido {get;set;}
		public Int32 edad { get; set; }
		public String correoElectronico { get; set; }
	}
}
