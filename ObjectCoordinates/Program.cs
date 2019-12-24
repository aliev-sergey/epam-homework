using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace ObjectCoordiantes
{
    public class Coordinates
    {
        private List<string> _coordinatePairs = new List<string>();

        public Coordinates(string[] cooridnatePairs)
        {
            foreach (string pair in cooridnatePairs)
            {
                this._coordinatePairs.Add(pair);
            }
        }

        public Coordinates(string firstCoordinate, string secondCoordiante)
        {
            this._coordinatePairs.Add(String.Format("{0},{1}", firstCoordinate, secondCoordiante));
        }

        public Coordinates(string path)
        {
            StreamReader sr = new StreamReader(path, System.Text.Encoding.Default);

            if (sr == null)
            {
                throw new IOException("Данный файл не найден или название файла указано неверно");
            }

            string line;

            while ((line = sr.ReadLine()) != null)
            {
                this._coordinatePairs.Add(line);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (string pair in this._coordinatePairs)
            {
                string[] XYCoordinates = pair.Split(',');

                sb.Append(String.Format("X: {0}   Y: {1}\n", XYCoordinates[0], XYCoordinates[1]));
            }

            return sb.Length == 0 ? "" : sb.Remove(sb.Length - 1, 1).ToString();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            string[] coords = new string[] { "23.8976,12.3218", "25.76,11.9463", "24.8293,12.2" };

            Console.Write("Введите название файла: ");

            try
            {
                Coordinates coordinates1 = new Coordinates(Console.ReadLine());
                Console.WriteLine(coordinates1.ToString());
            }
            catch(IOException io)
            {
                Console.WriteLine(io.Message);
            }   

            Console.WriteLine("Значения из массива:");

            Coordinates coordinates3 = new Coordinates(coords);

            Console.WriteLine(coordinates3.ToString());

            Console.Read();
        }
    }
}
