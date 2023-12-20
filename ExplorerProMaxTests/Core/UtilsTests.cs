using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ExplorerProMax.Core.FileSystem;

namespace ExplorerProMax.Core.Tests
{
    [TestClass()]
    public class UtilsTests
    {
        private FileSystemManager _fileSystemManager = new WindowsFileSystemManager();
        [TestMethod()]
        public void ListDirectoryTest()
        {
            var entitys = _fileSystemManager.ListDirectory(new PathEntity.DirectoryEntity(@"C:\"));
            Assert.AreNotEqual(0, entitys.Count);
        }

        [TestMethod()]
        public void GetAllDisksTest()
        {
            var disks = _fileSystemManager.GetAllDisks();
            Assert.AreNotEqual(0, disks.Count);
        }

        [TestMethod()]
        public void GetParentTest()
        {
            var testDirectory1 = new PathEntity.DirectoryEntity(@"C:\Program Files\");
            var testParent1 = _fileSystemManager.GetParent(testDirectory1);
            Assert.AreEqual(testParent1.FullPath, @"C:\");


            var testFile2 = new PathEntity.FileEntity(@"C:\Windows\explorer.exe");
            Console.WriteLine(testFile2.FullPath);
            var testParent2 = _fileSystemManager.GetParent(testFile2);
            Console.WriteLine(testParent2.FullPath);
            Assert.AreEqual(@"C:\Windows\", testParent2.FullPath);

            var testDirectory3 = new PathEntity.DirectoryEntity(@"C:\");
            var testParent3 = _fileSystemManager.GetParent(testDirectory3);
            Assert.IsNull(testParent3);
        }
    }
}