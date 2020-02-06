using NUnit.Framework;
using System.IO;

namespace XmlFacade.Tests
{
    public class SerializerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SerializeMethod_ShouldCreateXmlFileUponValidParameters()
        {
            //Arrange
            string xmlDummiesPath= "dummy.xml";
            string xmlRootAttribute = "Dummies";

            DummyObject[] dummyObjects = new DummyObject[]
            {
                new DummyObject()
                { 
                    Name = "SomeName", Number = 100000
                },
                new DummyObject()
                {
                    Name = "RandomName", Number = 2000
                },
            };
            
            //Act
            XmlConverter.Serialize(xmlDummiesPath, dummyObjects, xmlRootAttribute);

            //Assert
            var xmlAsString = File.ReadAllText("dummy.xml");

            string expectedOutput = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<Dummies>\r\n  <DummyObject>\r\n    <Name>SomeName</Name>\r\n    <Number>100000</Number>\r\n  </DummyObject>\r\n  <DummyObject>\r\n    <Name>RandomName</Name>\r\n    <Number>2000</Number>\r\n  </DummyObject>\r\n</Dummies>";

            Assert.That(xmlAsString, Is.EqualTo(expectedOutput).NoClip,
                $"Output is incorrect!");
        }
    }
}