namespace XmlFacade
{
    using System.IO;
    using System.Xml.Serialization;

    public static class XmlConverter
    {
        public static void Serialize<T>(
            string path, 
            T dataTransferObjects, 
            string xmlRootAttributeName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T), new XmlRootAttribute(xmlRootAttributeName));

            using (var writer = new StreamWriter(path))
            {
                serializer.Serialize(writer, dataTransferObjects, GetXmlNamespaces());
            }
        }

        public static void Serialize<T>(
            string path, 
            T[] dataTransferObjects, 
            string xmlRootAttributeName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T[]), new XmlRootAttribute(xmlRootAttributeName));

            using (var writer = new StreamWriter(path))
            {
                serializer.Serialize(writer, dataTransferObjects, GetXmlNamespaces());
            }
        }

        public static T[] Deserializer<T>(
            string path,
            string xmlRootAttributeName)
        {                                  
            XmlSerializer serializer = new XmlSerializer(typeof(T[]), new XmlRootAttribute(xmlRootAttributeName));

            string xmlObjectsAsString = File.ReadAllText(path);

            var dataTransferObjects = serializer.Deserialize(new StringReader(xmlObjectsAsString)) as T[];

            return dataTransferObjects;
        }

        public static T Deserializer<T>(
            string path,
            string xmlRootAttributeName,
            bool isSampleObject)
            where T : class
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T), new XmlRootAttribute(xmlRootAttributeName));

            string xmlObjectsAsString = File.ReadAllText(path);

            var dataTransferObjects = serializer.Deserialize(new StringReader(xmlObjectsAsString)) as T;

            return dataTransferObjects;
        }

        private static XmlSerializerNamespaces GetXmlNamespaces()
        {
            XmlSerializerNamespaces xmlNamespaces = new XmlSerializerNamespaces();
            xmlNamespaces.Add(string.Empty, string.Empty);
            return xmlNamespaces;
        }
    }
}
