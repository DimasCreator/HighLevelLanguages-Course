using System;
using System.Collections.Generic;

namespace RabbitsAndWolves
{
    class Rabbit : Animal
    {
        public Rabbit(int maxSatiety, int maxLifeTime, Grid grid, Point point, int satietyForBreeding) :
            base(maxSatiety, maxLifeTime, grid, point, satietyForBreeding)
        {
            thisPoint.SetRabbit(this);
        }

        public override void Move()
        {
            if (isLife)
            {
                base.Move();
                List<Point> movementsGrass = Searcher.GetGrassPoints(thisPoint);
                if (movementsGrass.Count != 0)
                {
                    Point newPoint = movementsGrass[grid.random.Next(0, movementsGrass.Count)];
                    thisPoint.FreeAnimals();
                    thisPoint = grid.points[newPoint.X, newPoint.Y];
                    thisPoint.SetRabbit(this);
                }
                else
                {
                    List<Point> movements = Searcher.GetFreePoints(thisPoint);
                    if (movements.Count != 0)
                    {
                        Point newPoint = movements[grid.random.Next(0, movements.Count)];
                        thisPoint.FreeAnimals();
                        thisPoint = grid.points[newPoint.X, newPoint.Y];
                        thisPoint.SetRabbit(this);
                    }
                }
                Eating();
                Breeding();
            }
        }

        protected override void Eating() 
        {
            if (thisPoint.IsGrass)
            {
                grid.grassCount--;
                base.Eating();
                thisPoint.EatGrass();
            }
        }

        protected override void Breeding()
        {
            List<Point> pointsList = Searcher.GetReadyBreedRabbitsPoint(thisPoint);
            if (pointsList.Count != 0)
            {
                Point targetPoint = pointsList[grid.random.Next(0, pointsList.Count)];
            }
        }

        public override string GetInformation()
        {
            return $"Кролик " + base.GetInformation();
        }
    }
}
