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
            AffichageTest();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            _vm.Resultat += b.Content.ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
        

        private static List<string> Decoupage(string calcul)
        {
            //Création d'une List qui récupèrera toutes les différentes parties du calcul
            var expression = new List<string>();

            int memoireInt = 0;
            //Lecture du calcul caractères par caractères
            foreach (char c in calcul)
            {
                if(CheckIntUnit(c) == true)
                {
                    memoireInt = memoireInt * 10;
                    memoireInt += int.Parse(c.ToString());

                }
                else
                {
                    expression.Add(memoireInt.ToString());
                    memoireInt = 0;
                    expression.Add(c.ToString());
                }
            }
            expression.Add(memoireInt.ToString());
            //On retourne la List avec le découpage du calcul fait
            return expression;
        }

        private static int Calcul(List<string> liste)
        {
            int test = 0;
            string operateur = "+";
            foreach (string p in liste)
            {
                if(isNumeric(p) == true)
                {
                    
                }
                else
                {
                    operateur = p;
                }
            }
            return 0;
        }

        private void AffichageTest()
        {
            string test = "54+37-54654";
            List<string> liste = new List<string>();
            liste = Decoupage(test);
            foreach(string s in liste)
            {
                MessageBox.Show(s);
            }
            
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
            int i = 0;
            bool result = int.TryParse(number, out i);
            return result;
        }

        private static string CheckOperateur(string operateur, string ajout, int resultat)
        {
            string op = operateur;
            switch(op)
            {
                case "+": resultat += int.Parse(ajout);break;
                case "-": resultat -= int.Parse(ajout); break;
                case "*": resultat *= int.Parse(ajout); break;
                case "/": resultat /= int.Parse(ajout); break;
            }
            return op;
        }


    }
}
