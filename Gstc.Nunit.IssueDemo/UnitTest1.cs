using System;
using AutoFixture;
using NUnit.Framework;

namespace Gstc.Nunit.IssueDemo {
    
    /// <summary>
    /// Test demonstrating randomly generated TestCaseSources don't display as ran MS Test Runner, but do in Resharper Test Runner.
    /// </summary>
    public class Tests {
        static readonly Fixture _fixture  = new();
        static readonly Random _random = new();

        private static double[] DefaultStaticValue { get; } = {
            1234.0,
            _random.NextDouble(),
        };

        private static object?[] DefaultStaticValueAutoFixture { get; } = {
            null,
            _fixture.Create<object>(),
            _fixture.Create<string>(),
            _fixture.Create<int>(),
            _fixture.Create<double>()
        };


        [Test, TestCaseSource(nameof(DefaultStaticValue))]
        public void TestMethod_Random(double item) {
            Console.WriteLine(item);
        }

        [Test, TestCaseSource(nameof(DefaultStaticValueAutoFixture))]
        public void TestMethod_AutoFixture(object? item) {
            Console.WriteLine(item == null ? "null" : item.ToString());
        }
    }
}