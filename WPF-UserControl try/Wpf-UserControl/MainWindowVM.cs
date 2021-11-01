using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using Prism.Commands;
using Prism.Mvvm;

namespace Wpf_UserControl
{
    class MainWindowVM : BindableBase
    {
        private string str;

        public string Str
        {
            get { return str; }
            set { 
                SetProperty(ref str, value); 
            }
        }

        private string myVar="dd";

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        public string MyValue
        {
            get { return myVar; }
            set
            {
                myVar = value;
                Str = value;
                OnPropertyChanged("MyValue");
            }
        }
    }
}
