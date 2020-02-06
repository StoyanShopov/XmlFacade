using System;

namespace XmlFacade.Example
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ExampleOfDeserializer();
            ExampleOfSerializer();
        }

        private static void ExampleOfSerializer()
        {
            string xmlCarsPath = "carsNew.xml";
            string xmlRootAttribute = "Cars";

            CarDto[] carDtos = new CarDto[]
            {
                new CarDto(){ Make = "VW", Model = "Golf", TravelledDistance = 100000},
                new CarDto(){ Make = "VW", Model = "Passat", TravelledDistance = 2000},
            };

            XmlConverter.Serialize(xmlCarsPath, carDtos, xmlRootAttribute);
        }

        private static void ExampleOfDeserializer()
        {
            //Copy to output Directory - copy always
            string xmlCarsPath = "cars.xml";
            string xmlRootAttribute = "Cars";

            CarDto[] carDtos = XmlConverter
                .Deserializer<CarDto>(xmlCarsPath, xmlRootAttribute);

            foreach (var carDto in carDtos)
            {
                Console.WriteLine(carDto);
            }
        }
    }
}
