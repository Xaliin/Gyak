namespace Gyak.Game
{
    public enum Pin 
    { 
        None,
        White,
        Black
    }
    public class Result
    {
        private List<Pin> _pins = [];
        public IReadOnlyList<Pin> Pins => _pins.AsReadOnly();
        public bool IsMatch => _pins.All(p => p == Pin.Black);

        private Result(int pinCount)
        {
            _pins = Enumerable.Range(0, pinCount).Select(m => Pin.None).ToList();
        }

        private Result(List<Pin> pins)
        {
            _pins = pins;
        }


        public static Result Create(int pinCount)
        {
            return new Result(pinCount);
        }

        public static Result Create(int black, int white, int none)
        {
            var pins = new List<Pin>();
            for (int i = 0; i < black; i++)
            {
                pins.Add(Pin.Black);
            }
            for (int i = 0; i < white; i++)
            {
                pins.Add(Pin.White);
            }
            for (int i = 0; i < none; i++)
            {
                pins.Add(Pin.None);
            }

            return new Result(pins);
        }
    }
}
