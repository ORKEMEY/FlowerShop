using System;
using Lab2.Flowers;

namespace Lab2.Builder
{
    class TriangularBouquetBuilder : BouquetBuilder
    {

        public TriangularBouquetBuilder() : base()
        {
            this.Bouquet.Shape = Shape.Triangular;
        }

        public override void AddRose()
        {
            Bouquet.Add(new Rose());
        }
        public override void AddAster()
        {
            Bouquet.Add(new Aster());
        }
        public override void AddHerbera()
        {
            Bouquet.Add(new Herbera());
        }
        public override void AddGladiolus()
        {
            Bouquet.Add(new Gladiolus());
        }
        public override void AddDaisy()
        {
            Bouquet.Add(new Daisy());
        }
        public override Bouquet GetBouquet()
        {
            return Bouquet;
        }
    }
}
