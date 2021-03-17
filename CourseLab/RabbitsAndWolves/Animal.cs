using System;
using System.Collections.Generic;

namespace RabbitsAndWolves
{
    class Animal
    {
        protected Point thisPoint;
        protected int satiety;
        private int maxSatiety;
        protected int lifeTime;
        protected int maxLifeTime;
        protected Grid grid;
        protected int satietyForBreeding;
        public bool isLife = true;


        public Animal(int maxSatiety, int maxLifeTime, Grid grid, Point point, int satietyForBreeding)
        {
            this.maxSatiety = maxSatiety;
            satiety = maxSatiety;
            this.maxLifeTime = maxLifeTime;
            lifeTime = maxLifeTime;
            this.grid = grid;
            thisPoint = point;
            this.satietyForBreeding = satietyForBreeding;
        }

        public bool CanLive()
        {
            if (satiety == 0 || lifeTime == 0 || !isLife)
            {
                Dead();
                return false;
            }
            return true;
        }

        public void Dead()
        {
            isLife = false;
            thisPoint.FreeAnimals();
        }

        public virtual void Move()
        {
            satiety--;
            lifeTime--;
        }

        protected virtual void Breeding()
        {

        }

        public bool ReadyBreed()
        {
            if (satiety >= satietyForBreeding) { return true; }
            return false;
        }

        protected virtual void Eating()
        {
            satiety = maxSatiety;
        }

        public virtual string GetInformation()
        {
            return $"x: {thisPoint.X}   y: {thisPoint.Y}\tСытость: {satiety}\tОсталось жить: {lifeTime}\n";
        }
    }
}
