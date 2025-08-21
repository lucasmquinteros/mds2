using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mds2.patrones.Adapter
{
    public interface IReportAdapter
    {
        public string render(List<Dictionary<string, object>> data);
    }
}
