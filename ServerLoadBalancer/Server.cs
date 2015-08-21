using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLoadBalancer
{
    public class Server
    {
        private int capacity;
        public double CurrentLoadPercentage { get; set; }

        public Server(int capacity)
        {
            this.capacity = capacity;
        }
    }
}
