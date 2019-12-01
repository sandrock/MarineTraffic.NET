
namespace MarineTrafficApiTests
{
    using MarineTrafficApi;
    using MarineTrafficApi.Internals;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using System.Text;

    [TestClass]
    public class UtilityTests
    {
        [TestMethod]
        public void CsvErrorFormat_1()
        {
            var line = "ERROR_1-INCORRECT CALL-CHECK PARAMETERS";
            var match = Utility.CsvErrorFormat.Match(line);
            Assert.IsTrue(match.Success);
            Assert.AreEqual("1", match.Groups[1].Value);
            Assert.AreEqual("INCORRECT CALL-CHECK PARAMETERS", match.Groups[2].Value);
            Assert.AreEqual("", match.Groups[4].Value);
        }

        [TestMethod]
        public void CsvErrorFormat_10()
        {
            var line = "ERROR_10-SERVICE KEY NOT FOUND";
            var match = Utility.CsvErrorFormat.Match(line);
            Assert.IsTrue(match.Success);
            Assert.AreEqual("10", match.Groups[1].Value);
            Assert.AreEqual("SERVICE KEY NOT FOUND", match.Groups[2].Value);
            Assert.AreEqual("", match.Groups[4].Value);
        }

        [TestMethod]
        public void CsvErrorFormat_5a2()
        {
            var line = "ERROR_5a2-INSUFFICIENT CREDITS. You currently have 100 credits while 826 is/are required to fulfil this API call. You can purchase additional credits at: https://www.marinetraffic.com/en/online-services/marinetraffic-credits";
            var match = Utility.CsvErrorFormat.Match(line);
            Assert.IsTrue(match.Success);
            Assert.AreEqual("5a2", match.Groups[1].Value);
            Assert.AreEqual("INSUFFICIENT CREDITS", match.Groups[2].Value);
            Assert.AreEqual("You currently have 100 credits while 826 is/are required to fulfil this API call. You can purchase additional credits at: https://www.marinetraffic.com/en/online-services/marinetraffic-credits", match.Groups[4].Value);
        }
    }
}
