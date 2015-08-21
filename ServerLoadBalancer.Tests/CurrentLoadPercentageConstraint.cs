using System;
using NUnit.Framework.Constraints;

namespace ServerLoadBalancer.Tests
{
    internal class CurrentLoadPercentageConstraint : Constraint
    {
        private double expectedLoadPerentage;
        private double actualLoadPercentage;

        public CurrentLoadPercentageConstraint(double expectedLoadPerentage)
        {
            this.expectedLoadPerentage = expectedLoadPerentage;
        }

        public override bool Matches(object actual)
        {
            if (actual is Server)
            {
                var server = (Server)actual;
                this.actualLoadPercentage = server.CurrentLoadPercentage;
                return this.actualLoadPercentage == this.expectedLoadPerentage 
                       || Math.Abs(this.actualLoadPercentage - this.expectedLoadPerentage) < 0.01;
            }

            throw new ArgumentException("Argument should be of type Server");
        }

        public override void WriteDescriptionTo(MessageWriter writer)
        {
            writer.WriteExpectedValue(this.expectedLoadPerentage);
        }

        public override void WriteActualValueTo(MessageWriter writer)
        {
            writer.WriteActualValue(this.actualLoadPercentage);
        }
    }
}