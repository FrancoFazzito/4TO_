using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MCGA.WebSite.Models
{
	public class CalendarioGeneralViewModel
	{
		public int IdTurno { get; set; }
		public string Titulo { get; set; }
		public string Descripcion { get; set; }
		public string FechaInicio { get; set; }
		public string FechaFin { get; set; }
		public string BackgroundColor { get; set; }
		public string BorderColor { get; set; }
		public string FontColor { get; set; }
		public bool Atendido { get; set; }
		public int EspecialidadProfesionalId { get; set; }
		public bool Cancelado { get; set; }
	}

	public class CalendarioGeneralColorViewModel
	{
		public string Descripcion { get; set; }
		public string Color { get; set; }
	}
}