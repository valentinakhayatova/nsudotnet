using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using Caliburn.Micro;
using TicTacToe.Models;

namespace TicTacToe.ViewModels
{
    public class MainViewModel : Screen
    {
        public const int Size = 3;
        public MainViewModel()
        {
            InitField();
            CurrentUser = User.Cross;
            _model = new TicTacToeModel();
        }

        private int _crossWins;
        public int CrossWins
        {
            get { return _crossWins; }
            private set
            {
                if (_crossWins == value)
                {
                    return;
                }
                _crossWins = value;
                NotifyOfPropertyChange(() => CrossWins);
            }
        }

        private int _zeroWins;
        public int ZeroWins
        {
            get { return _zeroWins; }
            private set
            {
                if (_zeroWins == value)
                {
                    return;
                }
                _zeroWins = value;
                NotifyOfPropertyChange(() => ZeroWins);
            }
        }


        #region CurrentUserPropperty

        private User _currentUser;

        public User CurrentUser
        {
            get { return _currentUser; }

            set
            {

                if (_currentUser == value) return;

                _currentUser = value;

                NotifyOfPropertyChange();
                UpdateCurrentUser();
            }
        }

        #endregion


     

        private ObservableCollection<ObservableCollection<SmallFieldViewModel>> _field;
        public ObservableCollection<ObservableCollection<SmallFieldViewModel>> Field
        {
            get { return _field; }
            private set
            {
                if (_field == value)
                {
                    return;
                }
                _field = value;
                NotifyOfPropertyChange(() => Field);
            }
        }


        #region CurrentFieldPropperty

        private Tuple<int, int> _currentField;

        public Tuple<int, int> CurrentField
        {
            get { return _currentField; }

            set
            {

                if (Equals(_currentField, value) ) return;

                if (value != null && _field != null && Field[value.Item1][value.Item2].IsComplite)
                {
                    return;
                }

                _currentField = value;
                NotifyOfPropertyChange();
                CurrentFieldChanged();
            }
        }

        #endregion

        protected void InitField()
        {
            Field = new ObservableCollection<ObservableCollection<SmallFieldViewModel>>();
            for (int i = 0; i < Size; i++)
            {
                Field.Add(new ObservableCollection<SmallFieldViewModel>());
                for (int j = 0; j < Size; j++)
                {
                    Field[i].Add(new SmallFieldViewModel());
                    Field[i][j].DoStep += OnDoStep;
                }
            }
        }

        private void OnDoStep(object sender, MakeStepEventArgs makeStepEventArgs)
        {
            ChangeUser();

            var vm = Field[CurrentField.Item1][CurrentField.Item2];



            if (vm.Winner != null)
            {
                _model.DoStep(vm.Winner.Value, CurrentField.Item1, CurrentField.Item2);
            }


            if (_model.IsComplited || Field.SelectMany(a => a).All(a => a.IsComplite))
            {
                ShowResult();
                UpdateStatistic();
                RestartGame();
                return;
            }
            CurrentField = Field[makeStepEventArgs.Position.Item1][makeStepEventArgs.Position.Item2].IsComplite ? null : makeStepEventArgs.Position;

        }

        private void UpdateStatistic()
        {
            if (_model.Winer == User.Cross)
            {
                CrossWins = CrossWins + 1;
            }
            if (_model.Winer == User.Zero)
            {
                ZeroWins = ZeroWins + 1;
            }
        }


        public void ClearStatistic()
        {
            ZeroWins = 0;
            CrossWins = 0;
        }

        public void RestartGame()
        {
            InitField();
            CurrentUser = User.Cross;
            CurrentField = null;
            _model = new TicTacToeModel();
        }
        private void ShowResult()
        {
            MessageBox.Show(_model.Winer == null ? "Draw!" : String.Format("Winner is {0}", _model.Winer.Value));
        }

        private void ChangeUser()
        {
            CurrentUser = _currentUser == User.Cross ? User.Zero : User.Cross;
        }

        private void UpdateCurrentUser()
        {
            foreach (var next in Field.SelectMany(a => a))
            {
                next.CurrentUser = _currentUser;
            }
        }

        private TicTacToeModel _model;

        private void CurrentFieldChanged()
        {
            for (int i = 0; i < Field.Count; i++)
            {
                for (int j = 0; j < Field[i].Count; j++)
                {
                    if (CurrentField != null && i == CurrentField.Item1 && j == CurrentField.Item2)
                    {
                        Field[i][j].IsActive = true;
                    }
                    else
                    {
                        Field[i][j].IsActive = false;
                        
                    }
                }
            }
        }
    }

    internal class MainViewModelDesignTime : MainViewModel
    {
        public MainViewModelDesignTime()
        {
            InitField();
            CurrentUser = User.Cross;
            
        }
    }
}