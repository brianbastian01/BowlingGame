namespace BowlingGame
{
	public class BowlingGame : IBowlingGame
	{
		private int[] rolls = new int[21];
		int currentRoll = 0;
        const int frame = 10;

        public void Roll(int pins)
        {
            rolls[currentRoll++] = pins;
        }

        public void Roll(int[] pins)
        {
            for (int i = 0; i < pins.Length; i++)
            {
                rolls[currentRoll++] = pins[i];
            }
        }
        private bool isSpare(int framePointer)
        {
            return rolls[framePointer] + rolls[framePointer + 1] == frame;
        }

        private bool isStrike(int framePointer)
        {
            return rolls[framePointer] == frame;
        }

        
        public int Score()
        {
            int score = 0;
            int framePointer = 0;
            for (int frame = 0; frame < 10; frame++)
            {
                if (isSpare(framePointer))
                {
                    score += 10 + rolls[framePointer + 2];
                    framePointer += 2;
                }
                else if (isStrike(framePointer))
                {
                    score += 10 + rolls[framePointer + 1] + rolls[framePointer + 2];
                    framePointer++;
                }
                else
                {
                    score += rolls[framePointer] + rolls[framePointer + 1];
                    framePointer += 2;
                }
            }

            return score;
        }
    }
}
