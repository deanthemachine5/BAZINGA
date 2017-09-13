using System;
using WebMonitorService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebMonitorService.Objects;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestExecute()
        {
            WebMonitor.Execute();
        }
    }
}
