using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLoadBalancer
{
    public class Vm
    {
        public int Size { get; private set; }

        public Vm(int size)
        {
            this.Size = size;
        }
    }
}
