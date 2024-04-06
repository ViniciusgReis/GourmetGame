using GourmetGame.Core.Entities;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GourmetGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Food typePasta = new Food("Macarrão", "Massa");
        Food notTypePasta = new Food("Bolo de Chocolate", "Bolo");

        List<Food> listOptionPasta = new List<Food>();
        List<Food> listOptionNotPasta = new List<Food>();
        
        public MainWindow()
        {
            InitializeComponent();
            listOptionPasta.Add(typePasta);
            listOptionNotPasta.Add(notTypePasta);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {           

            MessageBoxResult result = MessageBox.Show("O prato que você pensou é massa ?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                GuessFood(listOptionPasta);
                return;
            }
            else if (result == MessageBoxResult.No)
            {
                GuessFood(listOptionNotPasta);
                return;
            }
        }
    }
}