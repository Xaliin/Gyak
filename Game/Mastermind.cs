using System.Runtime.InteropServices;

namespace Gyak.Game
{
    public class Mastermind
    {
        private Settings _settings;
        private List<Peg> _availableColors = [];
        private List<Round> _rounds = [];
        private Question _question;
        private List<Peg> _selected = new List<Peg>();
        public Settings Settings => _settings;
        public IReadOnlyList<Peg> AvailableColors => _availableColors.AsReadOnly();
        public IReadOnlyList<Round> Rounds => _rounds.AsReadOnly();
        public IReadOnlyList<Peg> Selected => _selected.AsReadOnly();


        private Mastermind(Settings settings)
        {
            _settings = settings;
            _question = Question.Create(settings);
            CreateAvailableColors();
        }

        public static Mastermind Create(Settings settings)
        {
            return new Mastermind(settings);
        }

        public static Mastermind Create()
        {
            return new Mastermind(Settings.Default);
        }

        private void CreateAvailableColors()
        {
            _availableColors.Clear();
            for (int i = 0; i < _settings.ColorsNum; i++)
            {
                var peg = Peg.Create((char)(65+i));
                _availableColors.Add(peg);
            }
        }

        public Guess CreateGuess()
        {
            return Guess.Create(_settings.PegNum);
        }

        public void AddGuess(Guess guess)
        {
            if (!guess.IsValid()) return;

            _rounds.Add(Round.Check(_question, guess));
        }

        public void AddPeg(Peg peg)
        {
            _selected.Add(peg);
        }
        
        public void EmptyQueue()
        {
            _selected.Clear();
        }

        public void Configure(Settings settings)
        {
            _settings = settings;
            CreateAvailableColors();
            _rounds = [];
            _selected = [];
            _question = Question.Create(settings);
        }
    }
}
