using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ArtMarket.Entities.Model
{
    [Serializable]
    [DataContract]
    public class IdentityBase
    {
        [Key]
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [Required(ErrorMessage = "Requerido")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime CreatedOn { get; set; }

        [DataMember]
        [MaxLength(256, ErrorMessage = "Created By Longitud  256 caracteres")]
        public string CreatedBy { get; set; }

        [DataMember]
        [Required(ErrorMessage = "Requerido")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime ChangedOn { get; set; }

        [DataMember]
        [MaxLength(256, ErrorMessage = "Changed By Longitud  256 caracteres")]
        public string ChangedBy { get; set; }

        /// <summary>
        /// Muestra los valores de las propiedades con fines de depuración.
        /// </summary>
        public override string ToString()
        {
            return this.GetType().Name + ": " +
                   string.Join(",", this.GetType().GetProperties()
                       .Where(p => !p.PropertyType.IsGenericType && !p.PropertyType.IsArray)
                       .Select(p => string.Format("{0}={1}", p.Name, p.GetValue(this, null))));
        }
    }
}
