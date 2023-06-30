using AlgoritmoGenetico.AbstractClasses;
using AlgoritmoGenetico.Models;
using AlgoritmoGenetico.ViewModels;

namespace AlgoritmoGenetico.Commands
{
    public class SearchMazePathCommand : BaseCommand
    {
        private MainWindowViewModel _viewModel;

        public SearchMazePathCommand(MainWindowViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            _viewModel.BestIndividuals.Clear();
            _viewModel.IsSearching = true;
            _viewModel.SelectedIndividual = null;

            var geneticAlgorithm = new GeneticAlgorithm(
                _viewModel.CrossoverRate,
                _viewModel.MutationRate,
                _viewModel.PopulationSize,
                _viewModel.MaxNumberOfGenerations,
                _viewModel.ElitismEnabled);

            _viewModel.Worker.RunWorkerAsync(geneticAlgorithm);
        }      
    }
}
