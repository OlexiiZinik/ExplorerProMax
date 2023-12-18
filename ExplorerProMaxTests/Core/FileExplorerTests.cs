using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExplorerProMax.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ExplorerProMax.Core.Tests
{
    [TestClass()]
    public class FileExplorerTests
    {
        

        [TestMethod()]
        public void BackwardTest()
        {
            FileExplorer fe = new FileExplorer();
            fe.ChangeDirectory(new PathEntity.DirectoryInfo(@"C:\"));
            fe.ChangeDirectory(new PathEntity.DirectoryInfo(@"C:\Users\"));
            fe.ChangeDirectory(new PathEntity.DirectoryInfo(@"C:\Users\Public\"));

            fe.Backward();
            Assert.AreEqual(@"C:\Users\", fe.CurrentWorkingDirectory.FullPath);

            fe.Backward();
            Assert.AreEqual(@"C:\", fe.CurrentWorkingDirectory.FullPath);
        }

        [TestMethod()]
        [ExpectedException(typeof(DirectoryNotFoundException))]
        public void BackwardNotExistingTest()
        {
            FileExplorer fe = new FileExplorer();
            fe.ChangeDirectory(new PathEntity.DirectoryInfo(@"C:\"));

            fe.Backward();
        }

        [TestMethod()]
        public void ForwardTest()
        {
            FileExplorer fe = new FileExplorer();
            fe.ChangeDirectory(new PathEntity.DirectoryInfo(@"C:\"));
            fe.ChangeDirectory(new PathEntity.DirectoryInfo(@"C:\Users\"));
            fe.ChangeDirectory(new PathEntity.DirectoryInfo(@"C:\Users\Public\"));

            fe.Backward();
            Assert.AreEqual(@"C:\Users\", fe.CurrentWorkingDirectory.FullPath);

            fe.Backward();
            Assert.AreEqual(@"C:\", fe.CurrentWorkingDirectory.FullPath);

            bool more = fe.Forward();
            Assert.IsTrue(more);
            Assert.AreEqual(@"C:\Users\", fe.CurrentWorkingDirectory.FullPath);

            more = fe.Forward();
            Assert.IsFalse(more);
            Assert.AreEqual(@"C:\Users\Public\", fe.CurrentWorkingDirectory.FullPath);
        }

        [TestMethod()]
        public void ForwardBranchTest()
        {
            FileExplorer fe = new FileExplorer();
            fe.ChangeDirectory(new PathEntity.DirectoryInfo(@"C:\"));
            fe.ChangeDirectory(new PathEntity.DirectoryInfo(@"C:\Users\"));
            fe.ChangeDirectory(new PathEntity.DirectoryInfo(@"C:\Users\Public\"));
            Assert.AreEqual(@"C:\Users\Public\", fe.CurrentWorkingDirectory.FullPath);

            fe.Backward();
            Assert.AreEqual(@"C:\Users\", fe.CurrentWorkingDirectory.FullPath);

            fe.ChangeDirectory(new PathEntity.DirectoryInfo(@"C:\Users\Default\"));
            Console.WriteLine(fe.CurrentWorkingDirectory.FullPath);
            fe.Backward();
            Console.WriteLine(fe.CurrentWorkingDirectory.FullPath);
            Assert.AreEqual(@"C:\Users\", fe.CurrentWorkingDirectory.FullPath);

            bool more = fe.Forward();
            Assert.IsFalse(more);
            Assert.AreEqual(@"C:\Users\Default\", fe.CurrentWorkingDirectory.FullPath);
        }
    }
}