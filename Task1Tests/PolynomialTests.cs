using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1;

namespace Task1Tests
{
    [TestFixture]
    public class PolynomialTests
    {
        [TestCase(new double[] { 3, 4, 6 }, ExpectedResult = "P(x) = 3x^2 + 4x^1 + 6")]
        [TestCase(new double[] { 6, 6, 18, 5, -7 }, ExpectedResult = "P(x) = 6x^4 + 6x^3 + 18x^2 + 5x^1 + -7")]
        public string ToString_PositiveTests(double[] args)
        {
            return new Polynomial(args).ToString();
        }

        [TestCase(new double[] { 3, 4, 6 }, new double[] { 6, 6, 18, 5, -7 }, ExpectedResult = false)]
        [TestCase(new double[] { 3, 4, 6 }, new double[] { 3, 4, 6 }, ExpectedResult = true)]
        [TestCase(new double[] { 3, 4, 6 }, new double[] { }, ExpectedResult = false)]
        public bool Equals_PositiveTests(double[] args1, double[] args2)
        {
            return new Polynomial(args1).Equals(new Polynomial(args2));
        }

        [TestCase(new double[] { 3, 4, 6}, ExpectedResult = 3)]
        [TestCase(new double[] { }, ExpectedResult = 0)]
        public int GetHashCode_PositiveTests(double[] args)
        {
            return new Polynomial(args).GetHashCode();
        }

        [TestCase(new double[] { 3, 4, 6 }, new double[] { 6, 6, 18, 5, -7 }, ExpectedResult = "P(x) = 6x^4 + 6x^3 + 21x^2 + 9x^1 + -1")]
        [TestCase(new double[] { 3, 4, 6 }, new double[] { 3, 4, 6 }, ExpectedResult = "P(x) = 6x^2 + 8x^1 + 12")]
        public string Add_PositiveTests(double[] args1, double[] args2)
        {
            return (new Polynomial(args1) + new Polynomial(args2)).ToString();
        }

        [TestCase(new double[] { 3, 4, 6 }, new double[] { 6, 6, 18, 5, -7 }, ExpectedResult = "P(x) = -6x^4 + -6x^3 + -15x^2 + -1x^1 + 13")]
        [TestCase(new double[] { 6, -4, 9 }, new double[] { 3, 4, 6 }, ExpectedResult = "P(x) = 3x^2 + -8x^1 + 3")]
        public string Sub_PositiveTests(double[] args1, double[] args2)
        {
            return (new Polynomial(args1) - new Polynomial(args2)).ToString();
        }

        [TestCase(new double[] { 5, -8, 2 }, new double[] { 2, 3 }, ExpectedResult = "P(x) = 10x^3 + -1x^2 + -20x^1 + 6")]
        [TestCase(new double[] { 3, 2, 2 }, new double[] { 4, 3, 0, 5, 0 }, ExpectedResult = "P(x) = 12x^6 + 17x^5 + 14x^4 + 21x^3 + 10x^2 + 10x^1 + 0")]
        public string Mul_PositiveTests(double[] args1, double[] args2)
        {
            return (new Polynomial(args1) * new Polynomial(args2)).ToString();
        }

        [TestCase(new double[] { 3, 4 }, ExpectedResult = true)]
        [TestCase(new double[] { 4, 4 }, ExpectedResult = false)]
        public bool Eql_PositiveTests(double[] arr)
        {
            return new Polynomial(3, 4) == new Polynomial(arr);
        }

        [TestCase(new double[] { 3, 4 }, ExpectedResult = true)]
        [TestCase(new double[] { 4, 4 }, ExpectedResult = false)]
        public bool NotEql_PositiveTests(double[] arr)
        {
            return new Polynomial(4, 4) != new Polynomial(arr);
        }
    }
}