using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Prism.Commands;
using Prism.Mvvm;

namespace Wpf_UserControl
{
    class UserControlVM : BindableBase
    {
        public DelegateCommand AddOne { get; set; }
        public int Counter 
        {
            get; 
            set; 
        }
        public UserControlVM()
        {
            AddOne = new DelegateCommand(
                () => 
                Console.WriteLine(Counter)
                );
        }
    }
}
