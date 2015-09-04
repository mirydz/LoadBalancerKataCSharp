namespace ServerLoadBalancer.Tests
{
    internal class ServerBuilder : IBuilder<Server>
    {
        private int capacity;

        public ServerBuilder WithCapacity(int capacity)
        {
            this.capacity = capacity;
            return this;
        }

        public Server Build()
        {
            return new Server(capacity);
        }

        public static ServerBuilder Server()
        {
            return new ServerBuilder();
        }
    }
}