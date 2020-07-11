using System;

namespace Lab2
{
    enum Wrapper { Tape, Paper, Organza };

    class BouquetWrapper : Component
    {
        public override string Name
        {
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
}
