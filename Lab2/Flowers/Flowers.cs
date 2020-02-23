using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2.Flowers
{
    abstract class Flower
    {
        public string Name { get; protected set; }
		public int Price;
    }

    class Rose : Flower
    {
        public Rose()
        {
            Name = "Rose";
			Price = 5;
        }
    }

    class Aster : Flower
    {
        public Aster()
        {
            Name = "Aster";
			Price = 4;
		}
    }

    class Herbera : Flower
    {
        public Herbera()
        {
            Name = "Herbera";
			Price = 6;
		}
    }

    class Gladiolus : Flower
    {
        public Gladiolus()
        {
			Name = "Gladiolus";
			Price = 7;
		}
    }

    class Daisy : Flower
    {
        public Daisy()
        {
            Name = "Daisy";
			Price = 2;
		}
    }
}
