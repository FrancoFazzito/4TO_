using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCGA.Entities
{
	[MetadataType(typeof(TipoDocumentoMetadata))]
	public partial class TipoDocumento
	{
		public class TipoDocumentoMetadata
		{
			[DisplayName("Nombre")]
			[Required(ErrorMessage = "Obligatorio")]
			[MaxLength(510, ErrorMessage = "La longitud del texto debe ser <= a 510 carácteres.")]
			public string descripcion { get; set; }
		}
	}

}
