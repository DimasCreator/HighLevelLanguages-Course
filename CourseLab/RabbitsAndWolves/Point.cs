using System;

namespace RabbitsAndWolves
{
    class Point
    {
        public bool IsRabbit { get; private set; }
        public bool IsWolf { get; private set; }
        public bool IsGrass { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }
        Animal animal;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
            IsGrass = false;
            IsRabbit = false;
            IsWolf = false;
        }

        public Wolf GetWolf()
        {
            if (IsWolf) { return (Wolf)animal; }
            else { return null; }
        }

        public Rabbit GetRabbit()
        {
            if (IsRabbit) { return (Rabbit)animal; }
            else { return null; }
        }

        public void SetRabbit(Rabbit rabbit)
        {
            if (!IsRabbit && !IsWolf)
            {
                animal = rabbit;
                IsRabbit = true;
            }
        }

        public void SetWolf(Wolf wolf)
        {
            if (!IsRabbit && !IsWolf)
            {
                animal = wolf;
                IsWolf = true;
            }
        }

        public void FreeAnimals()
        {
            IsRabbit = false;
            IsWolf = false;
            animal = null;
        }

        public bool ReadyBreed()
        {
            return animal.ReadyBreed();
        }

        public void PlantGrass()
        {
            if (IsGrass) { throw new Exception("Тут уже есть трава"); }
            else { IsGrass = true; }
        }

        public void EatGrass()
        {
            if (IsGrass) { IsGrass = false; }
            else { throw new Exception("Здесь нет травы"); }
        }
    }
}
