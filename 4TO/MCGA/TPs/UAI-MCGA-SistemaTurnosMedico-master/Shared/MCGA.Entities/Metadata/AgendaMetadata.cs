using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCGA.Entities
{
	[MetadataType(typeof(AgendaMetadata))]
	public partial class Agenda
	{
		public class AgendaMetadata
		{
			[DisplayName("Especialidad")]
			[Required(ErrorMessage = "Obligatorio")]
			public int EspecialidadProfesionalId { get; set; }

			[DisplayName("Día")]
			[Required(ErrorMessage = "Obligatorio")]
			public int TipoDiaId { get; set; }

			[DisplayName("F. desde")]
			[Required(ErrorMessage = "Obligatorio")]
			[DataType(DataType.Date)]
			[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
			public System.DateTime fecha_desde { get; set; }

			[DisplayName("F. hasta")]
			[Required(ErrorMessage = "Obligatorio")]
			[DataType(DataType.Date)]
			[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
			public System.DateTime fecha_hasta { get; set; }

			[DisplayName("H. desde")]
			[Required(ErrorMessage = "Obligatorio")]
			[DataType(DataType.Time)]
			[DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = false)]
			public System.TimeSpan hora_desde { get; set; }

			[DisplayName("H. hasta")]
			[Required(ErrorMessage = "Obligatorio")]
			[DataType(DataType.Time)]
			[DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = false)]
			public System.TimeSpan hora_hasta { get; set; }
			
			
		}
	}
}