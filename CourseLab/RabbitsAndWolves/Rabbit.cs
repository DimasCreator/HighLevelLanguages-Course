using System;
using System.Collections.Generic;

namespace RabbitsAndWolves
{
    class Rabbit : Animal
    {
        public Rabbit(int maxSatiety, int maxLifeTime, Grid grid, int x, int y, int satietyForBreeding) :
            base(maxSatiety, maxLifeTime, grid, x, y, satietyForBreeding)
        {
            grid.Animals[x, y] = (int)CellType.Sheep;
        }

        public override void Move()
        {
            if (isLife)
            {
                base.Move();
                List<Point> movements = GetPoints();
                Point newPoint = movements[grid.random.Next(0, movements.Count)];
                grid.Animals[x, y] = (int)CellType.Empty;
                x = newPoint.x;
                y = newPoint.y;
                grid.Animals[x, y] = (int)CellType.Sheep;

                Eating();
                Breeding();
            }
        }

        protected override void Eating()
        {
            if ((CellType)grid.Grow[x, y] == CellType.Grass)
            {
                grid.grassCount--;
                grid.Grow[x, y] = (int)CellType.Empty;
                base.Eating();
            }
        }

        protected override void Breeding()
        {

        }

        public override string GetInformation()
        {
            return $"Овца " + base.GetInformation();
        }

        //TODO: Сделать поиск клеток, куда можно сходить
        private List<Point> GetPoints()
        {
            List<Point> pointList = new List<Point>();
            int newX;
            int newY;
            for (int y = 0; y <= 2; y++)
            {
                for (int x = y - 2; x <= 2 - y; x++)
                {
                    newX = this.x + x;
                    newY = this.y + y;
                    if (newX < 0 || newX >= grid.size || newY < 0 || newY >= grid.size) { continue; }//проверка на нахождение точки в области поля
                    if (grid.Animals[newX, newY] == (int)CellType.Sheep || grid.Animals[newX, newY] == (int)CellType.Wolf) { continue; }//проверка на отсутствие других ивотных на поле
                    pointList.Add(new Point(newX, newY));
                }
            }
            for (int y = -1; y >= -2; y--)
            {
                for (int x = -2 - y; x <= y + 2; x++)
                {
                    newX = this.x + x;
                    newY = this.y + y;
                    if (newX < 0 || newX >= grid.size || newY < 0 || newY >= grid.size) { continue; }//проверка на нахождение точки в области поля
                    if (grid.Animals[newX, newY] == (int)CellType.Sheep || grid.Animals[newX, newY] == (int)CellType.Wolf) { continue; }//проверка на отсутствие других ивотных на поле
                    pointList.Add(new Point(newX, newY));
                }
            }
            return pointList;
        }
        private List<Point> GetGrassPoint()
        {
            List<Point> pointList = new List<Point>();
            return pointList;
        }
    }
}
