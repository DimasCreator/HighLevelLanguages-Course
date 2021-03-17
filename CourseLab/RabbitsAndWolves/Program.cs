using System;
using System.Collections.Generic;

namespace RabbitsAndWolves
{
    class Program
    {
        static void Main(string[] args)
        {

            int size = GetData("Введите размер квадратного поля");
            int sheepCount = GetData("Введите количество овец");
            int grassCoveragePercent = GetData("Введите процент травы");
            int maxSatiety = GetData("Введите максимальную сытость");
            int maxLifeTime = GetData("Введите максимальное время жизни");
            int satietyForBreeding = GetData("Введите необходимое количество сытости для размножения");
            Grid lifeGrid = new Grid(size, sheepCount, grassCoveragePercent, maxSatiety, maxLifeTime, satietyForBreeding);
            lifeGrid.Life();
        }

        static int GetData(string message)
        {
            Console.WriteLine(message);
            return Convert.ToInt32(Console.ReadLine());
        }
    }
}
