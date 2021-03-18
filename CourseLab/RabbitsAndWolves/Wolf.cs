using System;
using System.Collections.Generic;

namespace RabbitsAndWolves
{
    class Wolf : Animal
    {
        public Wolf(int satiety, int maxSatiety, int maxLifeTime, Grid grid, Point point, int satietyForBreeding) :
            base(satiety, maxSatiety, maxLifeTime, grid, point, satietyForBreeding)
        {
            thisPoint.SetWolf(this);
        }

        public override void Move()
        {
            if (isLife)
            {
                base.Move();
                List<Point> movementsEatsRabbit = Searcher.GetRabbitPoints(thisPoint);
                if (movementsEatsRabbit.Count != 0)
                {
                    Point newPoint = movementsEatsRabbit[grid.random.Next(0, movementsEatsRabbit.Count)];
                    thisPoint.FreeAnimals();
                    thisPoint = grid.points[newPoint.X, newPoint.Y];
                    Eating();
                    thisPoint.SetWolf(this);
                }
                else
                {
                    List<Point> movements = Searcher.GetFreePointsOne(thisPoint);
                    if (movements.Count != 0)
                    {
                        Point newPoint = movements[grid.random.Next(0, movements.Count)];
                        thisPoint.FreeAnimals();
                        thisPoint = grid.points[newPoint.X, newPoint.Y];
                        thisPoint.SetWolf(this);
                    }
                }
                Breeding();
            }
        }

        protected override void Eating()
        {
            if (thisPoint.IsRabbit)
            {
                base.Eating();
                thisPoint.EatRabbit();
            }
        }

        protected override void Breeding()
        {
            List<Point> pointsList = Searcher.GetReadyBreedWolvesPoint(thisPoint);
            if (pointsList.Count != 0)
            {
                isReadyBreed = false;
                satiety = satietyForBreeding - 2;
                Point targetPoint = pointsList[grid.random.Next(0, pointsList.Count)];
                targetPoint.GetWolf().Breed();
            }
        }

        public void Breed()
        {
            List<Point> pointsList = Searcher.GetFreePointsOne(thisPoint);
            if (pointsList.Count != 0)
            {
                isReadyBreed = false;
                satiety = satietyForBreeding - 2;
                grid.AddAnimal(new Wolf(satietyForBreeding - 1, maxSatiety, maxLifeTime, grid, pointsList[grid.random.Next(0, pointsList.Count)], satietyForBreeding));
            }
        }


        public override string GetInformation()
        {
            return $"Волк   " + base.GetInformation();
        }
    }
}
