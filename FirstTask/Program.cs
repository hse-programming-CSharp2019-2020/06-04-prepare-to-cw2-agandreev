using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EKRLib;
using System.IO;
using System.Runtime.Serialization.Json;

namespace FirstTask
{
    class Program
    {
        const string SER_PATH = @"boxes.json";
        static readonly Random rnd = new Random();
        static void Main()
        {
            do
            {
                int n;
                do
                {
                    Console.WriteLine("Введите N");
                } while (!int.TryParse(Console.ReadLine(), out n) || (n <= 0));

                Collection<Box> boxes = CreateBoxes(n);
                PrintBoxes(boxes);

                try
                {
                    BoxSerialization(boxes);
                }
                catch (Exception)
                {
                    Console.WriteLine("Problems with file access");
                }

                Console.WriteLine("Введите ESC, чтобы завешить программу...");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        static Collection<Box> CreateBoxes(int n)
        {
            Collection<Box> boxes = new Collection<Box>();

            for (int i = 0; i < n; i++)
            {
                try
                {
                    double a = rnd.Next(-3, 10) + rnd.NextDouble();
                    double b = rnd.Next(-3, 10) + rnd.NextDouble();
                    double c = rnd.Next(-3, 10) + rnd.NextDouble();
                    double weight = rnd.Next(-3, 10) + rnd.NextDouble();
                    boxes.Add(new Box(a, b, c, weight));
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Problems with Box creation.");
                    i--;
                }
            }
            return boxes;
        }

        static void PrintBoxes(Collection<Box> boxes)
        {
            foreach (Box box in boxes)
            {
                Console.WriteLine(box.ToString());
            }
        }

        static void BoxSerialization(Collection<Box> boxes)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Collection<Box>));
            using (FileStream fs = new FileStream(SER_PATH, FileMode.Create))
            {
                ser.WriteObject(fs, boxes);
            }
        }
    }
}

