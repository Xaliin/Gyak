using System.Xml.Linq;

namespace Gyak.Game
{
    public class Question
    {
        private List<Peg> _pegs = [];
        public IReadOnlyList<Peg> Pegs => _pegs.AsReadOnly();

        private Question(List<Peg> pegs)
        {
            _pegs = pegs;
        }

        public static Question Create(Settings settings)
        {
            var divider = settings.ColorsNum;

            List<int> ints = [];
            var r = new Random(Environment.TickCount);
            while (ints.Count < settings.PegNum)
            {
                var value = r.Next(0, 10000);
                value = value % divider;

                if (!ints.Contains(value)) ints.Add(value);
            }

            var pegs = ints.Select(i => Peg.Create((char)(65 + i))).ToList();
            return new Question(pegs);
        }
    }
}
