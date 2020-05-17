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
using System.Windows.Media.Animation;
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

            if (b.Content.ToString() is "⇦")
            {
                if (_vm.Resultat != "")
                {
                    _vm.Resultat = _vm.Resultat.Remove(_vm.Resultat.Length - 1);
                }
                
            }
            else if (b.Content.ToString() is "+/-")
            {
                _vm.Resultat += "-";
            }
            else
            {
                _vm.Resultat += b.Content.ToString();

                if (b.Content.ToString() is "+" ||
                    b.Content.ToString() is "-" ||
                    b.Content.ToString() is "*" ||
                    b.Content.ToString() is "/")
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

                if (b.Content.ToString() is "CE")
                {
                    _vm.Resultat = "";
                }

                if (b.Content.ToString() is "C")
                {
                    _vm.Resultat = "";
                    _vm.SumCalcul = "";
                }

                if (b.Content.ToString() is "%" ||
                    b.Content.ToString() is "㏒" ||
                    b.Content.ToString() is "÷" ||
                    b.Content.ToString() is "^" ||
                    b.Content.ToString() is "√" ||
                    b.Content.ToString() is "sin" ||
                    b.Content.ToString() is "cos" ||
                    b.Content.ToString() is "tan")
                {
                    System.Windows.MessageBox.Show("Ce calcul n'est pas implementée encore.");
                    _vm.Resultat = "";
                    _vm.SumCalcul = "";
                }

                

            }

        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {

            Console.WriteLine(e.Key);

            //Lorsque l'on appuie sur = pour afficher le résultat
            if (e.Key == Key.Enter)
            {
                //calcul de _vm.SumCalcul et _vm.Resultat
                //Affichage du resultat dans _vm.Resultat
                _vm.SumCalcul += _vm.Resultat;
                _vm.Resultat = "Résultat calcul";
            }

            //Chiffres
            if (e.Key == Key.NumPad0)
            {
                _vm.Resultat += "0";
            }
            if (e.Key == Key.NumPad1)
            {
                _vm.Resultat += "1";
            }
            if (e.Key == Key.NumPad2)
            {
                _vm.Resultat += "2";
            }
            if (e.Key == Key.NumPad3)
            {
                _vm.Resultat += "3";
            }
            if (e.Key == Key.NumPad4)
            {
                _vm.Resultat += "4";
            }
            if (e.Key == Key.NumPad5)
            {
                _vm.Resultat += "5";
            }
            if (e.Key == Key.NumPad6)
            {
                _vm.Resultat += "6";
            }
            if (e.Key == Key.NumPad7)
            {
                _vm.Resultat += "7";
            }
            if (e.Key == Key.NumPad8)
            {
                _vm.Resultat += "8";
            }
            if (e.Key == Key.NumPad9)
            {
                _vm.Resultat += "9";
            }

            //Opérations basiques
            if (e.Key == Key.Add)
            {
                _vm.Resultat += "+";
                _vm.SumCalcul += _vm.Resultat;
                _vm.Resultat = "";
            }
            if (e.Key == Key.Subtract)
            {
                _vm.Resultat += "-";
                _vm.SumCalcul += _vm.Resultat;
                _vm.Resultat = "";
            }
            if (e.Key == Key.Multiply)
            {
                _vm.Resultat += "*";
                _vm.SumCalcul += _vm.Resultat;
                _vm.Resultat = "";
            }
            if (e.Key == Key.Divide)
            {
                _vm.Resultat += "/";
                _vm.SumCalcul += _vm.Resultat;
                _vm.Resultat = "";
            }
            if (e.Key == Key.OemComma)
            {
                _vm.Resultat += ",";
            }
            if (e.Key == Key.D6)
            {
                _vm.Resultat += "-";
            }

            //Opérations complexes
            if (e.Key == Key.Oem3)
            {
                _vm.Resultat += "%";
                _vm.SumCalcul += _vm.Resultat;
                _vm.Resultat = "";
                System.Windows.MessageBox.Show("Ce calcul n'est pas implementée encore.");
                _vm.Resultat = "";
                _vm.SumCalcul = "";
            }
            if (e.Key == Key.D)
            {
                _vm.Resultat += "÷";
                _vm.SumCalcul += _vm.Resultat;
                _vm.Resultat = "";
                System.Windows.MessageBox.Show("Ce calcul n'est pas implementée encore.");
                _vm.Resultat = "";
                _vm.SumCalcul = "";
            }
            if (e.Key == Key.E)
            {
                _vm.Resultat += "^";
                System.Windows.MessageBox.Show("Ce calcul n'est pas implementée encore.");
                _vm.Resultat = "";
                _vm.SumCalcul = "";
            }
            if (e.Key == Key.V)
            {
                _vm.Resultat += "√";
                System.Windows.MessageBox.Show("Ce calcul n'est pas implementée encore.");
                _vm.Resultat = "";
                _vm.SumCalcul = "";
            }
            if (e.Key == Key.L)
            {
                _vm.Resultat += "㏒";
                System.Windows.MessageBox.Show("Ce calcul n'est pas implementée encore.");
                _vm.Resultat = "";
                _vm.SumCalcul = "";
            }
            if (e.Key == Key.T)
            {
                _vm.Resultat += "tan";
                System.Windows.MessageBox.Show("Ce calcul n'est pas implementée encore.");
                _vm.Resultat = "";
                _vm.SumCalcul = "";
            }
            if (e.Key == Key.C)
            {
                _vm.Resultat += "cos";
                System.Windows.MessageBox.Show("Ce calcul n'est pas implementée encore.");
                _vm.Resultat = "";
                _vm.SumCalcul = "";
            }
            if (e.Key == Key.S)
            {
                _vm.Resultat += "sin";
                System.Windows.MessageBox.Show("Ce calcul n'est pas implementée encore.");
                _vm.Resultat = "";
                _vm.SumCalcul = "";
            }

        }
    }
}
