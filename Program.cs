using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = "homersekletek.txt";
        List<int> temperatures = new List<int>();

        try
        {
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                if (int.TryParse(line.Trim(), out int temp))
                {
                    temperatures.Add(temp);
                }
            }

            Console.WriteLine("===hőmérséklet statisztika===");
            Console.WriteLine($"beolvasott napok száma: {temperatures.Count} nap");

            if (temperatures.Count > 0)
            {
                double sum = 0;
                foreach (int temp in temperatures)
                {
                    sum += temp;
                }
                double average = sum / temperatures.Count;
                Console.WriteLine($"kéthetes átlaghőmérséklet: {average:F2} °C");

                int maxTemp = temperatures[0];
                foreach (int temp in temperatures)
                {
                    if (temp > maxTemp)
                    {
                        maxTemp = temp;
                    }
                }
                Console.WriteLine($"legmagasabb hőmérséklet: {maxTemp} °C");

                int warmDays = 0;
                foreach (int temp in temperatures)
                {
                    if (temp >= 25)
                    {
                        warmDays++;
                    }
                }
                Console.WriteLine($"meleg napok száma (25°C felett): {warmDays} nap");
            }
            else
            {
                Console.WriteLine("Nem sikerült adatokat beolvasni a fájlból!");
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Hiba: A 'homersekletek.txt' fájl nem található!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Hiba történt: {ex.Message}");
        }

        Console.WriteLine("\n nyomj meg egy gombot a kilépéshez...");
        Console.ReadKey();
    }
}