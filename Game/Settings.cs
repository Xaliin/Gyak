namespace Gyak.Game
{
    public class Settings
    {
        public int PegNum { get; }
        public int ColorsNum { get; }
        public int TriesNum { get; }

        private Settings(int pegnum, int colorsnum, int triesnum)
        {
            PegNum = pegnum;
            ColorsNum = colorsnum;
            TriesNum = triesnum;
        }

        public static Settings Default => new Settings(4, 6, 10);
        public static Settings Default2 { get { return new Settings(4, 6, 10); } }

        public static Settings Create(int pegnum, int colorsnum, int triesnum)
        {
            if (colorsnum < pegnum) throw new InvalidDataException("Színek száma legyen legalább megyező a lyukak számával!");

            if (triesnum < pegnum) throw new InvalidDataException("Próbálkozások száma legyen legalább megyező a lyukak számával!");

            return new Settings(pegnum, colorsnum, triesnum);
        }
    }
}
