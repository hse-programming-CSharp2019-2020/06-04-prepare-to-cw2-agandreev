using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EKRLib;
using System.Runtime.Serialization.Json;
using System.IO;

namespace SecondTask
{
    class Program
    {
        const string SER_PATH = @"../../../FirstTask/bin/Debug/boxes.json";
        static void Main()
        {
            do
            {
                try
                {
                    Collection<Box> boxes = BoxesDeserialization();
                    foreach (Box box in boxes)
                    {
                        Console.WriteLine(box.ToString());
                    }
                    Console.WriteLine();
                    Console.WriteLine();

                    var maxObjects = boxes.Where(x => x.GetLongestSideSize() > 3).
                        OrderByDescending(x => x.GetLongestSideSize());
                    foreach (var box in maxObjects)
                    {
                        Console.WriteLine(box.ToString());
                    }
                    Console.WriteLine();
                    Console.WriteLine();

                    var hardCollection = from box in boxes
                                         group box by box.Weight;
                    foreach (var col in hardCollection)
                    {
                        foreach (var item in col)
                        {
                            Console.WriteLine(item.ToString());
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                    Console.WriteLine();

                    var maxMassBoxes = boxes.Where(x => x.Weight == boxes.Max(y => y.Weight)).
                        Select(x => x);
                    foreach (var box in maxMassBoxes)
                    {
                        Console.WriteLine(box.ToString());
                    }
                    Console.WriteLine(maxMassBoxes.Count());
                    Console.WriteLine();
                }
                catch (Exception)
                {
                    Console.WriteLine("Sth wring with your filepath.");
                }
                Console.WriteLine("Введите ESC, чтобы завершить работу...");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        static Collection<Box> BoxesDeserialization()
        {
            Collection<Box> boxes;
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Collection<Box>));
            using (FileStream fs = new FileStream(SER_PATH, FileMode.Open))
            {
                boxes = (Collection<Box>)ser.ReadObject(fs);
            }
            return boxes;
        }
    }
}
