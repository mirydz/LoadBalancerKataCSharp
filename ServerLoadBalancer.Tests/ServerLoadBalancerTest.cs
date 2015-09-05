using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using static ServerLoadBalancer.Tests.ServerBuilder;
using static ServerLoadBalancer.Tests.VmBuilder;

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

        [Test]
        public void BalancingServerWithOneSlotCapacity_AndOneSlotVm_FillsServerWithVm()
        {
            Server theServer = A(Server().WithCapacity(1));
            Vm theVm = A(Vm().OfSize(1));

            Balance(ListOfServersWith(theServer), ListOfVmsWith(theVm));

            Assert.That(theServer, HasLoadPercentageOf(100.0));
            Assert.That(theServer.Contains(theVm), "The server should contain the vm");
        }

        [Test]
        public void BalancingOneServerWithTenSlotsCapacity_AndOneSlotVm_FillsServerWIthTenPercent()
        {
            Server theServer = A(Server().WithCapacity(10));
            Vm theVm = A(Vm().OfSize(1));

            Balance(ListOfServersWith(theServer), ListOfVmsWith(theVm));

            Assert.That(theServer, HasLoadPercentageOf(10.0));
            Assert.That(theServer.Contains(theVm), "The server should contain the vm");
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

        private Server[] ListOfServersWith(Server server)
        {
            return new Server[] { server };
        }

        private Vm[] ListOfVmsWith(Vm vm)
        {
            return new Vm[] { vm };
        }

        private Vm[] EmptyListOfVms()
        {
            return new Vm[0];
        }

        private T A<T>(IBuilder<T> builder)
        {
            return builder.Build();
        }



    }
}
