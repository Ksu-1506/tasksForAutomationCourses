using System;

namespace Task6ForCourses
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Enter what  number of Lights you would like see in your garland:");
			int customerLightCount = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine(
				"Enter what  type of garland you would like see (where 1 - Simple garland, 2 - Color garland, 3 - Both garlands:");
			int garlandType = Convert.ToInt32(Console.ReadLine());


			if (garlandType == 1)
			{
				Console.WriteLine($"Simple garland with {customerLightCount} lights look like this:");
				SimpleGarland simpleGarland = new SimpleGarland(customerLightCount);
				simpleGarland.PrintGarlandState();
			}

			if (garlandType == 2)
			{
				Console.WriteLine($"Color garland with {customerLightCount} lights look like this:");
				ColorGarland colorGarland = new ColorGarland(customerLightCount);
				colorGarland.PrintGarlandState();
			}

			if (garlandType == 3)
			{
				Console.WriteLine($"Simple garland with {customerLightCount} lights look like this:");
				SimpleGarland simpleGarland = new SimpleGarland(customerLightCount);
				simpleGarland.PrintGarlandState();
				Console.WriteLine($"Color garland with {customerLightCount} lights look like this:");
				ColorGarland colorGarland = new ColorGarland(customerLightCount);
				colorGarland.PrintGarlandState();
			}

			else
			{
				Console.WriteLine(
					$"Sorry, but you were mistaken in choosing the type of garland. Please, try again {Environment.NewLine}");
			}

			Console.ReadKey();
		}
	}
}