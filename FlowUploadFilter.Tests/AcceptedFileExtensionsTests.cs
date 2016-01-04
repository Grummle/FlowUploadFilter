using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FlowUploadFilter.Tests
{
    [TestClass]
    public class AcceptedFileExtensionTests
    {
        [TestMethod]
        public void ExtensionAccepted_SameCase()
        {
            var tester = new AcceptedFileExtensions();

            var acceptedExtensions = new List<string> {"txt", "png", "pdf"};

            var result = tester.IsExtensionAllowed(acceptedExtensions, "test.txt");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ExtensionAccepted_DifferentCase()
        {
            var tester = new AcceptedFileExtensions();

            var acceptedExtensions = new List<string> { "txt", "png", "pdf" };

            var result = tester.IsExtensionAllowed(acceptedExtensions, "test.TXT");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ExtensionInvalid_InvalidExtension()
        {
            var tester = new AcceptedFileExtensions();

            var acceptedExtensions = new List<string> { "txt", "png", "pdf" };

            var result = tester.IsExtensionAllowed(acceptedExtensions, "test.invalid");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ExtensionInvalid_NoExtension()
        {
            var tester = new AcceptedFileExtensions();

            var acceptedExtensions = new List<string> { "txt", "png", "pdf" };

            var result = tester.IsExtensionAllowed(acceptedExtensions, "test");

            Assert.IsFalse(result);
        }
    }
}
