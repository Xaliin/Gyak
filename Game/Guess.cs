using System.Runtime.InteropServices;

namespace Gyak.Game
{
    public class Guess
    {
        private List<Peg> _pegs = [];
        public IReadOnlyList<Peg> Pegs => _pegs.AsReadOnly();


        private Guess(int pegCount)
        {
            _pegs = Enumerable.Range(1, pegCount).Select(m => (Peg)null).ToList();
            //for (int i = 0; i < pegCount; i++)
            //{
            //    _pegs.Add(null);
            //}
        }

        public static Guess Create(int pegCount)
        {
            return new Guess(pegCount);
        }

        public void SetPeg(int pegIndex, Peg peg)
        {
            if (pegIndex < 0 || pegIndex > (_pegs.Count - 1)) throw new InvalidDataException("Érvénytelen index");

            _pegs[pegIndex] = peg;
        }

        public void AddPeg(Peg peg)
        {
            var index = _pegs.IndexOf(null);
            SetPeg(index, peg);
        }

        public bool IsValid()
        {
            return _pegs.All(m => m != null);
            //foreach (var peg in _pegs)
            //{
            //    if (peg == null)
            //    {
            //        return false;
            //    }
            //}
            //return true;
        }
        
        public bool IsCorrect
        {
            get
            {
                return _pegs.All(m => m != null);
            }
        }
    }
}
