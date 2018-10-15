using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace WPF_Shapes.DAL
{
    /// <summary>
    /// Static class for pentagon serialization.
    /// </summary>
    public static class SerializationManager
    {
        /// <summary>
        /// Serializes a dictionary of names of pentagons and pentagons of pentagons to a file.
        /// </summary>
        /// <param name="fileName">Path to target file.</param>
        /// <param name="pentagons">A dictionary of names of pentagons and pentagons to serialize.</param>
        public static void SerializePentagons(string fileName, Dictionary<string, Shape> pentagons)
        {
            using (Stream stream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                new XmlSerializer(typeof(Dictionary<string, Shape>), new Type[]{typeof(Polygon)}).Serialize(stream, pentagons);
            }
        }

        /// <summary>
        /// Deserializes names of pentagons and pentagons to a dictionary.
        /// </summary>
        /// <param name="fileName">Path to source file.</param>
        /// <returns>>A dictionary of names of pentagons of deserialized pentagons.</returns>
        public static Dictionary<string, Shape> DeserializePentagons(string fileName)
        {
            Dictionary<string, Shape> result=null;
            using (Stream stream = new FileStream(fileName, FileMode.Open))
            {
               result = new XmlSerializer(typeof(Dictionary<string, Shape>)).Deserialize(stream) as Dictionary<string, Shape>;
            }
            return result;
        }
    }
}
