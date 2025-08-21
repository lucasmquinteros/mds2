using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mds2.patrones.Adapter
{
    public class ClientCode
    {
        public void ImprimirReporte(IReportAdapter adapter, List<Dictionary<string, object>> data)
        {
            var reporte = adapter.render(data);
            Console.WriteLine("=== Reporte generado por el adaptador ===");
            Console.WriteLine(reporte);
        }

    }
}
