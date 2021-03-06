﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Shapes;

namespace WPF_Shapes.DAL
{
    /// <summary>
    /// Represents a file manager
    /// </summary>
    public static class FileManager 
    {
        /// <summary>
        /// Loads all shapes from  the file.
        /// </summary>
        /// <param name="filePath">A file path.</param>
        /// <returns>Collection of shapes.</returns>
        public static void Load(string filePath, Dictionary<string, Shape> shapes)
        {
            if (filePath == null)
            {
                throw new ArgumentNullException(nameof(filePath));
            }

            int countShapes = shapes.Count;
            using (var reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    var values = reader.ReadLine()?.Split(';');
                    var shape = new Polygon();
                    var shapeName = $"Pentagon{++countShapes}";
                    for (int i = 0; i < values.Length - 1; i++)
                    {
                        shape.Points.Add(new Point(double.Parse(values[i]), double.Parse(values[i + 1])));
                    }
                    shapes.Add(shapeName, shape);
                }
            }
        }

        /// <summary>
        /// Saves all shapes to the file.
        /// </summary>
        /// <param name="filePath">A file path.</param>
        /// <param name="shapes">Collection of shapes.</param>
        /// <returns>True - if shapes successfully saved in the file, otherwise - false.</returns>
        public static bool Save(string filePath, Dictionary<string, Shape> shapes)
        {
            if (filePath == null)
            {
                throw new ArgumentNullException(nameof(filePath));
            }

            using (var writer = new StreamWriter(filePath))
            {
                foreach (var shape in shapes)
                {
                    var points = ((Polygon) shape.Value).Points;
                    writer.WriteLine($"{string.Join(";",points)}");
                }
            }
            return true;
        }
    }
}
