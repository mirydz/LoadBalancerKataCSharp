using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLoadBalancer
{
    public class Server
    {
        public int Capacity { get; private set; }
        public double CurrentLoadPercentage { get; set; }

        public Server(int capacity)
        {
            this.Capacity = capacity;
        }

        public bool Contains(Vm vm)
        {
            return true;
        }
    }
}
