using System;

namespace ServerLoadBalancer.Tests
{
    internal class VmBuilder
    {
        private int size;

        public VmBuilder OfSize(int size)
        {
            this.size = size;
            return this;
        }

        public Vm Build()
        {
            return new Vm(this.size);
        }
    }
}