namespace Gyak.Game
{
    public class Round
    {
        private Guess _guess;
        private Result _result;
        public Guess Guess => _guess;
        public Result Result => _result;

        private Round(Guess guess, Result result)
        {
            _guess = guess;
            _result = result;
        }

        public static Round Check(Question question, Guess guess)
        {
            int black = 0, white = 0, none = 0;

            for (int i = 0; i < question.Pegs.Count; i++)
            {
                if (guess.Pegs[i].Value == question.Pegs[i].Value)
                {
                    black++;
                }
                else if (question.Pegs.Any(m => m.Value == guess.Pegs[i].Value)) 
                { 
                    white++;
                }
                else
                {
                    none++;
                }
            }
            var result = Result.Create(black, white, none);
            return new Round(guess, result);
        }
        public bool IsMatch()
        {
            int blacks = 0;
            foreach (var pin in _result.Pins)
            {
                if (pin == Pin.Black)
                {
                    blacks++;
                }
            }

            return blacks == _result.Pins.Count;
        }
    }
}
