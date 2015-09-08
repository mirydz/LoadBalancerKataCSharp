using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLoadBalancer
{
    public class Server
    {
        private static readonly double MAXIMUM_LOAD = 100.0;
        private List<Vm> vms = new List<Vm>();
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
    }
}
