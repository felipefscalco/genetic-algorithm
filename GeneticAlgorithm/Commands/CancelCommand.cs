using AlgoritmoGenetico.AbstractClasses;
using AlgoritmoGenetico.ViewModels;
using System;

namespace AlgoritmoGenetico.Commands
{
    public class CancelCommand : BaseCommand
    {
        private MainWindowViewModel _viewModel;
        public CancelCommand(MainWindowViewModel viewModel)
        {
            _viewModel = viewModel;        
        }

        public override void Execute(object parameter)
        {
            _viewModel.Worker.CancelAsync();
        }
    }
}
