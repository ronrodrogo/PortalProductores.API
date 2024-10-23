namespace PortalProductores.Domain.Ports
{
    public interface IExportExcel
    {
        Task<byte[]> ExportToExcel<T>(List<T> data, List<string> headers);
    }
}
