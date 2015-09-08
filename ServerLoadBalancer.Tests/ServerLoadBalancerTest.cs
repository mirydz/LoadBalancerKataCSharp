﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using static ServerLoadBalancer.Tests.ServerBuilder;
using static ServerLoadBalancer.Tests.VmBuilder;
using static ServerLoadBalancer.Tests.ServerVmsCountConstraint;
using static ServerLoadBalancer.Tests.CurrentLoadPercentageConstraint;

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

        [Test]
        public void BalancingServerWithEnoughRoom_GetsFilledWithAllVms()
        {
            Server theServer = A(Server().WithCapacity(100));
            Vm theFirstVm = A(Vm().OfSize(1));
            Vm theSecondVm = A(Vm().OfSize(1));

            Balance(ListOfServersWith(theServer), ListOfVmsWith(theFirstVm, theSecondVm));

            Assert.That(theServer, HasVmsCountOf(2));
            Assert.That(theServer.Contains(theFirstVm), "The server should contain the vm");
            Assert.That(theServer.Contains(theSecondVm), "The server should contain the vm");
        }

        [Test]
        public void Vm_ShouldBeBalanced_OnLessLoadedServerFirst()
        {
            Server lessLoadedServer = A(Server().WithCapacity(100).WithCurrentLoadOf(45.0));
            Server moreLoadedServer = A(Server().WithCapacity(100).WithCurrentLoadOf(50.0));
            Vm theVm = A(Vm().OfSize(10));

            Balance(ListOfServersWith(moreLoadedServer, lessLoadedServer), ListOfVmsWith(theVm));

            Assert.That(lessLoadedServer.Contains(theVm), "The server should contain the vm");
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

        private Vm[] ListOfVmsWith(params Vm[] vms)
        {
            return vms;
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
