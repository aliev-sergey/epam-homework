using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace ObjectCoordiantes
{
    /// <summary>
    /// Класс, который хранит координаты в удобочитаемой форме
    /// </summary>
    public class Coordinates
    {
        /// <summary>
        /// Связный список хранит значения строк с координатами
        /// независимо от способа их получения
        /// </summary>
        private List<string> _coordinatePairs = new List<string>();

        /// <summary>
        /// Конструктор для значений, которые хранятся в качестве массива строк
        /// </summary>
        /// <param name="cooridnatePairs"></param>
        public Coordinates(string[] cooridnatePairs)
        {
            foreach (string pair in cooridnatePairs)
            {
                this._coordinatePairs.Add(pair);
            }
        }
        /// <summary>
        /// Конструктор для пары значений, переданной в виде двух строк
        /// </summary>
        /// <param name="firstCoordinate">первое значение</param>
        /// <param name="secondCoordiante">второе значение</param>
        public Coordinates(string firstCoordinate, string secondCoordiante)
        {
            this._coordinatePairs.Add(String.Format("{0},{1}", firstCoordinate, secondCoordiante));
        }
        /// <summary>
        /// Конструктор, извлекающий строки из тектового файла
        /// </summary>
        /// <param name="path">путь до файла</param>
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

        /// <summary>
        /// Переопределение метода ToString()
        /// </summary>
        /// <returns>Отформатированная строка</returns>
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
