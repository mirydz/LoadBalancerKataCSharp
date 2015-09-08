using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLoadBalancer
{
    public class Server
    {
        private List<Vm> vms = new List<Vm>();
        public static readonly double MAXIMUM_LOAD = 100.0;
        public int Capacity { get; private set; }
        public double CurrentLoadPercentage { get; set; }
        public int VmsCount
        {
            get { return this.vms.Count; }
        }

        public Server(int capacity)
        {
            this.Capacity = capacity;
        }

        public bool Contains(Vm vm)
        {
            return this.vms.Contains(vm);
        }

        public void AddVm(Vm vm)
        {
            this.vms.Add(vm);
            this.CurrentLoadPercentage = (double)vm.Size
                / (double) this.Capacity * MAXIMUM_LOAD;
        }

        public bool CanFit(Vm vm)
        {
            return this.CurrentLoadPercentage
                   + ((double) vm.Size / (double) this.Capacity * MAXIMUM_LOAD) <= MAXIMUM_LOAD;
        }
    }
}
