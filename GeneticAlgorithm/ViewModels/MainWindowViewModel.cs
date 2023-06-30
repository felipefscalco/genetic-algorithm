using AlgoritmoGenetico.AbstractClasses;
using AlgoritmoGenetico.Commands;
using AlgoritmoGenetico.Helpers;
using AlgoritmoGenetico.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Input;

namespace AlgoritmoGenetico.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        #region Constants
        public const int SquareSize = 35;
        public const int Columns = 10;
        public const int Rows = 10;
        #endregion

        #region Fields
        private float _crossoverRate;
        private float _mutationRate;
        private int _populationSize;
        private int _maxNumberOfGenerations;
        private bool _elitismEnabled;
        private bool _isSearching;
        private IndividualViewModel _selectedIndividual;
        #endregion

        #region PublicProperties
        public Canvas Canvas { get; private set; }
        public MazeStructure MazeStructure { get; private set; }
        public BackgroundWorker Worker { get; set; }
        public ObservableCollection<IndividualViewModel> BestIndividuals { get; set; }
        #endregion

        #region NotifiableProperties
        public float CrossoverRate
        {
            get => _crossoverRate;
            set
            {
                _crossoverRate = value;
                OnPropertyChanged();
            }
        }

        public float MutationRate
        {
            get => _mutationRate;
            set
            {
                _mutationRate = value;
                OnPropertyChanged();
            }
        }

        public int PopulationSize
        {
            get => _populationSize;
            set
            {
                _populationSize = value;
                OnPropertyChanged();
            }
        }

        public int MaxNumberOfGenerations
        {
            get => _maxNumberOfGenerations;
            set
            {
                _maxNumberOfGenerations = value;
                OnPropertyChanged();
            }
        }

        public bool ElitismEnabled
        {
            get => _elitismEnabled;
            set
            {
                _elitismEnabled = value;
                OnPropertyChanged();
            }
        }

        public bool IsSearching
        {
            get => _isSearching;
            set
            {
                _isSearching = value;
                OnPropertyChanged();
            }
        }

        public IndividualViewModel SelectedIndividual
        {
            get => _selectedIndividual;
            set
            {
                _selectedIndividual = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Commands

        public ICommand SearchMazePathCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }
        #endregion

        #region Constructor
        public MainWindowViewModel(Canvas canvas)
        {
            Canvas = canvas;

            InitializeFields();

            InitializeCommands();

            InitializeMaze();
        }
        #endregion

        public void DrawSelectedIndividual(IndividualViewModel individual)
        {
            SelectedIndividual = individual;
            CanvasHelper.UpdateUI(individual.FieldsTraveled);
        }

        #region PrivateMethods
        private void InitializeFields()
        {
            CrossoverRate = 0.6f;
            MutationRate = 0.5f;
            PopulationSize = 400000;
            MaxNumberOfGenerations = 100;
            ElitismEnabled = true;
            BestIndividuals = new ObservableCollection<IndividualViewModel>();

            Worker = new BackgroundWorker
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };
            Worker.DoWork += Worker_DoWork;
            Worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            Worker.ProgressChanged += Worker_ProgressChanged;
        }

        private void InitializeCommands()
        {
            SearchMazePathCommand = new SearchMazePathCommand(this);
            CancelCommand = new CancelCommand(this);
        }

        private void InitializeMaze()
        {
            MazeStructure = new MazeStructure(Columns, Rows, SquareSize);

            CanvasHelper.AddFieldsToCanvas(Canvas);
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (e.Argument is GeneticAlgorithm geneticAlgorithm)
            {
                geneticAlgorithm.FindMazePath(Worker, e);
            }
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState is Individual individual)
            {
                var newIndividual = new IndividualViewModel(this, individual, GeneticAlgorithm.CurrentGeneration);

                if (!BestIndividuals.Contains(newIndividual))
                {
                    SelectedIndividual = newIndividual;
                    BestIndividuals.Add(SelectedIndividual);
                }

                CanvasHelper.UpdateUI(individual.FieldsTraveled);
            }
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            IsSearching = false;

            CanvasHelper.UpdateUI(GeneticAlgorithm.Solution);
        }
        #endregion
    }
}
