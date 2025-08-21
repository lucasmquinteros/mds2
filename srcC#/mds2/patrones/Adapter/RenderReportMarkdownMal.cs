using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mds2.patrones.Adapter;
namespace mds2.patrones.Adapter
{
    public class RenderReportMarkdownMal
    {
        public static void RenderReporteMarkdownMal(List<Dictionary<string, object>> data)
        {
            // El cliente usa la lib legada y hace de traductor: 
            var csv = new LegacyCsvExporter().Export(data);
            var lines = csv.Split('\n');
            var headerLine = lines.FirstOrDefault() ?? "";
            var rows = lines.Skip(1).ToList();
            var headers = headerLine.Split(',');

            var table = new List<string>
        {
            $"| {string.Join(" | ", headers)} |",
            $"| {string.Join(" | ", headers.Select(_ => "--"))} |"
        };

            foreach (var line in rows)
            {
                var cols = line.Split(',');
                table.Add($"| {string.Join(" | ", cols)} |");
            }

            Console.WriteLine("=== Reporte csv legacy ===");
            Console.WriteLine(csv);

            Console.WriteLine("=== Reporte Markdown (MAL) ===");
            Console.WriteLine(string.Join("\n", table));
        }
    }    
}
