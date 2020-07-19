namespace XmlFacade.Example
{
    using System.Xml.Serialization;

    [XmlType("Car")]
    public class CarDto
    {
        [XmlElement("Make")]
        public string Make { get; set; }

        [XmlElement("Model")]
        public string Model { get; set; }

        [XmlElement("Traveled-Distance")]
        public long Traveled { get; set; }

        public override string ToString()
        {
            return $"Make: {this.Make} -- Model: {this.Model} -- Traveled-Distance {this.Traveled}";
        }
    }
}
