using System;

namespace BowlingGame
{
	class Program
	{
		public static void Main(string[] args)
		{
			int[] theArray = { 1, 3, 7, 3, 10, 1, 7, 4, 2, 5, 3, 8, 2, 7, 2, 10, 9, 3 };
			BowlingGame game = new BowlingGame();
			game.Roll(theArray);

			int result =  game.Score();
			Console.WriteLine("The Final score is : " + result);
			Console.ReadLine();
		}
	}
}
