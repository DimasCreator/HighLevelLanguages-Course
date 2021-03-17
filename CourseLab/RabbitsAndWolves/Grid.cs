using System;
using System.Collections.Generic;

namespace RabbitsAndWolves
{
    class Grid
    {
        public int[,] Grow { get; set; }
        public int[,] Animals { get; set; }

        List<Animal> animalList;
        int shareOfGrass;
        public int size;
        public int grassCount;
        public Random random;

        public Grid(int size, int sheepCount, int grassCoveragePercent, int maxSatiety, int maxLifeTime, int satietyForBreeding)
        {
            random = new Random();
            Grow = new int[size, size];
            Animals = new int[size, size];
            shareOfGrass = size * size * grassCoveragePercent / 100;
            grassCount = 0;
            this.size = size;
            Planting();
            int x = 0;
            int y = 0;
            animalList = new List<Animal>();
            for (int i = 0; i < sheepCount; i++)
            {
                do
                {
                    x = random.Next(0, size);
                    y = random.Next(0, size);
                } while ((CellType)Animals[x, y] == CellType.Sheep);
                animalList.Add(new Rabbit(maxSatiety, maxLifeTime, this, x, y, satietyForBreeding));
            }
        }

        public void Life()
        {
            Print();
            Console.ReadKey();
            while (true)
            {
                Print();
                foreach (var animal in animalList)
                {
                    animal.Move();
                }
                for (int i = 0; i < animalList.Count;)
                {
                    if (animalList[i].CanLive())
                    {
                        i++;
                        continue;
                    }
                    else
                    {
                        animalList[i].Dead();
                        animalList.RemoveAt(i);
                    }
                }
                Planting();
                Shaffle();
                Console.ReadKey();
            }
        }

        private void Shaffle()
        {
            if (animalList.Count != 0)
            {
                int animalA = 0;
                int animalB = 0;
                Animal tmp;
                for (int i = 0; i < 20; i++)
                {
                    animalA = random.Next(0, animalList.Count);
                    animalB = random.Next(0, animalList.Count);
                    tmp = animalList[animalA];
                    animalList[animalA] = animalList[animalB];
                    animalList[animalB] = tmp;
                }
            }
        }

        private void Print()
        {
            Console.Clear();
            string symbol;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    symbol = "   ";
                    if ((CellType)Grow[i, j] == CellType.Grass)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                    }
                    if ((CellType)Animals[i, j] == CellType.Sheep)
                    {
                        symbol = " O ";
                    }
                    else if ((CellType)Animals[i, j] == CellType.Wolf)
                    {
                        symbol = " @ ";
                    }
                    Console.Write(symbol);
                }
                Console.WriteLine();
            }
            Console.BackgroundColor = ConsoleColor.Black;
            foreach (var animal in animalList)
            {
                Console.Write(animal.GetInformation());
            }
        }

        private void Planting()
        {
            int x;
            int y;
            for (; grassCount < shareOfGrass; grassCount++)
            {
                do
                {
                    x = random.Next(0, size);
                    y = random.Next(0, size);
                } while ((CellType)Grow[x, y] == CellType.Grass);
                Grow[x, y] = 1;
            }
        }
    }

    public enum CellType
    {
        Empty = 0,
        Grass = 1,
        Sheep = 1,
        Wolf = 2
    }
}
