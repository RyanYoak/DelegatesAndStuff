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
    }
}
