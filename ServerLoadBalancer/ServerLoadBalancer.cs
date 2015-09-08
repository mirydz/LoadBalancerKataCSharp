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
            foreach (var vm in vms)
            {
                var serversWithEnoughCapacity = new List<Server>();
                foreach (var server in servers)
                {
                    if (server.CanFit(vm))
                        serversWithEnoughCapacity.Add(server);
                }
                Server lessLoaded = ExtractLessLoadedServer(serversWithEnoughCapacity);
                lessLoaded?.AddVm(vm);
            }
        }

        private Server ExtractLessLoadedServer(List<Server> servers)
        {
            Server lessLoaded = null;
            foreach (var server in servers)
            {
                if (lessLoaded == null ||
                    lessLoaded.CurrentLoadPercentage > server.CurrentLoadPercentage)
                {
                    lessLoaded = server;
                }
            }
            return lessLoaded;
        }
    }
}
