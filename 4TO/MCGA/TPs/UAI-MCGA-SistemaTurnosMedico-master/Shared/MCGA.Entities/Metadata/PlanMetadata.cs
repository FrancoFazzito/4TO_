using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCGA.Entities
{
	[MetadataType(typeof(PlanMetadata))]
	public partial class Plan
	{
		public class PlanMetadata
		{
			[DisplayName("Nombre")]
			[Required(ErrorMessage = "Obligatorio")]
			[MaxLength(510, ErrorMessage = "La longitud del texto debe ser <= a 510 carácteres.")]
			public string descripcion { get; set; }

            [DisplayName("Bono de consulta")]
			[Required(ErrorMessage = "Obligatorio")]
            public decimal precio_bono_consulta { get; set; }

            [DisplayName("Bono de farmacia")]
			[Required(ErrorMessage = "Obligatorio")]
            public decimal precio_bono_farmacia { get; set; }
		}
	}
}
