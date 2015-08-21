using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using static ServerLoadBalancer.Tests.ServerBuilder;

namespace ServerLoadBalancer.Tests
{
    [TestFixture]
    public class ServerLoadBalancerTest
    {
        [Test]
        public void ItCompiles()
        {
            Assert.That(true, Is.True);
        }

        [Test]
        public void BalancingServer_NoVms_ServerStaysEmpty()
        {
            Server theServer = A(Server().WithCapacity(1));

            Balance(ListOfServersWith(theServer), EmptyListOfVms());

            Assert.That(theServer, HasLoadPercentageOf(0.0));
        }

        private Constraint HasLoadPercentageOf(double expectedLoadPerentage)
        {
            return new CurrentLoadPercentageConstraint(expectedLoadPerentage);
        }

        private void Balance(Server[] servers, Vm[] vms)
        {
            var loadBalancer = new ServerLoadBalancer();
            loadBalancer.Balance(servers, vms);
        }

        private Server[] ListOfServersWith(Server theServer)
        {
            return new Server[] { theServer };
        }

        private Vm[] EmptyListOfVms()
        {
            return new Vm[0];
        }

        private Server A(ServerBuilder builder)
        {
            return builder.Build();
        } 
    }
}
