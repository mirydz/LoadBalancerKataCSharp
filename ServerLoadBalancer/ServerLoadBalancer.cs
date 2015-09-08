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
                AddToCapableLessLoadedServer(servers, vm);
            }
        }

        private void AddToCapableLessLoadedServer(Server[] servers, Vm vm)
        {
            var serversWithEnoughCapacity = FindServersWithEnoughCapacity(servers, vm);
            var lessLoaded = ExtractLessLoadedServer(serversWithEnoughCapacity);
            lessLoaded?.AddVm(vm);
        }

        private static List<Server> FindServersWithEnoughCapacity(Server[] servers, Vm vm)
        {
            return servers.Where(server => server.CanFit(vm)).ToList();
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
                                                                                                