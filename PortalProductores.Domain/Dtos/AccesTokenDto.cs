namespace PortalProductores.Domain.Dtos
{
    public class AccesTokenDto(string _accesToken)
    {
        public string AccesToken { get; set; } = _accesToken;
    }
}
