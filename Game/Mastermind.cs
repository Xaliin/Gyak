using System.Runtime.InteropServices;

namespace Gyak.Game
{
    public class Mastermind
    {
        private Settings _settings;
        private List<Peg> _availableColors = [];
        public IReadOnlyList<Peg> AvailableColors => _availableColors.AsReadOnly();

        private Mastermind(Settings settings)
        {
            _settings = settings;
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


    }
}
