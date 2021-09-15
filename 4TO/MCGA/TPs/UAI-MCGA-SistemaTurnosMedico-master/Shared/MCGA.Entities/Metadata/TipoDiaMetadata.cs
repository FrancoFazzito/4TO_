using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCGA.Entities
{
	[MetadataType(typeof(TipoDiaMetadata))]
	public partial class TipoDia
	{
		public class TipoDiaMetadata
		{
			[DisplayName("Nombre")]
			[Required(ErrorMessage = "Obligatorio")]
			[MaxLength(510, ErrorMessage = "La longitud del texto debe ser <= a 510 carácteres.")]
			public string descripcion { get; set; }

			[DisplayName("Referencia DayOfWeek")]
			[Required(ErrorMessage = "Obligatorio")]
			[Range(0,6,ErrorMessage ="Debe estar entre 0 y 6.")]
			public Nullable<int> referenciaDayOfWeek { get; set; }


			
		}
	}
}
