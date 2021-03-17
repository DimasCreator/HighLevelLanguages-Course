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

        public override string GetInformation()
        {
            return $"Волк" + base.GetInformation();
        }
    }
}
