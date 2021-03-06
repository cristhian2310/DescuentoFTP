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
    
    public partial class Cliente
    {
        public Cliente()
        {
            this.DescuentoSocios = new HashSet<DescuentoSocio>();
            this.SRV_Clientes1 = new HashSet<Cliente>();
        }
    
        public int IDCliente { get; set; }
        public Nullable<int> IDClientePadre { get; set; }
        public int IDtipoClientes { get; set; }
        public int IDlimite { get; set; }
        public Nullable<int> IDsucursal { get; set; }
        public Nullable<int> IDPlanfidelidad { get; set; }
        public string Nombre1 { get; set; }
        public string Nombre2 { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Email { get; set; }
        public byte Sexo { get; set; }
        public System.DateTime FechaNac { get; set; }
        public System.DateTime FechaUltimoCambio { get; set; }
        public byte Estatus { get; set; }
        public string CodigoDeBusqueda { get; set; }
        public string Cedula { get; set; }
        public Nullable<int> NoDependientes { get; set; }
        public Nullable<byte> ManejoLimite { get; set; }
        public string Parentesco { get; set; }
        public Nullable<bool> EsCuentaCorporativa { get; set; }
        public Nullable<int> IDLugarTrabajo { get; set; }
        public Nullable<bool> Zonafranca { get; set; }
        public Nullable<bool> Ordencompra { get; set; }
        public Nullable<int> IDsucursalAsiste { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public Nullable<int> IDusuario { get; set; }
        public Nullable<bool> AceptarCheque { get; set; }
        public Nullable<int> IDempresaafiliada { get; set; }
        public Nullable<int> IDEstructuradescuento { get; set; }
        public Nullable<int> IDpoliticacredito { get; set; }
        public Nullable<int> PersonalidadJuridica { get; set; }
        public System.Guid rowguid { get; set; }
        public Nullable<bool> Gubernamental { get; set; }
        public string RNC { get; set; }
        public Nullable<decimal> LimiteCredito { get; set; }
        public Nullable<decimal> MontoDisponible { get; set; }
        public string Legajo { get; set; }
        public Nullable<int> Estado_Credito { get; set; }
        public Nullable<int> IdUsrCreacion { get; set; }
        public Nullable<int> IdUsrUltimaModificacion { get; set; }
        public Nullable<int> Id_TipoIdentificacion { get; set; }
        public System.Guid msrepl_tran_version { get; set; }
        public string TelCasa { get; set; }
        public string TelOficina { get; set; }
        public Nullable<int> IdTarjeta { get; set; }
        public string NroTarjeta { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }
        public Nullable<int> PerfilServicio { get; set; }
        public string AuxiliarContable { get; set; }
        public Nullable<int> IdAcreedorSalud { get; set; }
        public string NroAsegurado { get; set; }
        public string CedulaMenor { get; set; }
        public string Pasaporte { get; set; }
        public Nullable<decimal> puntosDisponibles { get; set; }
        public Nullable<int> lugartrabajo { get; set; }
        public Nullable<int> lugartrabajosucu { get; set; }
        public string NoAfiliadoPBS { get; set; }
    
        public virtual ICollection<DescuentoSocio> DescuentoSocios { get; set; }
        public virtual ICollection<Cliente> SRV_Clientes1 { get; set; }
        public virtual Cliente SRV_Clientes2 { get; set; }
    }
}
