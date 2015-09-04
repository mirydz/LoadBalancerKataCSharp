using System;

namespace ServerLoadBalancer.Tests
{
    internal class VmBuilder : IBuilder<Vm>
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

        public static VmBuilder Vm()
        {
            return new VmBuilder();
        }
    }
}