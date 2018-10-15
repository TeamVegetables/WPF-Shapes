using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Shapes;
using System.Xml.Serialization;
using WPF_Shapes.BLL.Adapters;

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
            var shapes = pentagons.Select(i => new KeyValuePair<string, PolygonInfo>(i.Key, new PolygonInfo((Polygon)i.Value)))
                .ToDictionary(i => i.Key, i => i.Value);

            using (Stream stream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                new BinaryFormatter().Serialize(stream, shapes);
            }
        }

        /// <summary>
        /// Deserializes names of pentagons and pentagons to a dictionary.
        /// </summary>
        /// <param name="fileName">Path to source file.</param>
        /// <returns>>A dictionary of names of pentagons of deserialized pentagons.</returns>
        public static Dictionary<string, Shape> DeserializePentagons(string fileName)
        {
            Dictionary<string, PolygonInfo> result = null;
            using (Stream stream = new FileStream(fileName, FileMode.Open))
            {
                result = new BinaryFormatter().Deserialize(stream) as Dictionary<string, PolygonInfo>;
            }

            return result.Select(i => new KeyValuePair<string, Shape>(i.Key, i.Value.ConvertToPolygon()))
                .ToDictionary(i => i.Key, i => i.Value);
        }
    }
}
