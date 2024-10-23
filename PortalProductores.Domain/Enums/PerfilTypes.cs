using System.ComponentModel;

namespace PortalProductores.Domain.Enums
{
    public enum PerfilTypes
    {
        [Description("Administrador")]
        Administrador = 1,
        [Description("Estándar")]
        Estandar = 2,
        [Description("Productor")]
        Productor = 3
    }
}
