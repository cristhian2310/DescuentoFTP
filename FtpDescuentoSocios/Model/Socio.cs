//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FtpDescuentoSocios.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Socio
    {
        public Socio()
        {
            this.DescuentoSocios = new HashSet<DescuentoSocio>();
        }
    
        public int IdSocio { get; set; }
        public Nullable<short> IdEstado { get; set; }
        public string Descripcion { get; set; }
        public string Usuario { get; set; }
        public string Contrasenia { get; set; }
        public Nullable<int> IdUsrCreacion { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public Nullable<int> IdUsrUltimaModificacion { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }
        public string UsuarioFtp { get; set; }
        public string PasswordFtp { get; set; }
    
        public virtual ICollection<DescuentoSocio> DescuentoSocios { get; set; }
    }
}