using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExplorerProMax.Core.PathEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ExplorerProMax.Core.PathEntity.Tests
{
    [TestClass()]
    public class DiskInfoTests
    {
        public PathEntity.DriveEntity disk1 = new PathEntity.DriveEntity(@"C:\", false);
        [TestMethod()]
        public void GetNameTest()
        {
            Assert.AreEqual(disk1.Name, "C:");
        }

        [TestMethod()]
        [ExpectedException(typeof(DriveNotFoundException))]
        public void DoesNotExistsTest1()
        {
            PathEntity.DriveEntity disk1 = new PathEntity.DriveEntity("J:/");
        }
    }
}