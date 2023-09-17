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

namespace ECONOMIZE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Border_Inicio_MouseDown(null, null);
        }

        private void Border_Sair_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Border_Inicio_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Label_Inicio.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#787CD2"));

            frmInício frmInício = new frmInício();
            grid_principal_areaDeTrabalho.Children.Add(frmInício);
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            frmAdicionarTransação frmAdicionarTransação = new frmAdicionarTransação();
            frmAdicionarTransação.ShowDialog();
        }
    }
}
