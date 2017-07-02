using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StringXor;

namespace StringXor.Tests
{
    [TestFixture]
    public class StringExtensionTests
    {
        [Test]
        public void AddsExtensionMethod()
        {
            string testString = "This is a test string.";

            Assert.DoesNotThrow(() => { testString.Xor(); });
        }

        [Test]
        public void ReturnsJumbledString()
        {
            string testString = "This is a test string.";

            Assert.That(testString.Xor(), Is.Not.EqualTo(testString));
        }

        [Test]
        [TestCase("This is a test string.")]
        [TestCase("This is a different test string.")]
        [TestCase("Bacon ipsum dolor amet salami landjaeger sausage, turkey pastrami jowl shankle short loin ham rump chuck kielbasa biltong filet mignon. Andouille tri-tip swine leberkas frankfurter, tail salami. Beef pig jowl, picanha pork belly turducken landjaeger kevin rump cow ball tip corned beef. Rump short loin ham ham hock cow landjaeger cupim andouille pork chop. Pancetta leberkas pastrami, andouille boudin biltong pork chop landjaeger venison pork belly burgdoggen spare ribs porchetta. Hamburger shankle ball tip ham hock pork shoulder salami tenderloin prosciutto boudin sirloin filet mignon capicola jerky. Biltong salami tenderloin drumstick.")]
        [TestCase("<!DOCTYPE html><html><head><title>Page Title</title></head><body><h1>This is a Heading</h1><p>This is a paragraph.</p></body></html>")]
        public void RestoresTheOriginalString(string testString)
        {
            string jumbledString = testString.Xor();

            Assert.That(jumbledString.Xor(), Is.EqualTo(testString));
        }

        [Test]
        public void WorksWithAllAsciiCharacters()
        {
            string asciiChars = new String(Enumerable.Range('\x1', 127).Select(n => (char)n).ToArray());
            string jumbledString = asciiChars.Xor();

            Assert.That(jumbledString.Xor(), Is.EqualTo(asciiChars));
        }
    }
}
