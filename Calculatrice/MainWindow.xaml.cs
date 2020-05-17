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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Runtime;

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
            this.DataContext = _vm;
            TB_expression.Focus();
            AffichageTest();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            _vm.Resultat += b.Content.ToString();
        }
           

        private static List<string> Decoupage(string calcul)
        {
            //Création d'une List qui récupèrera toutes les différentes parties du calcul
            var expression = new List<string>();

            decimal memoireInt = 0;
            decimal puissance = 1;
            //Lecture du calcul caractères par caractères
            foreach (char c in calcul)
            {
                if(CheckIntUnit(c) == true)
                {
                    if(puissance == 1)
                    {
                        memoireInt = memoireInt * 10;
                        memoireInt += decimal.Parse(c.ToString());
                    }
                    else
                    {
                        memoireInt += (decimal.Parse(c.ToString())) * puissance;
                        puissance /= 10;
                    }                   
                }
                else if((c.ToString()).Contains("."))
                {
                    puissance /= 10;
                }
                else
                {
                    expression.Add(memoireInt.ToString());
                    memoireInt = 0;
                    puissance = 1;
                    expression.Add(c.ToString());
                }
            }
            expression.Add(memoireInt.ToString());
            //On retourne la List avec le découpage du calcul fait
            return expression;
        }

        private static decimal Calcul(List<string> liste)
        {
            string operateur = "";
            decimal num1 = 0;
            decimal num2 = 0;
            foreach (string p in liste)
            {                                
                if(isNumeric(p) == true)
                {
                    if (num1 != 0)
                    {
                        num2 = decimal.Parse(p);
                        num1 = CheckOperateur(num1, num2, operateur);
                    }
                    else num1 = decimal.Parse(p);
                }
                else
                {
                    operateur = p;
                }
            }
            return num1;
        }
               

        private void AffichageTest()
        {
            string test = "5+3.7";
            List<string> liste = new List<string>();
            liste = Decoupage(test);

            foreach (string s in liste)
            {
                MessageBox.Show(s);
            }

            test = (Calcul(liste)).ToString();
            MessageBox.Show("Résultat : " + test);
            
            
        }

        private static Boolean CheckIntUnit(char caractere)
        {
            if (caractere < '0' || caractere > '9')
            {
                return false;
            }

            return true;
        }

        private static Boolean isNumeric(string number)
        {
            decimal i = 0;
            bool result = decimal.TryParse(number, out i);
            return result;
        }       

        private static decimal CheckOperateur(decimal n1, decimal n2, string o)
        {
            switch (o)
            {
                case "+": n1 = n1 + n2; break;
                case "-": n1 = n1 - n2; break;
                case "*": n1 = n1 * n2; break;
                case "/": n1 = n1 / n2; break;
            }
            return n1;
        }
    }
}
