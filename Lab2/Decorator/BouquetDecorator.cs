using System;
using System.Collections.Generic;
using System.Text;
using Lab2.Flowers;
using Lab2.Builder;

namespace Lab2
{
    abstract class BouquetDecorator : Bouquet
    {
        public override List<Flower> Flowers
        {
            get
            {
                return bouquet.Flowers;
            }
            set
            {
                bouquet.Flowers = value;
            }

        }
        public override Shape Shape
        {
            get
            {
                return bouquet.Shape;
            }
            set
            {
                bouquet.Shape = value;
            }
        }
        public override int NumberOfFlowers
        {
            get
            {
                return bouquet.Flowers.Count;
            }
        }
        public override int Price
        {
            get
            {
                return bouquet.Price;
            }
            internal set
            {
                bouquet.Price = value;
            }
        }

        public override string Name
        {
            get
            {
                return bouquet.Name;
            }
            set
            {
                bouquet.Name = value;
            }
        }

        protected Bouquet bouquet;
        public BouquetWrapper Wrapper;
        public Postcard Postcard;

        public BouquetDecorator(Bouquet bouquet) : base(bouquet)
        {
            Wrapper = null;
            Postcard = null;
            this.bouquet = bouquet;
        }

        public override void GetInfo()
        {
            bouquet.GetInfo();
            if (Wrapper != null) Console.Write($" Wrapper: {Wrapper.Name}");
            if (Postcard != null) Console.Write($" Postcard text: {Postcard.Text}");
            Console.WriteLine();
        }

    }
}
