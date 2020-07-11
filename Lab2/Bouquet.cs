using System;
using System.Collections.Generic;
using Lab2.Flowers;
using Lab2.Builder;

namespace Lab2
{

    class Bouquet
    {
        public virtual string Name { get; set; }
        public virtual List<Flower> Flowers { get; set; }
        public virtual Shape Shape { get; set; }
        public virtual int NumberOfFlowers
        {
            get
            {
                return Flowers.Count;
            }
        }

        public virtual int Price { get; internal set; }

        public Bouquet()
        {
            Flowers = new List<Flower>();
            Price = 0;
            Shape = default;
            Name = null;
        }

        protected Bouquet(Bouquet bouquet)
        {
        }

        public void Add(Flower flower)
        {
            Flowers.Add(flower);
            Price += flower.Price;
        }

        public virtual void GetInfo()
        {
            Console.WriteLine($" Name: {Name}");
            Console.WriteLine($" Shape: {Shape}");
            Console.WriteLine($" Number of flowers: {NumberOfFlowers}");
            Console.WriteLine($" Price: {Price}");
        }

    }
}
