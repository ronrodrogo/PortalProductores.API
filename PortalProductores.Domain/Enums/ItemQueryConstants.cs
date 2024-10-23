using System.ComponentModel;

namespace PortalProductores.Domain.Enums
{
    public enum ItemQueryConstants
    {
        [Description("GetListUsuarioProductorByUsuarioId")]
        GetListUsuarioProductorByUsuarioId,
        [Description("DeleteUsuarioById")]
        DeleteUsuarioById,
        [Description("ValidateExistsProductores")]
        ValidateExistsProductores,
        [Description("DeleteUsuarioProductorByUsuarioId")]
        DeleteUsuarioProductorByUsuarioId,
        [Description("GetListUsuarios")]
        GetListUsuarios,
        [Description("GetCountUsuarios")]
        GetCountUsuarios,
        [Description("GetListProductores")]
        GetListProductores,
        [Description("GetCountProductores")]
        GetCountProductores,
        [Description("GetListRecepciones")]
        GetListRecepciones,
        [Description("GetCountRecepciones")]
        GetCountRecepciones,
        [Description("GetListProcesos")]
        GetListProcesos,
        [Description("GetCountProcesos")]
        GetCountProcesos
    }
}
