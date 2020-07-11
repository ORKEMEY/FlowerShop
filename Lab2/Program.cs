using System;
using Lab2.Builder;

namespace Lab2
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine(" < Poshukailo Artem, IS-82, Lab2, V-13 > ");

			Menu();
		}

		public static void MainMenu()
		{
			Console.WriteLine(" < Menu > ");
			Console.WriteLine(" < Enter \"o\" to output menu > ");
			Console.WriteLine(" < Enter \"c\" to create cascade bouquet > ");
			Console.WriteLine(" < Enter \"r\" to create round bouquet > ");
			Console.WriteLine(" < Enter \"t\" to create triangular bouquet > ");
			Console.WriteLine(" < Enter \"w\" to wrap bouquet > ");
			Console.WriteLine(" < Enter \"p\" to add a postcard to bouquet > ");
			Console.WriteLine(" < Enter \"i\" to get information about cuurent bouquet > ");
			Console.WriteLine(" < Enter \"q\" to quit > ");
			Console.WriteLine();
		}

		public static void Menu()
		{
			MainMenu();
			char mode = ' ';

			Bouquet currentBuquet = null;
			FlowerShop shop = FlowerShop.GetSource();

			do
			{
				mode = Program.EnterMode();
				switch (mode)
				{

					case 'o':
						MainMenu();
						break;

					case 'c':
						shop.SetBuilder(new CascadeBouquetBuilder());
						currentBuquet = shop.Menu();
						MainMenu();
						break;

					case 'r':
						shop.SetBuilder(new RoundBouquetBuilder());
						currentBuquet = shop.Menu();
						MainMenu();
						break;

					case 't':
						shop.SetBuilder(new TriangularBouquetBuilder());
						currentBuquet = shop.Menu();
						MainMenu();
						break;

					case 'i':
						if (currentBuquet != null) currentBuquet.GetInfo();
						else Console.WriteLine(" < Bouquet wasn't constructed > ");
						break;

					case 'w':
						if (currentBuquet != null)
						{
							BouquetWrapper wrapper = new BouquetWrapper();
							wrapper.ChooseWrapper();
							MainMenu();
							currentBuquet = new WrappedBouquet(currentBuquet, wrapper);
						}
						else Console.WriteLine(" < Bouquet wasn't constructed > ");
						break;

					case 'p':
						if (currentBuquet != null)
						{
							Postcard postcard = new Postcard();
							postcard.SignPostcard();
							currentBuquet = new SignedBouquet(currentBuquet, postcard);
						}
						else Console.WriteLine(" < Bouquet wasn't constructed > ");
						break;

					case 'q':
						break;

					default:
						Console.WriteLine(" < Wrong mode > ");
						break;
				}

			} while (mode != 'q');
		
		}

		public static char EnterMode()
		{
			char mode = ' ';
			try
			{
				Console.Write(" < Enter mode > \n>");
				mode = char.Parse(Console.ReadLine());
			}
			catch (FormatException)
			{
			}

			return char.ToLower(mode);
		}
	}
}
	

