using System;
using System.Collections.Generic;

namespace RabbitsAndWolves
{
    class Animal
    {
        protected int satiety;
        private int maxSatiety;
        protected int lifeTime;
        protected int maxLifeTime;
        protected Grid grid;
        protected int x;
        protected int y;
        protected int satietyForBreeding;
        public bool isLife = true;

        public Animal(int maxSatiety, int maxLifeTime, Grid grid, int x, int y, int satietyForBreeding)
        {
            this.maxSatiety = maxSatiety;
            satiety = maxSatiety;
            this.maxLifeTime = maxLifeTime;
            lifeTime = maxLifeTime;
            this.grid = grid;
            this.x = x;
            this.y = y;
            this.satietyForBreeding = satietyForBreeding;
        }

        public bool CanLive()
        {
            if (satiety == 0 || lifeTime == 0 || !isLife)
            {
                isLife = false;
                return false;
            }
            return true;
        }

        public void Dead()
        {
            isLife = false;
            grid.Animals[x, y] = (int)CellType.Empty;
        }

        public virtual void Move()
        {
            satiety--;
            lifeTime--;
        }

        protected virtual void Breeding()
        {

        }

        protected virtual void Eating()
        {
            satiety = maxSatiety;
        }

        public virtual string GetInformation()
        {
            return $"x: {x}   y: {y}\tСытость: {satiety}\tОсталось жить: {lifeTime}\n";
        }
    }
}
