using AlgoritmoGenetico.AbstractClasses;
using AlgoritmoGenetico.Commands;
using AlgoritmoGenetico.Models;
using System.Collections.Generic;
using System.Windows.Input;

namespace AlgoritmoGenetico.ViewModels
{
    public class IndividualViewModel : ViewModel
    {
        #region Fields
        private int _fieldsTraveledCount;
        private int _repeatedFields;
        private int _wallHits;
        private int _generation;
        private int _fitness;
        private string _genes;
        private bool _hasSolution;
        private bool _hasImpossibleMove;
        private MainWindowViewModel _viewModel;
        #endregion

        #region NotifiableProperties
        public int FieldsTraveledCount
        {
            get => _fieldsTraveledCount;
            set
            {
                _fieldsTraveledCount = value;
                OnPropertyChanged();
            }
        }

        public int WallHits
        {
            get => _wallHits;
            set
            {
                _wallHits = value;
                OnPropertyChanged();
            }
        }

        public int RepeatedFields
        {
            get => _repeatedFields;
            set
            {
                _repeatedFields = value;
                OnPropertyChanged();
            }
        }

        public int Generation
        {
            get => _generation;
            set
            {
                _generation = value;
                OnPropertyChanged();
            }
        }

        public int Fitness
        {
            get => _fitness;
            set
            {
                _fitness = value;
                OnPropertyChanged();
            }
        }

        public string Genes
        {
            get => _genes;
            set
            {
                _genes = value;
                OnPropertyChanged();
            }
        }

        public bool HasImpossibleMove
        {
            get => _hasImpossibleMove;
            set
            {
                _hasImpossibleMove = value;
                OnPropertyChanged();
            }
        }

        public bool HasSolution
        {
            get => _hasSolution;
            set
            {
                _hasSolution = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public List<MazeField> FieldsTraveled { get; set; }

        public ICommand DrawIndividualCommand { get; set; }

        public IndividualViewModel(MainWindowViewModel viewModel, Individual individual, int generation)
        {
            _viewModel = viewModel;

            DrawIndividualCommand = new DrawIndividualCommand(this);

            FieldsTraveledCount = individual.FieldsTraveled.Count;
            RepeatedFields = individual.RepeatedFields;
            WallHits = individual.WallsHit;
            Genes = individual.Genes;
            HasSolution = individual.HasSolution;
            HasImpossibleMove = individual.HasImpossibleMove;
            Fitness = individual.Fitness;
            Generation = generation;
            FieldsTraveled = individual.FieldsTraveled;
        }

        public void CallDrawIndividual(IndividualViewModel individual)
        {
            _viewModel.DrawSelectedIndividual(individual);
        }
    }
}