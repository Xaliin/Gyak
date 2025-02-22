namespace Gyak.Game
{
    public class Peg
    {
        private char _value;
        public char Value => _value;

        private Peg(char value)
        {
            _value = value;
        }

        public static Peg Create(char value) => new Peg(value);
    }
}
