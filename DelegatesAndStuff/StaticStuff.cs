using DelegatesAndStuff.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace DelegatesAndStuff
{
    public class StaticStuff
    {
        private readonly ITestOutputHelper output;

        public StaticStuff(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void AnonymousTypes()
        {
            // AT are types or objects without a class
            var meeting = new { Time = "Noon", Where = "Zoom" };
            Assert.Equal("Noon", meeting.Time);
            Assert.Equal("Zoom", meeting.Where);

            var friends = new List<String> { "Time", "Bill", "Sue", "Ray" };

            var friendInfo = friends.Where(f => f.Length >= 3)
                .Select(f => new
                {
                    Name = f,
                    NameInUpper = f.ToUpper(),
                    Letter = f.Length
                });

            foreach(var friend in friendInfo)
            {
                output.WriteLine(friend.Name + " has this many letters: " + friend.Letter);
            }
        }

        [Fact]
        public void UsingUsingAStaticMethod()
        { 
            // JET -> Data Access Objects (DAO)
            // ODBC (Open Database Connectivity) for Relational databases
            // OLE_DB -> ActiveX Data Objects (ADO) "Universal Data Access"
            // ADO.NET (OleDb, OdbC, how, standards-based xml)
                /// Entity Frameworkd used ADO.NET
                /// Dapper


            var name = Utils.FormatName("Luke", "Skywalder");

            Assert.Equal("Skywalder, Luke", name);

            Assert.True(14.IsEven());
            Assert.False(Utils.IsEven(3));
            Assert.Equal("<p>awesome</p>", "p".MakeTag("awesome"));

            var dateOfOrderShipped = new DateTime(2021, 3, 21);

            Assert.Equal(2.DaysFromToday().Date, dateOfOrderShipped.Date);
        }
    }
}
