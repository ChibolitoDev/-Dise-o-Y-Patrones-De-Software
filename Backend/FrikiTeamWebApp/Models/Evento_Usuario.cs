//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FrikiTeamWebApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Evento_Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Evento_Usuario()
        {
            this.Evento_Usuario_Codigo = new HashSet<Evento_Usuario_Codigo>();
        }
    
        public int IDEvento_Usuario { get; set; }
        public int IDCliente { get; set; }
        public int IDEvento { get; set; }
    
        public virtual Cliente Cliente { get; set; }
        public virtual Evento Evento { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Evento_Usuario_Codigo> Evento_Usuario_Codigo { get; set; }
    }
}