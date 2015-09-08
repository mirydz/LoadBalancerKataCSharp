namespace ServerLoadBalancer.Tests
{
    internal class ServerBuilder : IBuilder<Server>
    {
        private int capacity;
        private double initialLoad;

        public ServerBuilder WithCapacity(int capacity)
        {
            this.capacity = capacity;
            return this;
        }

        public ServerBuilder WithCurrentLoadOf(double initialLoad)
        {
            this.initialLoad = initialLoad;
            return this;
        }

        public Server Build()
        {
            var server =  new Server(capacity);
            if (initialLoad > 0)
            {
                int expectedLoad =  (int) (initialLoad / 100.0 * (double) server.Capacity);
                server.AddVm(VmBuilder.Vm().OfSize(expectedLoad).Build());
            }
            return server;
        }

        public static ServerBuilder Server()
        {
            return new ServerBuilder();
        }
    }
}