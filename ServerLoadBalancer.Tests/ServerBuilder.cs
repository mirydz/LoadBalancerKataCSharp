using static ServerLoadBalancer.Server;

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

        private void AddInitaialLoad(Server server)
        {
            if (this.initialLoad > 0)
            {
                int expectedLoad = (int)(initialLoad / MAXIMUM_LOAD 
                                         * (double)server.Capacity);
                server.AddVm(VmBuilder.Vm().OfSize(expectedLoad).Build());
            }
        }

        public Server Build()
        {
            var server =  new Server(capacity);
            AddInitaialLoad(server);
            return server;
        }

        public static ServerBuilder Server()
        {
            return new ServerBuilder();
        }
    }
}