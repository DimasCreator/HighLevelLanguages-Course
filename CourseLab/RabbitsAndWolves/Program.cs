using System;

namespace RabbitsAndWolves
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = GetIntData("Введите размер квадратного поля");
            int sheepCount = GetIntData("Введите количество кроликов");
            int wolfCount = GetIntData("Введите количество волков");
            int grassCoveragePercent = GetIntData("Введите процент травы");
            int maxSatiety = GetIntData("Введите максимальную сытость");
            int maxLifeTime = GetIntData("Введите максимальное время жизни");
            int satietyForBreeding = GetIntData("Введите необходимое количество сытости для размножения");
            Grid lifeGrid = new Grid(size, sheepCount, wolfCount, grassCoveragePercent, maxSatiety, maxLifeTime, satietyForBreeding);
            lifeGrid.Life();
        }

        static int GetIntData(string message)
        {
            Console.WriteLine(message);
            int num;
            string input = Console.ReadLine();
            while(!int.TryParse(input, out num))
            {
                Console.Clear();
                Console.WriteLine("Некорректный ввод");
                Console.WriteLine(message);
                input = Console.ReadLine();
            }
            Console.Clear();
            return num;
        }
    }
}
