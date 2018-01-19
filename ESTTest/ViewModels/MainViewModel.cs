using ESTTest.Infrastructure;
using ESTTest.Models;
using System.Windows.Input;
using System.Windows.Media;

namespace ESTTest
{
    public class MainViewModel : BindableBase
    {
        private readonly Counter _counter;
        private Brush _background;

        public MainViewModel()
        {
            _counter = new Counter();
            _counter.PropertyChanged += (_, e) => OnPropertyChanged(e.PropertyName);
            _background = Brushes.White;

            NextCommand = new AlwaysExecutableDelegateCommand(() =>
            {
                _counter.Next();
                Background = GetBackground();
            });
        }

        public int Value => _counter.Value;
        public ICommand NextCommand { get; }
        public Brush Background
        {
            get => _background;
            set
            {
                if (_background == value)
                {
                    return;
                }

                _background = value;
                OnPropertyChanged(nameof(Background));
            }
        }

        private Brush GetBackground()
        {
            if (Value % 2 == 0)
            {
                return Brushes.LightBlue;
            }
            else
            {
                return Brushes.IndianRed;
            }
        }
    }
}
