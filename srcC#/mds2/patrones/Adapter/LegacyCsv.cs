using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mds2.patrones.Adapter
{
    public class LegacyCsvExporter
    {
        public string Export(List<Dictionary<string, object>> data)
        {
            if (data == null || data.Count == 0)
                return string.Empty;

            var headers = data[0].Keys.ToList();
            var sb = new StringBuilder();

            // Encabezados
            sb.AppendLine(string.Join(",", headers));

            // Filas de datos
            foreach (var row in data)
            {
                var line = string.Join(",", headers.Select(h => row.ContainsKey(h) && row[h] != null ? row[h].ToString() : ""));
                sb.AppendLine(line);
            }

            return sb.ToString().TrimEnd('\r', '\n');
        }
    }
}
