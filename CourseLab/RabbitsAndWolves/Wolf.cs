using System;
using System.Collections.Generic;

namespace RabbitsAndWolves
{
    class Wolf : Animal
    {
        public Wolf(int maxSatiety, int maxLifeTime, Grid grid, Point point, int satietyForBreeding) :
            base(maxSatiety, maxLifeTime, grid, point, satietyForBreeding)
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

        }


        public override string GetInformation()
        {
            return $"Волк   " + base.GetInformation();
        }
    }
}
