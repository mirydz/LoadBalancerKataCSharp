using System;
using NUnit.Framework.Constraints;

namespace ServerLoadBalancer.Tests
{
    internal class ServerVmsCountConstraint : Constraint
    {
        private int expectedCount;
        private int actualCount;

        public ServerVmsCountConstraint(int expectedCount)
        {
            this.expectedCount = expectedCount;
        }

        public override bool Matches(object actual)
        {
            if (actual is Server)
            {
                var server = (Server) actual;
                this.actualCount = server.VmsCount;
                return server.VmsCount == expectedCount;
            }

            throw new ArgumentException("Argument should be of type Server");
        }

        public override void WriteDescriptionTo(MessageWriter writer)
        {
            writer.WriteExpectedValue(this.expectedCount);
        }

        public override void WriteActualValueTo(MessageWriter writer)
        {
            writer.WriteActualValue(this.actualCount);
        }
    }
}