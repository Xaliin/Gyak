using System.Diagnostics;
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
        private bool _gameEnded;

        private Stopwatch _stopwatch;
        public Settings Settings => _settings;
        public Question Question => _question;
        public IReadOnlyList<Peg> AvailableColors => _availableColors.AsReadOnly();
        public IReadOnlyList<Round> Rounds => _rounds.AsReadOnly();
        public IReadOnlyList<Peg> Selected => _selected.AsReadOnly();
        public bool GameEnded => _gameEnded;
        public TimeSpan ElapsedTime => _stopwatch.Elapsed;

        public event EventHandler<string> MessageReceived;
        public event EventHandler<bool> GameFinished;




        private Mastermind(Settings settings)
        {
            _stopwatch = new Stopwatch();
            _settings = settings;
            StartGame();
        }

        private void StartGame()
        {
            _question = Question.Create(_settings);
            _gameEnded = false;
			_rounds = [];
			CreateAvailableColors();
            _stopwatch.Restart();
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
            var round = Round.Check(_question, guess);
            _rounds.Add(round);

            if (round.IsMatch())
            {
                StopGame(true);
            }
            else if (_rounds.Count == _settings.TriesNum)
            {
                StopGame(false);
            }
            else MessageReceived?.Invoke(this, "Hozzáadtál egy tippet.");
            
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
            StartGame();
		}

        private void StopGame(bool winner) 
        {
            _stopwatch.Stop();
			GameFinished?.Invoke(this, winner);
			_gameEnded = true;
		}
	}
}
