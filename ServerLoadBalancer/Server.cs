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

        private double LoadOfVm(Vm vm)
        {
            return ((double) vm.Size / (double) this.Capacity * MAXIMUM_LOAD);
        }

        public void AddVm(Vm vm)
        {
            this.vms.Add(vm);
            this.CurrentLoadPercentage = LoadOfVm(vm);
        }

        public bool CanFit(Vm vm)
        {
            return this.CurrentLoadPercentage + LoadOfVm(vm) <= MAXIMUM_LOAD;
        }
    }
}
