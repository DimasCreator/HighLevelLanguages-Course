using System;
using System.Collections.Generic;

namespace RabbitsAndWolves
{
    class Wolf : Animal
    {
        public Wolf(int maxSatiety, int maxLifeTime, Grid grid, int x, int y, int satietyForBreeding) :
            base(maxSatiety, maxLifeTime, grid, x, y, satietyForBreeding)
        {
            grid.Animals[x, y] = (int)CellType.Wolf;
        }

        public override void Move()
        {
            if (isLife)
            {
                base.Move();

                Eating();
                Breeding();
            }
        }

        protected override void Eating()
        {

            base.Eating();
        }

        protected override void Breeding()
        {
        }

        public override string GetInformation()
        {
            return $"Волк " + base.GetInformation();
        }
    }
}
