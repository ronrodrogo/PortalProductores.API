using System.ComponentModel;

namespace PortalProductores.Domain.Enums
{
    public enum EstadoTypes
    {
        [Description("Inactivo")]
        Inactivo = 0,
        [Description("Activo")]
        Activo = 1,
        [Description("Aprobado")]
        Aprobado = 2,
        [Description("Rechazado")]
        Rechazado = 3,
        [Description("Objetado")]
        Objetado = 4
    }
}
