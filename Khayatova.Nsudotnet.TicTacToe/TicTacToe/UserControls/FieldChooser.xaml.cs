using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TicTacToe.UserControls
{
    /// <summary>
    /// Interaction logic for FieldChooser.xaml
    /// </summary>
    public partial class FieldChooser
    {
        public static readonly DependencyProperty ChoosedFieldProperty = DependencyProperty.Register(
            "ChoosedField", typeof (Tuple<int, int>), typeof (FieldChooser), new PropertyMetadata(default(Tuple<int, int>)));

        public Tuple<int, int> ChoosedField
        {
            get { return (Tuple<int, int>) GetValue(ChoosedFieldProperty); }
            set { SetValue(ChoosedFieldProperty, value); }
        }
        public FieldChooser()
        {
            InitializeComponent();
        }

        private void ButtonChoosed(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }

            var row = Grid.GetRow(button);
            var collumn = Grid.GetColumn(button);

            ChoosedField = new Tuple<int, int>(row, collumn);
        }
    }
}
