using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public static class Sorter
    {
        public static void LenghtSort(string[] lines)
        {
            string temp;
            for (int i = 0; i < lines.Length - 1; i++)
            {
                for (int j = i + 1; j < lines.Length; j++)
                {
                    if (lines[i].Length > lines[j].Length)
                    {
                        temp = lines[i];
                        lines[i] = lines[j];
                        lines[j] = temp;
                    }
                }
            }
        }
    }
}
