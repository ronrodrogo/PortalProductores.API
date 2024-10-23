using ClosedXML.Excel;
using PortalProductores.Domain.Ports;
using System.ComponentModel;

namespace PortalProductores.Infrastructure.Adapters
{
    public class ExportExcel : IExportExcel
    {
        private readonly ComponentResourceManager _componentResourceManager = new(typeof(Constants.FieldNameConstants));

        public async Task<byte[]> ExportToExcel<T>(List<T> data, List<string> headers)
        {
            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Sheet1");

            for (int i = 0; i < headers.Count; i++)
            {
                worksheet.Cell(1, i + 1).Value = GetNombreCampo(headers[i]);
            }

            var properties = typeof(T).GetProperties()
                .Where(prop => headers.Contains(prop.Name, StringComparer.OrdinalIgnoreCase))
                .ToList();

            for (int i = 0; i < data.Count; i++)
            {
                for (int j = 0; j < properties.Count; j++)
                {
                    worksheet.Cell(i + 2, j + 1).Value = properties[j].GetValue(data[i])!.ToString();
                }
            }

            worksheet.Columns().AdjustToContents();

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);

            return await Task.FromResult(stream.ToArray());
        }

        public string GetNombreCampo(string key)
        {
            string? value = _componentResourceManager.GetString(key);

            return value ?? key;
        }
    }
}
