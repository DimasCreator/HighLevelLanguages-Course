using System;
using System.Collections.Generic;

namespace RabbitsAndWolves
{
    class Program
    {
        static void Main(string[] args)
        {
            //int size = GetData("Введите размер квадратного поля");
            //int sheepCount = GetData("Введите количество овец");
            //int wolfCount = GetData("Введите количество волков");
            //int grassCoveragePercent = GetData("Введите процент травы");
            //int maxSatiety = GetData("Введите максимальную сытость");
            //int maxLifeTime = GetData("Введите максимальное время жизни");
            //int satietyForBreeding = GetData("Введите необходимое количество сытости для размножения");
            //Grid lifeGrid = new Grid(size, sheepCount, wolfCount, grassCoveragePercent, maxSatiety, maxLifeTime, satietyForBreeding);
            Grid lifeGrid = new Grid(10, 20, 10, 30, 1000, 1000, 7);
            lifeGrid.Life();
        }

        static int GetData(string message)
        {
            Console.WriteLine(message);
            return Convert.ToInt32(Console.ReadLine());
        }
    }
}
