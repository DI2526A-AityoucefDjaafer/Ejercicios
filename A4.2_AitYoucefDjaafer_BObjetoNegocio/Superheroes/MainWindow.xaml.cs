using System.Windows;
using System.Windows.Input;
using Superheroes.Services;
using System.Text;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Superheroes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Superheroe> personajes;
        private int indice = 0;

        public MainWindow()
        {
            InitializeComponent();
            personajes = DataService.GetSamples();
            DataContext = personajes[indice];
        }

        private void Siguiente_Click(object sender, MouseButtonEventArgs e)
        {
            indice = (indice + 1) % personajes.Count;
            DataContext = personajes[indice];
        }

        private void Anterior_Click(object sender, MouseButtonEventArgs e)
        {
            indice = (indice - 1 + personajes.Count) % personajes.Count;
            DataContext = personajes[indice];
        }
    }
}