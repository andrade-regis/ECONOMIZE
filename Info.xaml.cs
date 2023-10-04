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
using System.Windows.Shapes;

namespace ECONOMIZE
{
    /// <summary>
    /// Lógica interna para Info.xaml
    /// </summary>
    public partial class Info : Window
    {
        public Info()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, MouseButtonEventArgs e)
        {
             var Border = (Border)sender;

            switch (Border.Name)
            {
                case "Button_Seguir":
                    {
                        this.Visibility = Visibility.Collapsed;

                        if (!AbrirJanela_InicialSaldo())
                        {
                            this.Close();
                            return;
                        }

                        MainWindow mainWindow = new MainWindow();
                        mainWindow.ShowDialog();

                        this.Close();
                    }
                    break;
                case "Button_ComoUsar":
                    {

                    }
                    break;
                case "Button_Sair":
                    {
                        this.Close();
                    }
                    break;
            }
        }

        private bool AbrirJanela_InicialSaldo()
        {
            frmPerguntarSaldoInicial frmPerguntarSaldoInicial = new frmPerguntarSaldoInicial();
            frmPerguntarSaldoInicial.ShowDialog();

            return frmPerguntarSaldoInicial.AcessoLiberado;
        }
    }
}
