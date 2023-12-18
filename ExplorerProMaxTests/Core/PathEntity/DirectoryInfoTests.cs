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
    public class DirectoryInfoTests
    {
        public PathEntity.DirectoryInfo directory1 = new PathEntity.DirectoryInfo(@"C:\Users\", false);
        public PathEntity.DirectoryInfo directory2 = new PathEntity.DirectoryInfo(@"C:\", false);
        public PathEntity.DirectoryInfo directory3 = new PathEntity.DirectoryInfo(@"C:\Some Directory\", false);
        [TestMethod()]
        public void GetNameTest()
        {
            Assert.AreEqual(directory1.Name, "Users");
            Assert.AreEqual(directory2.Name, "C:");
            Assert.AreEqual(directory3.Name, "Some Directory");
        }

        [TestMethod()]
        [ExpectedException(typeof(DirectoryNotFoundException))]
        public void DoesNotExistsTest()
        {
            PathEntity.DirectoryInfo directory1 = new PathEntity.DirectoryInfo(@"C:\UgaBuga\");
        }

        [TestMethod()]
        public void ExistsTest()
        {
            PathEntity.DirectoryInfo directory1 = new PathEntity.DirectoryInfo(@"C:\");
        }
    }
}