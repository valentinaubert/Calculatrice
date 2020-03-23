using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculatrice
{
    class MainViewModel : BaseNotifyPropertyChanged
    {
        public string Resultat
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
    }
}
