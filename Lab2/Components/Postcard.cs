using System;

namespace Lab2
{
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
}
