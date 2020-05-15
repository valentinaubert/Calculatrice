using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculatrice
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel _vm;
        public MainWindow()
        {
            InitializeComponent();
            _vm = new MainViewModel();
            _vm.Resultat = "";
            _vm.SumCalcul = "";
            this.DataContext = _vm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button b = (System.Windows.Controls.Button)sender;

            _vm.Resultat += b.Content.ToString();

            if (b.Content.ToString() is "+")
            {
                _vm.SumCalcul += _vm.Resultat;
                _vm.Resultat = "";
            }

            if (b.Content.ToString() is "=")
            {
                //calcul de _vm.SumCalcul et _vm.Resultat
                //Affichage du resultat dans _vm.Resultat
                _vm.SumCalcul += _vm.Resultat;
                _vm.Resultat = "Résultat calcul";
                
            }



        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                _vm.Resultat = "ENTER";
            }
        }
    }
}
