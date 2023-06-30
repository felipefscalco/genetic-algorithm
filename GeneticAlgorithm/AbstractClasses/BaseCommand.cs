using System;
using System.Windows.Input;

namespace AlgoritmoGenetico.AbstractClasses
{
    public abstract class BaseCommand : ICommand
    {
        private bool _canExecute;

        protected BaseCommand()
        {
            _canExecute = true;
        }

        public bool CanExecute(object parameter)
        {
            var newValue = OnCanExecute(parameter);
            if (newValue == _canExecute)
            {
                return newValue;
            }

            _canExecute = newValue;
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);

            return newValue;
        }

        protected virtual bool OnCanExecute(object parameter)
        {
            return true;
        }

        public abstract void Execute(object parameter);

        public event EventHandler CanExecuteChanged;
    }
}
