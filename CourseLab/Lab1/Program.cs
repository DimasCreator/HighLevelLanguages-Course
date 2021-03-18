using System;
using System.Collections.Generic;
using System.IO;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO: обработка TextLabaLHL
            string[] lines = File.ReadAllLines("random.txt");
            Sorter.LenghtSort(lines);
            Array.Sort(lines);
            Sub(lines);
            SubVariant2(lines);
        }

        public static void Sub(string[] str)
        {
            Sorter.LenghtSort(str);
            var watch = System.Diagnostics.Stopwatch.StartNew();
            watch.Start();

            //находим первоначальную размерность списка подстрок(максимум возможных подстрок)
            int subCount = 0;
            for (int i = str[0].Length; i >= 0; i--)
            {
                subCount += i;
            }
            //заполняем список, который поддерживает уникальность
            HashSet<string> subStrings = new HashSet<string>(subCount);
            for (int i = 1; i <= str[0].Length; i++)
            {
                for (int j = 0; j <= str[0].Length - i; j++)
                {
                    subStrings.Add(str[0].Substring(j, i));
                }
            }
            //проверяем на вхождение подстрок
            List<string> commonSubstrings = new List<string>();
            foreach (var sub in subStrings)
            {
                bool flag = true;
                for (int i = 1; i < str.Length; i++)
                {
                    if (str[i].Contains(sub))
                    {
                        continue;
                    }
                    flag = false;
                    break;
                }
                if (flag)
                {
                    commonSubstrings.Add(sub);
                }
            }
            watch.Stop();
            Console.WriteLine("\n");
            Console.WriteLine(watch.ElapsedMilliseconds + "\tмс");
            //вывод
            Console.WriteLine("\n\nОбщие подстроки\n\n");
            foreach (var i in commonSubstrings)
            {
                Console.WriteLine(i);
            }
        }

        public static void SubVariant2(string[] str)
        {
            Sorter.LenghtSort(str);
            var watch = System.Diagnostics.Stopwatch.StartNew();
            watch.Start();

            //находим размерность массива подстрок
            int subCount = 0;
            for (int i = str[0].Length; i >= 0; i--)
            {
                subCount += i;
            }
            string[] subStrings = new string[subCount];

            //заполняем массив подстрок
            int count = 0;
            for (int i = 1; i <= str[0].Length; i++)
            {
                for (int j = 0; j <= str[0].Length - i; j++)
                {
                    subStrings[count] = str[0].Substring(j, i);
                    count++;
                }
            }
            //проверяем на вхождение подстрок
            List<string> commonSubstrings = new List<string>();
            for (int j = 0; j < count; j++)
            {
                bool flag = true;
                for (int i = 0; i < commonSubstrings.Count; i++)
                {
                    if (subStrings[j] == commonSubstrings[i])
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    for (int i = 1; i < str.Length; i++)
                    {
                        if (str[i].Contains(subStrings[j]))
                        {
                            continue;
                        }
                        flag = false;
                        break;
                    }
                    if (flag)
                    {
                        commonSubstrings.Add(subStrings[j]);
                    }
                }
            }
            watch.Stop();
            Console.WriteLine("\n");
            Console.WriteLine(watch.ElapsedMilliseconds + "\tмс");
            //вывод
            Console.WriteLine("\n\nОбщие подстроки\n\n");
            foreach (var i in commonSubstrings)
            {
                Console.WriteLine(i);
            }
        }
    }
}
