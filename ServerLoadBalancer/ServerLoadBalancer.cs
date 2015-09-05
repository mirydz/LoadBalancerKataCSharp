using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLoadBalancer
{
    public class ServerLoadBalancer
    {
        public void Balance(Server[] servers, Vm[] vms)
        {
            if (vms.Length > 0)
            {
                servers[0].CurrentLoadPercentage = (double) vms[0].Size
                    / (double) servers[0].Capacity * 100.0;
            }
        }
    }
}
