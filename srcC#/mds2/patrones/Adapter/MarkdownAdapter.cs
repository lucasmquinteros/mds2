using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mds2.patrones.Adapter
{
    public class MarkdownAdapter : IReportAdapter
    {
        private readonly LegacyCsvExporter _legacyCsvExporter;

        public MarkdownAdapter(LegacyCsvExporter legacyCsvExporter)
        {
            _legacyCsvExporter = legacyCsvExporter;
        }

        public string render(List<Dictionary<string, object>> data)
        {
            var csv = _legacyCsvExporter.Export(data);
            var lines = csv.Split('\n').Where(line => !string.IsNullOrWhiteSpace(line)).ToList();

            if (lines.Count == 0)
                return string.Empty;

            var headerLine = lines[0];
            var rows = lines.Skip(1).ToList();

            var headers = headerLine.Split(',');

            var body = string.Join("\n", rows.Select(r => $"| {string.Join(" | ", r.Split(','))} |"));

            var table =
                $"| {string.Join(" | ", headers)} |\n" +
                $"| {string.Join(" | ", headers.Select(_ => "---"))} |\n" +
                body;

            return table;
        }
    }
}
