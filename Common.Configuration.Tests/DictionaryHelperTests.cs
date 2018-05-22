using System.Collections.Generic;
using Common.Configuration;
using NUnit.Framework;

namespace Common.ConfigurationTests
{
    [TestFixture()]
    public class DictionaryHelperTests
    {
        [Test()]
        public void ValueTest()
        {
            var dict = new Dictionary<string,string>();
            dict.Add("foo", "bar");
            dict.Add("bar", "7");
            Assert.That(dict.GetValue<string>("foo","xxxx")=="bar");
            Assert.That(dict.GetValue<string>("zip", "xxxx") == "xxxx");
            Assert.That(dict.GetValue<int>("bar", 9,true)==7);
        }
    }
}