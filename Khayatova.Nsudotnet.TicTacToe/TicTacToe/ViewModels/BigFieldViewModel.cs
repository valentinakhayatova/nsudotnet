using System.Collections.Generic;
using Caliburn.Micro;
using System.Collections.ObjectModel;

namespace TicTacToe.ViewModels
{
    public class BigFieldViewModel : PropertyChangedBase
    {
        public const int Size = 3;
        public BigFieldViewModel()
        {
            SmallFields = new ObservableCollection<ObservableCollection<SmallFieldViewModel>>();
            for (int i = 0; i < Size; i++)
            {
                SmallFields.Add(new ObservableCollection<SmallFieldViewModel>());
                for (int j = 0; j < Size; j++)
                {
                    SmallFields[i].Add(new SmallFieldViewModel());
                }
            }
        }






        private ObservableCollection<ObservableCollection<SmallFieldViewModel>> _smallFields;
        public ObservableCollection<ObservableCollection<SmallFieldViewModel>> SmallFields
        {
            get { return _smallFields; }
            private set
            {
                if (_smallFields == value)
                {
                    return;
                }
                _smallFields = value;
                NotifyOfPropertyChange(() => SmallFields);
            }
        }
    }
}