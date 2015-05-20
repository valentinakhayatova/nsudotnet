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

    public class ItemSelectedEventArgs : RoutedEventArgs
    {
        public ItemSelectedEventArgs(RoutedEvent routedEvent, Tuple<int, int> position) : base(routedEvent)
        {
            Position = position;
        }

        public ItemSelectedEventArgs(Tuple<int, int> item)
        {
            Position = item;
        }
        public Tuple<int, int> Position { get; private set; }
    }
    /// <summary>
    /// Interaction logic for SmallField.xaml
    /// </summary>
    public partial class SmallField : UserControl
    {

        public static readonly RoutedEvent ItemSelectedEvent = EventManager.RegisterRoutedEvent(
    "ItemSelected", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(SmallField));

        // Provide CLR accessors for the event 
        public event RoutedEventHandler ItemSelected
        {
            add { AddHandler(ItemSelectedEvent, value); }
            remove { RemoveHandler(ItemSelectedEvent, value); }
        }


     
        public static readonly DependencyProperty IsCompliteProperty = DependencyProperty.Register(
            "IsComplite", typeof (bool), typeof (SmallField), new PropertyMetadata(default(bool)));

        public bool IsComplite
        {
            get { return (bool) GetValue(IsCompliteProperty); }
            set { SetValue(IsCompliteProperty, value); }
        }

        public static readonly DependencyProperty WinerImageProperty = DependencyProperty.Register(
            "WinerImage", typeof (ImageSource), typeof (SmallField), new PropertyMetadata(default(ImageSource)));

       

        public ImageSource WinerImage
        {
            get { return (ImageSource) GetValue(WinerImageProperty); }
            set { SetValue(WinerImageProperty, value); }
        }

        public static readonly DependencyProperty CurrentUserImageProperty = DependencyProperty.Register(
            "CurrentUserImage", typeof (ImageSource), typeof (SmallField), new PropertyMetadata(default(ImageSource)));

        public ImageSource CurrentUserImage
        {
            get { return (ImageSource) GetValue(CurrentUserImageProperty); }
            set { SetValue(CurrentUserImageProperty, value); }
        }
        public SmallField()
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
            button.Content = new Image {Source = CurrentUserImage};
            var r = Grid.GetRow(button);
            var c = Grid.GetColumn(button);

            RaiseEvent(new ItemSelectedEventArgs(ItemSelectedEvent, new Tuple<int, int>(r, c)));


        }
    }
}
