using System;

namespace XmlFacade.Example
{
    using System.IO;

    public class Program
    {
        public static void Main(string[] args)
        {
            ExampleOfDeserializer();
            ExampleOfSerializer();
        }

        private static void ExampleOfSerializer()
        {
            const string xmlRootAttribute = "Cars";

            CarDto[] carDtos =
            {
                new CarDto { Make = "VW", Model = "Golf", Traveled = 100000},
                new CarDto { Make = "VW", Model = "Passat", Traveled = 2000},
            };

            var result = XmlConverter.Serialize(carDtos, xmlRootAttribute);

            Console.WriteLine(result);
        }

        private static void ExampleOfDeserializer()
        {
            //Copy to output Directory - copy always
            string xmlCarsAsXMLString = File.ReadAllText("cars.xml");
            string xmlRootAttribute = "Cars";

            CarDto[] carDtos = XmlConverter
                .Deserializer<CarDto>(xmlCarsAsXMLString, xmlRootAttribute);

            foreach (var carDto in carDtos)
            {
                Console.WriteLine(carDto);
            }
        }
    }
}
