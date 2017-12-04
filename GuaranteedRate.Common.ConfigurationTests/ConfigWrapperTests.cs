using System;
using GuaranteedRate.Common.Configuration;
using NUnit.Framework;
using FluentAssertions;


namespace GuaranteedRate.Common.ConfigurationTests
{
    [TestFixture]
    public class ConfigWrapperTests
    {
        [Test()]
        [TestCase("missingkey", 10, 10, false)]
        [TestCase("integer.success.test", 10, 12, false)]
        [TestCase("integer.fail.test", 12, 12, true)]
        public void IntegerTests(string key, int defaultValue, int expectedValue, bool throwArgumentException)
        {

            if (throwArgumentException)
            {
                Action act = () => ConfigHelper.GetAppSetting<int>(key, defaultValue, true);
                act.ShouldThrow<Exception>();
            }
            else
            {
                ConfigHelper.GetAppSetting<int>(key, defaultValue).Should().Be(expectedValue);
            }
        }

        [TestCase("missingkey", 10.02, 10.02, false)]
        [TestCase("decimal.success.test", 10.02, 12.02, false)]
        [TestCase("decimal.fail.test", 12.02, 12.02, true)]
        public void DecimalTests(string key, decimal defaultValue, decimal expectedValue, bool throwArgumentException )
        {

           
            if (throwArgumentException)
            {
                Action act = () => ConfigHelper.GetAppSetting<decimal>(key, defaultValue, true);
                act.ShouldThrow<Exception>();
            }
            else
            {
                ConfigHelper.GetAppSetting<decimal>(key, defaultValue).Should().Be(expectedValue); 
            }
        }
        [Test]
        public void DecimalArrayTests()
        {
            Action act = () => ConfigHelper.GetAppSetting<int[]>("integer.array.success.test", null, new[] { ',' });
            act.Should().Be(new []{12,13,14})
            ;

        }
    }
}
