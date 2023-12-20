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
        public PathEntity.DirectoryEntity directory1 = new PathEntity.DirectoryEntity(@"C:\Users\", false);
        public PathEntity.DirectoryEntity directory2 = new PathEntity.DirectoryEntity(@"C:\", false);
        public PathEntity.DirectoryEntity directory3 = new PathEntity.DirectoryEntity(@"C:\Some Directory\", false);
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
            PathEntity.DirectoryEntity directory1 = new PathEntity.DirectoryEntity(@"C:\UgaBuga\");
        }

        [TestMethod()]
        public void ExistsTest()
        {
            PathEntity.DirectoryEntity directory1 = new PathEntity.DirectoryEntity(@"C:\");
        }
    }
}