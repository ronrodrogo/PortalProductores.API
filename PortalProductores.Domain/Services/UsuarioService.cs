using PortalProductores.Domain.Dtos;
using PortalProductores.Domain.Entities;
using PortalProductores.Domain.Enums;
using PortalProductores.Domain.Exceptions;
using PortalProductores.Domain.Helpers;
using PortalProductores.Domain.Ports;

namespace PortalProductores.Domain.Services
{
    [DomainService]
    public class UsuarioService(
        IGenericRepository<Usuario> _usuarioRepository,
        IQueryDapper _queryDapper
    )
    {
        public async Task<Usuario> GetUsuarioByIdAsync(int id)
        {
            id.ValidateInvalidId();

            Usuario usuario = await _usuarioRepository.GetByFilterAsync(
                filter => filter.Id.Equals(id) && filter.Estado.Equals(1)
            ) ?? throw new ValidatorException(MessagesExceptions.UserNotExists);

            return usuario;
        }

        public async Task<Usuario> GetUsuarioByCorreoAsync(string correo)
        {
            correo.ValidateNullOrEmptyString(MessagesExceptions.EmailEmpty);

            Usuario usuario = await _usuarioRepository.GetByFilterAsync(
                filter => filter.Correo.Equals(correo) && filter.Estado.Equals(1)
            ) ?? throw new ValidatorException(MessagesExceptions.UserNotExists);

            return usuario;
        }

        public async Task<Usuario> GetUsuarioByCorreoYContrasenaAsync(
            string correo,
            string contrasena
        )
        {
            correo.ValidateNullOrEmptyString(MessagesExceptions.EmailEmpty);
            contrasena.ValidateNullOrEmptyString(MessagesExceptions.PasswordEmpty);

            Usuario usuario = await _usuarioRepository.GetByFilterAsync(
                filter => filter.Correo.Equals(correo) && filter.Contrasena.Equals(contrasena) && filter.Estado.Equals(1)
            ) ?? throw new ValidatorException(MessagesExceptions.IncorrectEmailOrPassword);

            return usuario;
        }

        public async Task<Usuario> GuardarUsuarioAsync(
            Usuario usuario
        )
        {
            ValidateFieldUsuario(usuario);

            await ValidateExistsProductoresAsync(usuario);

            usuario.Estado = (int)EstadoTypes.Activo;

            return await _usuarioRepository.CreateAsync(usuario);
        }

        public async Task<Usuario> ActualizarUsuarioAsync(Usuario usuario)
        {
            usuario.Id.ValidateInvalidId();
            ValidateFieldUsuario(usuario);
            await ValidateExistsProductoresAsync(usuario);

            Usuario usuarioUpdate = await GetUsuarioByIdAsync(usuario.Id);

            await _queryDapper.ExecuteAsync(
                ItemQueryConstants.DeleteUsuarioProductorByUsuarioId.GetDescription(),
                new { UsuarioId = usuario.Id }
            );

            usuarioUpdate.Nombre = usuario.Nombre;
            usuarioUpdate.Correo = usuario.Correo;
            usuarioUpdate.Telefono = usuario.Telefono;
            usuarioUpdate.Rut = usuario.Rut;
            usuarioUpdate.Perfil = usuario.Perfil;
            usuarioUpdate.Contrasena = usuario.Contrasena;
            usuarioUpdate.FechaActualizacion = DateTime.Now;

            usuarioUpdate.UsuarioProductores = usuario.UsuarioProductores;

            return await _usuarioRepository.UpdateAsync(usuarioUpdate);
        }

        public async Task ActualizarContrasenaUsuarioAsync(
            int usuarioId,
            string contrasena
        )
        {
            usuarioId.ValidateInvalidId();
            contrasena.ValidateNullOrEmptyString(MessagesExceptions.PasswordEmpty);

            Usuario usuario = await GetUsuarioByIdAsync(usuarioId);

            usuario.Contrasena = contrasena;
            usuario.FechaActualizacion = DateTime.Now;

            await _usuarioRepository.UpdateAsync(usuario);
        }

        public async Task DeleteUsuarioByIdAsync(int usuarioId)
        {
            usuarioId.ValidateInvalidId();

            await _queryDapper.ExecuteAsync(
                ItemQueryConstants.DeleteUsuarioById.GetDescription(),
                new { usuarioId }
            );
        }

        private static void ValidateFieldUsuario(Usuario usuario)
        {
            usuario.Nombre.ValidateNullOrEmptyString(MessagesExceptions.NameEmpty);
            usuario.Correo.ValidateNullOrEmptyString(MessagesExceptions.EmailEmpty);
            usuario.Rut.ValidateNullOrEmptyString(MessagesExceptions.RutEmpty);
            usuario.Perfil.ValidateByteEmpty(MessagesExceptions.ProfileEmpty);
            usuario.Contrasena.ValidateNullOrEmptyString(MessagesExceptions.PasswordEmpty);

            if (!Enum.IsDefined(typeof(PerfilTypes), (int)usuario.Perfil))
            {
                throw new ValidatorException(MessagesExceptions.PerfilTypeNotExists);
            }
        }

        private async Task ValidateExistsProductoresAsync(Usuario usuario)
        {
            if (usuario.UsuarioProductores is not null && usuario.UsuarioProductores.Any())
            {
                IEnumerable<int> productoresIds = usuario.UsuarioProductores.Select(item => item.ProductorId);
                string productoresIdsString = string.Join(",", productoresIds);
                object[] args = [productoresIdsString];

                IEnumerable<ValidateExistsProductoresDto> productoresIdsInBd = await _queryDapper.QueryAsync<ValidateExistsProductoresDto>(
                    ItemQueryConstants.ValidateExistsProductores.GetDescription(),
                    new(),
                    args
                );

                var productoresNoExistentes = productoresIds
                    .Except(productoresIdsInBd.Select(item => item.ProductorId))
                    .ToList();

                if (productoresNoExistentes.Count != 0)
                {
                    throw new ValidatorException(
                        string.Format(MessagesExceptions.ProducersNotExists, string.Join(", ", productoresNoExistentes))
                    );
                }
            }
        }
    }
}
