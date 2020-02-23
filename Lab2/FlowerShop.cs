using System;
using System.Collections.Generic;
using System.Text;
using Lab2.Flowers;

namespace Lab2
{

    abstract class Component
    {
        public abstract string Name { get; protected set; }
    }

    enum Shape { Round, Triangular, Cascade };
    enum Wrapper { Tape, Paper, Organza };

    class Postcard : Component
    {
        public override string Name { get; protected set; }

        public string Text;
        public Postcard()
        {
            Name = "Postcard";
            Text = null;
        }

        public void SignPostcard()
        {
            Console.Write(" < Sign postcard > \n>");
            Text = Console.ReadLine();
            Console.WriteLine();
        }
    }

    class BouquetWrapper : Component
    {
        public override string Name {
            get
            {
                switch (Wrapper)
                {
                    case Lab2.Wrapper.Tape:
                        return "Tape";
                    case Lab2.Wrapper.Paper:
                        return "Paper";
                    case Lab2.Wrapper.Organza:
                        return "Organza";
                    default:
                        return null;
                }
            }
            protected set
            {
            }
        }

        public Wrapper Wrapper;
        public BouquetWrapper()
        {
            Wrapper = default;
        }

        protected void OutputMenu()
        {
            Console.WriteLine(" < Menu > ");

            Console.WriteLine(" < Enter \"o\" to output menu > ");
            Console.WriteLine(" < Enter \"t\" to wrapp bouquet with tape > ");
            Console.WriteLine(" < Enter \"p\" to wrapp bouquet with paper > ");
            Console.WriteLine(" < Enter \"g\" to wrapp bouquet with organza > ");
            Console.WriteLine(" < Enter \"q\" to quit > ");
            Console.WriteLine();
        }

        public void ChooseWrapper()
        {
            Console.Clear();
            OutputMenu();
         
            char mode = ' ';

            do
            {
                mode = Program.EnterMode();
                switch (mode)
                {

                    case 'o':
                        OutputMenu();
                        break;

                    case 't':
                        Wrapper = Lab2.Wrapper.Tape;
                        Console.Clear();
                        return;
                       
                    case 'p':
                        Wrapper = Lab2.Wrapper.Paper;
                        Console.Clear();
                        return;

                    case 'g':
                        Wrapper = Lab2.Wrapper.Organza;
                        Console.Clear();
                        return;

                    case 'q':
                        break;

                    default:
                        Console.WriteLine(" < Wrong mode > ");
                        break;
                }

            } while (mode != 'q');

            Console.Clear();
        }

    }

    abstract class BouquetDecorator : Bouquet
    {
        public override List<Flower> Flowers {
            get
            {
                return bouquet.Flowers;
            }
            set
            {
                bouquet.Flowers = value;
            }

        }
        public override Shape Shape {
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
        public override int Price {
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
            if(Wrapper != null) Console.Write($" Wrapper: {Wrapper.Name}");
            if (Postcard != null) Console.Write($" Postcard text: {Postcard.Text}");
            Console.WriteLine();
        }

    }

    class WrappedBouquet : BouquetDecorator
    {
        public WrappedBouquet(Bouquet bouquet, BouquetWrapper wrapper) : base(bouquet)
        {
            mainConstructor(wrapper);
        }

        public WrappedBouquet(SignedBouquet bouquet, BouquetWrapper wrapper) : base(bouquet)
        {
            Postcard = bouquet.Postcard;
            mainConstructor(wrapper);
        }
        private void mainConstructor(BouquetWrapper wrapper)
        {
            this.Wrapper = wrapper;

            if (!Name.Contains("Wrapped"))
            {
                Name = Name.ToLower();
                Name = Name.Insert(0, "Wrapped");
            }
            switch (wrapper.Wrapper)
            {
                case Lab2.Wrapper.Organza:
                    Price += 10;
                    break;
                case Lab2.Wrapper.Paper:
                    Price += 5;
                    break;
                case Lab2.Wrapper.Tape:
                    Price += 3;
                    break;
            }
        }
    }

    class SignedBouquet : BouquetDecorator
    {
        public SignedBouquet(Bouquet bouquet, Postcard postcard) : base(bouquet)
        {
            mainConstructor(postcard);
        }

        public SignedBouquet(WrappedBouquet bouquet, Postcard postcard) : base(bouquet)
        {
            Wrapper = bouquet.Wrapper;
            mainConstructor(postcard);
        }

        private void mainConstructor(Postcard postcard)
        {
            this.Postcard = postcard;
            if (!Name.Contains("with postcard"))
            {
                Name = Name.Insert(Name.Length - 1, " with postcard ");
            }
            Price += 10;
        }

    }

    //==============================================================================

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

    class FlowerShop
    {
        BouquetBuilder Builder;

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

    abstract class BouquetBuilder
    {
        public abstract void AddRose();
        public abstract void AddAster();
        public abstract void AddHerbera();
        public abstract void AddGladiolus();
        public abstract void AddDaisy();
        public abstract Bouquet GetBouquet();
    }

    class CascadeBouquetBuilder : BouquetBuilder
    {
        private Bouquet Bouquet = new Bouquet();

        public CascadeBouquetBuilder()
        {
            this.Bouquet.Shape = Shape.Cascade;
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

    class RoundBouquetBuilder : BouquetBuilder
    {
        private Bouquet Bouquet = new Bouquet();

        public RoundBouquetBuilder()
        {
            this.Bouquet.Shape = Shape.Round;
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

    class TriangularBouquetBuilder : BouquetBuilder
    {
        private Bouquet Bouquet = new Bouquet();

        public TriangularBouquetBuilder()
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
