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



namespace A3._2._4_Calculadora_Estilos
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CrearBotones();
        }

        private void CrearBotones()
        {
            for (int i = 0; i < 4; i++)
                gridBotones.RowDefinitions.Add(new RowDefinition());
            for (int j = 0; j < 3; j++)
                gridBotones.ColumnDefinitions.Add(new ColumnDefinition());

            var estiloBoton = (Style)this.FindResource("EstiloBoton");

            int numero = 1;
            for (int fila = 0; fila < 3; fila++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Button boton = new Button();
                    boton.Content = numero.ToString();
                    boton.Style = estiloBoton;
                    boton.Click += Button_Click;

                    Grid.SetRow(boton, fila);
                    Grid.SetColumn(boton, col);
                    gridBotones.Children.Add(boton);

                    numero++;
                }
            }

            Button boton0 = new Button();
            boton0.Content = "0";
            boton0.Style = estiloBoton;
            boton0.Click += Button_Click;

            Grid.SetRow(boton0, 3);
            Grid.SetColumn(boton0, 0);
            Grid.SetColumnSpan(boton0, 3);

            gridBotones.Children.Add(boton0);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button boton = (Button)sender;
            txtDisplay.Text += boton.Content.ToString();
        }
    }
}
