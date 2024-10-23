using PortalProductores.Domain.Entities;

namespace PortalProductores.Domain.Dtos
{
    public class UsuarioConProductoresDto(
        Usuario _usuario,
        IEnumerable<UsuarioProductorDto> _productores
    ) : UsuarioDto(_usuario)
    {
        public IEnumerable<UsuarioProductorDto> Productores { get; set; } = _productores;
    }
}
