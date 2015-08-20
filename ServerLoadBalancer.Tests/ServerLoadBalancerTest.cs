using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ServerLoadBalancer.Tests
{
    [TestFixture]
    class ServerLoadBalancerTest
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

            Balance(ListOfServersWith(theServer), emptyListOfVms());

            Assert.That(theServer, HasLoadPercentageOf(0.0));
        }
    }
}
