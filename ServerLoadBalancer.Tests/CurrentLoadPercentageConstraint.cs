using System;
using NUnit.Framework.Constraints;

namespace ServerLoadBalancer.Tests
{
    internal class CurrentLoadPercentageConstraint : Constraint
    {
        private const double EPSILON = 0.01;
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
                return EqualsDouble(this.expectedLoadPerentage, this.actualLoadPercentage);
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

        private bool EqualsDouble(double d1, double d2)
        {
            return d1 == d2 || Math.Abs(d1 - d2) < EPSILON;
        }

        public static Constraint HasLoadPercentageOf(double expectedLoadPerentage)
        {
            return new CurrentLoadPercentageConstraint(expectedLoadPerentage);
        }
    }
}