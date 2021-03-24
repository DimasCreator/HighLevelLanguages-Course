using System;
using System.Collections.Generic;
using System.Threading;

namespace RabbitsAndWolves
{
    class Grid
    {
        public Point[,] points { get; private set; }
        List<Animal> animalList;
        int shareOfGrass;
        public int size;
        public int grassCount;
        public Random random;
        int maxSatiety;
        int maxLifeTime;
        int satietyForBreeding;

        public Grid(int size, int sheepCount, int wolfCount, int grassCoveragePercent, int maxSatiety, int maxLifeTime, int satietyForBreeding)
        {
            this.maxLifeTime = maxLifeTime;
            this.maxSatiety = maxSatiety;
            this.satietyForBreeding = satietyForBreeding;
            this.size = size;
            int x = 0;
            int y = 0;
            points = new Point[size, size];
            for (x = 0; x < size; x++)
            {
                for (y = 0; y < size; y++)
                {
                    points[x, y] = new Point(x, y);
                }
            }
            Searcher.SetMap(points);
            random = new Random();
            shareOfGrass = size * size * grassCoveragePercent / 100;
            grassCount = 0;
            Planting();
            animalList = new List<Animal>(sheepCount + wolfCount);

            for (int i = 0; i < sheepCount; i++)
            {
                do
                {
                    x = random.Next(0, size);
                    y = random.Next(0, size);
                } while (points[x, y].IsRabbit || points[x, y].IsWolf);
                animalList.Add(new Rabbit(maxSatiety, maxSatiety, maxLifeTime, this, points[x, y], satietyForBreeding));
            }
            for (int i = 0; i < wolfCount; i++)
            {
                do
                {
                    x = random.Next(0, size);
                    y = random.Next(0, size);
                } while (points[x, y].IsRabbit || points[x, y].IsWolf);
                animalList.Add(new Wolf(maxSatiety, maxSatiety, maxLifeTime, this, points[x, y], satietyForBreeding));
            }
        }

        public void Life()
        {
            while (true)
            {
                Shaffle();
                Print();
                Console.ReadKey();
                for(int i = 0; i < animalList.Count; i++)
                {
                    animalList[i].Move();
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
                        animalList.RemoveAt(i);
                    }
                }
                Planting();
                Thread.Sleep(70);
                
            }
        }
        /// <summary>
        /// Добавляет в систему новое животное
        /// </summary>
        /// <param name="animal"></param>
        public void AddAnimal(Animal animal)
        {
            animalList.Add(animal);
        }

        /// <summary>
        /// Перемешивает массив животных
        /// </summary>
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

        /// <summary>
        /// Отображает поле на экране
        /// </summary>
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
                    if (points[i, j].IsGrass)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                    }
                    if (points[i, j].IsRabbit)
                    {
                        symbol = " V ";
                    }
                    else if (points[i, j].IsWolf)
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

        /// <summary>
        /// Засаживает поле недостающей травой
        /// </summary>
        private void Planting()
        {
            if (size * size < shareOfGrass) { shareOfGrass = size * size; }
            int x;
            int y;
            for (; grassCount < shareOfGrass; grassCount++)
            {
                do
                {
                    x = random.Next(0, size);
                    y = random.Next(0, size);
                } while (points[x, y].IsGrass);
                points[x, y].PlantGrass();
            }
        }
    }
}
