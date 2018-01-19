using System;
using System.Windows.Input;

namespace ESTTest.Infrastructure
{
    public class AlwaysExecutableDelegateCommand : ICommand
    {
        private readonly Action _execute;

        public event EventHandler CanExecuteChanged;

        public AlwaysExecutableDelegateCommand(Action execute)
        {
            _execute = execute;
        }

        public bool CanExecute(object parameter) =>
            true;

        public void Execute(object parameter) =>
            _execute();
    }
}
