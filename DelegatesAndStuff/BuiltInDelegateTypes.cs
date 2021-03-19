using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace DelegatesAndStuff
{
    public class BuiltInDelegateTypes
    {
        private readonly ITestOutputHelper output;

        public BuiltInDelegateTypes(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void ActionTypes()
        {
            // Actions are built in delegate types for methods
            // that return void
            // and take 0 - 16 arguments
            Action doIt;
            doIt = () => output.WriteLine("Did it.");
            doIt();

            Action<int, string> doItMultipleTimes;
            doItMultipleTimes = (times, message) =>
            {
                for (var t = 0; t < times; t++)
                {
                    output.WriteLine(message);
                }
            };
            doItMultipleTimes(10, "And I'll do it again!");
        }

        [Fact]
        public void FuncTypes()
        {
            // Func types are built in delegate types for methods
            // that return somethign
            // can take up to 16 arguments
            // Arguments go first and last is what is returned

            Func<string, int> getLengthOf = (s) => s.Length;
            Assert.Equal(9, getLengthOf("Han, Solo"));

            Func<int, int, int> mathOp;
            mathOp = (a, b) => a + b;
            Assert.Equal(4, mathOp(2, 2));

            mathOp = (a, b) => a * b;
            Assert.Equal(9, mathOp(3, 3));

            var calculator = new Dictionary<char, Func<int, int, int>>()
            {
                { '+', (a, b) => a + b },
                { '-', (a, b) => a - b },
                { '*', (a, b) => a * b },
                { '/', (a, b) => a / b },
                { '%', (a, b) => a % b }
            };

            var sum = calculator['+'](10, 2);
            Assert.Equal(12, sum);

            var product = calculator['*'](5, 5);
            Assert.Equal(25, product);
        }
    }
}
