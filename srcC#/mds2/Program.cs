using mds2.patrones.Adapter;
namespace Mds2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Dictionary<string, object>> data = new()
            {
                new Dictionary<string, object>
                {
                    { "Nombre", "Juan" },
                    { "Edad", 30 },
                    { "Ciudad", "Madrid" }
                },
                new Dictionary<string, object>
                {
                    { "Nombre", "Ana" },
                    { "Edad", 25 },
                    { "Ciudad", "Barcelona" }
                },
                new Dictionary<string, object>
                {
                    { "Nombre", "Luis" },
                    { "Edad", 28 },
                    { "Ciudad", "Valencia" }
                }
            };
            var legacyCsvExporter = new LegacyCsvExporter();
            var markdownAdapter = new MarkdownAdapter(legacyCsvExporter);
            var client = new ClientCode();
            client.ImprimirReporte(markdownAdapter, data);
            Console.WriteLine("\n");
            Console.WriteLine(legacyCsvExporter.Export(data));
            Console.WriteLine("\n");
            Console.WriteLine();
            RenderReportMarkdownMal.RenderReporteMarkdownMal(data);
        }
    }
}