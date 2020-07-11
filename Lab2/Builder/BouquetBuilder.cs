using System;

namespace Lab2.Builder
{
    enum Shape { Round, Triangular, Cascade };
    abstract class BouquetBuilder
    {
        protected Bouquet Bouquet;

        protected BouquetBuilder()
        {
            Bouquet = new Bouquet();
        }

        public abstract void AddRose();
        public abstract void AddAster();
        public abstract void AddHerbera();
        public abstract void AddGladiolus();
        public abstract void AddDaisy();
        public abstract Bouquet GetBouquet();
    }
}
