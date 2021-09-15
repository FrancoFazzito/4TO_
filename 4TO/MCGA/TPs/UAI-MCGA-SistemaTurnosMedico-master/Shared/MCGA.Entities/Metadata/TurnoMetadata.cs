using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCGA.Entities
{
	[MetadataType(typeof(TurnoMetadata))]
	public partial class Turno
	{
		public class TurnoMetadata
		{
			[DisplayName("Fecha")]
			[Required(ErrorMessage = "Obligatorio")]
			[DataType(DataType.Date)]
			[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
			public System.DateTime Fecha { get; set; }

			[DisplayName("Hora")]
			[Required(ErrorMessage = "Obligatorio")]
			[DataType(DataType.Time)]
			[DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = false)]
			public System.TimeSpan Hora { get; set; }

			[DisplayName("Afiliado")]
			[Required(ErrorMessage = "Obligatorio")]
			public int AfiliadoId { get; set; }

			[DisplayName("Especialidad")]
			[Required(ErrorMessage = "Obligatorio")]
			public int EspecialidadProfesionalId { get; set; }

			[DisplayName("Reserva")]
			[Required(ErrorMessage = "Obligatorio")]
			public int reserva { get; set; }

			[DisplayName("Observaciones")]
			[Required(ErrorMessage = "Obligatorio")]
			[MaxLength (8000,ErrorMessage = "La longitud del texto debe ser <= a 8000 carácteres.")]
			public string Observaciones { get; set; }
		}
	}
}