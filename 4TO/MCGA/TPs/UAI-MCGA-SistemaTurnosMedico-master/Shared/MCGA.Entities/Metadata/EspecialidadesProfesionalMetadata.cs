using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCGA.Entities
{
	[MetadataType(typeof(EspecialidadesProfesionalMetadata))]
	public partial class EspecialidadesProfesional
	{
		public class EspecialidadesProfesionalMetadata
		{
			[DisplayName("Especialidad")]
			[Required(ErrorMessage = "Obligatorio")]
			public int EspecialidadId { get; set; }


			[DisplayName("Profesional")]
			[Required(ErrorMessage = "Obligatorio")]
			public int ProfesionalId { get; set; }
		}
	}
}