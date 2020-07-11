using System;
using Lab2.Builder;

namespace Lab2
{
    class FlowerShop
    {
        private BouquetBuilder Builder;

        private static FlowerShop Source;

        public static FlowerShop GetSource()
        {
            if (Source == null)
                Source = new FlowerShop();
            return Source;
        }

        private FlowerShop()
        {
            this.Builder = null;
        }

        public void SetBuilder(BouquetBuilder builder)
        {
            this.Builder = builder;
        }

        public Bouquet ConstructWeddingBouquet()
        {
            if (Builder == null)
            {
                Console.WriteLine(" < Choose bouquete shape > ");
                return null;
            }

            for (int count = 0; count < 8; count++) Builder.AddRose();
            for (int count = 0; count < 8; count++) Builder.AddHerbera();
            for (int count = 0; count < 5; count++) Builder.AddGladiolus();
            Builder.GetBouquet().Name = " Wedding bouquet ";
            return Builder.GetBouquet();
        }

        public Bouquet ConstructАnniversaryBouquet()
        {
            if (Builder == null)
            {
                Console.WriteLine(" < Choose bouquete shape > ");
                return null;
            }

            for (int count = 0; count < 5; count++) Builder.AddAster();
            for (int count = 0; count < 5; count++) Builder.AddDaisy();
            for (int count = 0; count < 5; count++) Builder.AddHerbera();
            Builder.GetBouquet().Name = " Аnniversary bouquet ";
            return Builder.GetBouquet();
        }

        protected void OutputCustomMenu()
        {
            Console.WriteLine(" < Menu > ");

            Console.WriteLine(" < Enter \"o\" to output menu > ");
            Console.WriteLine(" < Enter \"r\" to add rose to bouquet > ");
            Console.WriteLine(" < Enter \"a\" to add aster to bouquet > ");
            Console.WriteLine(" < Enter \"h\" to add herbera to bouquet > ");
            Console.WriteLine(" < Enter \"g\" to add gladiolus to bouquet > ");
            Console.WriteLine(" < Enter \"d\" to add daisy to bouquet > ");
            Console.WriteLine(" < Enter \"q\" to quit > ");
            Console.WriteLine();
        }

        public Bouquet ConstructCustomBouquet()
        {
            if (Builder == null)
            {
                Console.WriteLine(" < Choose bouquete shape > ");
                return null;
            }

            Console.Clear();
            OutputCustomMenu();

            char mode = ' ';

            do
            {
                mode = Program.EnterMode();
                switch (mode)
                {

                    case 'o':
                        OutputCustomMenu();
                        break;
                    case 'r':
                        Builder.AddRose();
                        break;
                    case 'a':
                        Builder.AddAster();
                        break;
                    case 'h':
                        Builder.AddHerbera();
                        break;
                    case 'g':
                        Builder.AddGladiolus();
                        break;
                    case 'd':
                        Builder.AddDaisy();
                        break;

                    case 'q':
                        break;

                    default:
                        Console.WriteLine(" < Wrong mode > ");
                        break;
                }

            } while (mode != 'q');
            
            Builder.GetBouquet().Name = " Custom bouquet ";
            return Builder.GetBouquet();
        }

        protected void OutputMenu()
        {
        Console.WriteLine(" < Menu > ");

        Console.WriteLine(" < Enter \"o\" to output menu > ");
        Console.WriteLine(" < Enter \"w\" to construct wedding bouquet > ");
        Console.WriteLine(" < Enter \"a\" to construct anniversary bouquet > ");
        Console.WriteLine(" < Enter \"c\" to construct custom bouquet > ");
        Console.WriteLine(" < Enter \"q\" to quit > ");
        Console.WriteLine();
        }

        public Bouquet Menu()
        {
            Console.Clear();
            OutputMenu();
            Bouquet newBouquet = null;

            char mode = ' ';
            do
            {
                mode = Program.EnterMode();
                switch (mode)
                {

                    case 'o':
                        OutputMenu();
                        break;

                    case 'w':
                        newBouquet = Source.ConstructWeddingBouquet();
                        break;

                    case 'a':
                        newBouquet = Source.ConstructАnniversaryBouquet();
                        break;

                    case 'c':
                        newBouquet = Source.ConstructCustomBouquet();
                        break;
                    case 'q':
                        break;

                    default:
                        Console.WriteLine(" < Wrong mode > ");
                        break;
                }

            } while (mode != 'q' && newBouquet == null);
            Console.Clear();
            return newBouquet;
    }
    }
}
