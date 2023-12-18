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

        [TestMethod()]
        public void GetParentTest()
        {
            var testDirectory1 = new PathEntity.DirectoryInfo(@"C:\Program Files\");
            var testParent1 = Utils.GetParent(testDirectory1);
            Assert.AreEqual(testParent1.FullPath, @"C:\");


            var testFile2 = new PathEntity.FileInfo(@"C:\Windows\explorer.exe");
            Console.WriteLine(testFile2.FullPath);
            var testParent2 = Utils.GetParent(testFile2);
            Console.WriteLine(testParent2.FullPath);
            Assert.AreEqual(@"C:\Windows\", testParent2.FullPath);

            var testDirectory3 = new PathEntity.DirectoryInfo(@"C:\");
            var testParent3 = Utils.GetParent(testDirectory3);
            Assert.IsNull(testParent3);

        }
    }
}