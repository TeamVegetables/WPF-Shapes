﻿using System.Collections.Generic;
using System.IO;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace WPF_Shapes.DAL
{
    /// <summary>
    /// Static class for hexagon serialization.
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
            Stream stream = new FileStream(fileName, FileMode.Create);
            new XmlSerializer(typeof(Dictionary<string, Shape>)).Serialize(stream, pentagons);
            stream.Close();
        }

        /// <summary>
        /// Deserializes names of pentagons and pentagons to a dictionary.
        /// </summary>
        /// <param name="fileName">Path to source file.</param>
        /// <returns>>A dictionary of names of pentagons of deserialized pentagons.</returns>
        public static Dictionary<string, Shape> DeserializePentagons(string fileName)
        {
            Stream stream = new FileStream(fileName, FileMode.Open);
            var result = new XmlSerializer(typeof(Dictionary<string, Shape>)).Deserialize(stream) as Dictionary<string, Shape>;
            stream.Close();
            return result;
        }
    }
}