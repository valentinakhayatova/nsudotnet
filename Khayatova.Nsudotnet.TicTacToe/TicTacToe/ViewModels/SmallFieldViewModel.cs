using System;
using Caliburn.Micro;
using TicTacToe.Models;
using TicTacToe.UserControls;

namespace TicTacToe.ViewModels
{
    public class MakeStepEventArgs : EventArgs
    {
        public MakeStepEventArgs(Tuple<int, int> position)
        {
            Position = position;
        }

        public Tuple<int, int> Position { get; private set; }
    }
    public class SmallFieldViewModel : PropertyChangedBase
    {
        public event EventHandler<MakeStepEventArgs> DoStep; 

        public SmallFieldViewModel()
        {
            Model = new TicTacToeModel();
        }


        public void HandeSelection(ItemSelectedEventArgs args)
        {
            Model.DoStep(CurrentUser, args.Position.Item1, args.Position.Item2);

            if (Model.IsComplited)
            {
                IsComplite = true;
                IsActive = false;
                Winner = Model.Winer;
            }
            
            OnDoStep(new MakeStepEventArgs(args.Position));
        }
        public TicTacToeModel Model { get; private set; }

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
            }
        }

        #endregion

        #region WinnerPropperty

        private User? _winner;

        public User? Winner
        {
            get { return _winner; }

            set
            {

                if (_winner == value) return;

                _winner = value;
                NotifyOfPropertyChange();
            }
        }

        #endregion

        #region IsActivePropperty

        private bool _isActive;

        public bool IsActive
        {
            get { return _isActive; }

            set
            {

                if (_isActive == value) return;

                _isActive = value;
                NotifyOfPropertyChange();
            }
        }

        #endregion

        #region IsComplitePropperty

        private bool _isComplite;

        public bool IsComplite
        {
            get { return _isComplite; }

            set
            {

                if (_isComplite == value) return;

                _isComplite = value;
                NotifyOfPropertyChange();
            }
        }

        #endregion

        protected virtual void OnDoStep(MakeStepEventArgs e)
        {
            var handler = DoStep;
            if (handler != null) handler(this, e);
        }
    }
}