using AlgoritmoGenetico.AbstractClasses;
using AlgoritmoGenetico.ViewModels;

namespace AlgoritmoGenetico.Commands
{
    public class DrawIndividualCommand : BaseCommand
    {
        private IndividualViewModel _viewModel;
        public DrawIndividualCommand(IndividualViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            if (parameter is IndividualViewModel individualViewModel)
            {
                _viewModel.CallDrawIndividual(individualViewModel);
            }
        }
    }
}
