namespace PortalProductores.Domain.Dtos
{
    public class ObjectResultDto
    {
        public bool Satisfactorio { get; set; }
        public int Codigo { get; set; }
        public string Mensaje { get; set; } = string.Empty;
        public object Data { get; set; } = null!;
    }
}
