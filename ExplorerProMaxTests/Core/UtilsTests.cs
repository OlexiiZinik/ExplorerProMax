using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExplorerProMax.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerProMax.Core.Tests
{
    [TestClass()]
    public class UtilsTests
    {
        [TestMethod()]
        public void ListDirectoryTest()
        {
            var entitys = Utils.ListDirectory(new PathEntity.DirectoryInfo(@"C:\"));
            Assert.AreNotEqual(0, entitys.Count);
        }

        [TestMethod()]
        public void GetAllDisksTest()
        {
            var disks = Utils.GetAllDisks();
            Assert.AreNotEqual(0, disks.Count);
        }
    }
}