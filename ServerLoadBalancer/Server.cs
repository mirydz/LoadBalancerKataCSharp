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
        private int capacity;
        private List<Vm> vms = new List<Vm>();
        public double CurrentLoadPercentage { get; set; }
        public int VmsCount
        {
            get { return this.vms.Count; }
        }

        public Server(int capacity)
        {
            this.capacity = capacity;
        }

        public bool Contains(Vm vm)
        {
            return true;
        }

        public void AddVm(Vm vm)
        {
            this.vms.Add(vm);
            this.CurrentLoadPercentage = (double)vm.Size
                / (double) this.capacity * MAXIMUM_LOAD;
        }
    }
}
