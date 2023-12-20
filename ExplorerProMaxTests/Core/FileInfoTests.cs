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
        private FileEntity testFile1 = new FileEntity(@"C:\SomeFolder1\SomeFile1.exe", false);
        private FileEntity testFile2 = new FileEntity(@"C:\Some Folder 2\SomeFile2.txt", false);
        private FileEntity testFile3 = new FileEntity(@"C:\SomeFolder3\Some File 3.docx", false);
        private FileEntity testFile4 = new FileEntity(@"C:\Some Folder 4\Some File 4.pdf", false);
        private FileEntity testFile5 = new FileEntity(@"C:\Some File 5.pdf", false);
        private FileEntity testFile6 = new FileEntity(@"C:\.gitignore", false);
        private FileEntity testFile7 = new FileEntity(@"C:\file", false);
        private FileEntity testFile8 = new FileEntity(@"C:\.hidden_file.txt", false);

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
            FileEntity testFile = new FileEntity(@"C:\Some Folder 4\Some File 4.pdf");
        }

        [TestMethod()]
        public void ExistsTest()
        {
            FileEntity test1File = new FileEntity(@"C:\Windows\regedit.exe");
            
            //FileInfo test2File = new FileInfo(@"C:\appverifUI.dll");
        }
    }
}