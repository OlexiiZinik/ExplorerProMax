using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExplorerProMax.Core.PathEntity;
using System.IO;

namespace ExplorerProMax.Core.PathEntity.Tests
{
    [TestClass()]
    public class FileInfoTests
    {
        private FileInfo testFile1 = new FileInfo(@"C:\SomeFolder1\SomeFile1.exe", false);
        private FileInfo testFile2 = new FileInfo(@"C:\Some Folder 2\SomeFile2.txt", false);
        private FileInfo testFile3 = new FileInfo(@"C:\SomeFolder3\Some File 3.docx", false);
        private FileInfo testFile4 = new FileInfo(@"C:\Some Folder 4\Some File 4.pdf", false);
        private FileInfo testFile5 = new FileInfo(@"C:\Some File 5.pdf", false);
        private FileInfo testFile6 = new FileInfo(@"C:\.gitignore", false);
        private FileInfo testFile7 = new FileInfo(@"C:\file", false);
        private FileInfo testFile8 = new FileInfo(@"C:\.hidden_file.txt", false);

        [TestMethod()]
        public void GetNameTest()
        {
            Console.WriteLine(testFile1.Name);
            Assert.AreEqual(testFile1.Name, "SomeFile1");
            Assert.AreEqual(testFile2.Name, "SomeFile2");
            Assert.AreEqual(testFile3.Name, "Some File 3");
            Assert.AreEqual(testFile4.Name, "Some File 4");
            Assert.AreEqual(testFile5.Name, "Some File 5");
            Assert.AreEqual(testFile6.Name, ".gitignore");
            Assert.AreEqual(testFile7.Name, "file");
            Assert.AreEqual(testFile8.Name, ".hidden_file");
        }

        [TestMethod()]
        public void GetExtentionTest()
        {
            Assert.AreEqual(testFile1.Extention, "exe");
            Assert.AreEqual(testFile2.Extention, "txt");
            Assert.AreEqual(testFile3.Extention, "docx");
            Assert.AreEqual(testFile4.Extention, "pdf");
            Assert.AreEqual(testFile6.Extention, "");
            Assert.AreEqual(testFile7.Extention, "");
            Assert.AreEqual(testFile8.Extention, "txt");
        }

        [TestMethod()]
        public void GetLocationTest()
        {
            Console.WriteLine(testFile1.Location);
            Assert.AreEqual(testFile1.Location, @"C:\SomeFolder1\");
            Assert.AreEqual(testFile2.Location, @"C:\Some Folder 2\");
            Assert.AreEqual(testFile3.Location, @"C:\SomeFolder3\");
            Assert.AreEqual(testFile4.Location, @"C:\Some Folder 4\");
        }

        [TestMethod()]
        [ExpectedException(typeof(FileNotFoundException))]
        public void DoesNotExistsTest()
        {
            FileInfo testFile = new FileInfo(@"C:\Some Folder 4\Some File 4.pdf");
        }

        [TestMethod()]
        public void ExistsTest()
        {
            FileInfo test1File = new FileInfo(@"C:\Windows\regedit.exe");
            
            //FileInfo test2File = new FileInfo(@"C:\appverifUI.dll");
        }
    }
}