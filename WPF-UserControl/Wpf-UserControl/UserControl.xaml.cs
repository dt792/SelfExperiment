using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace WpfApplication1
{
    /// <summary>
    /// UserControl1.xaml 的交互逻辑
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }



        public static readonly DependencyProperty TextContentProperty;

        static UserControl1()
        {
            UserControl1.TextContentProperty =
                                       DependencyProperty.Register("TextContent",
                                       typeof(string), typeof(UserControl1));
        }

        public string TextContent
        {
            get
            {
                return (string)GetValue(UserControl1.TextContentProperty);
            }
            set
            {
                SetValue(UserControl1.TextContentProperty, value);
            }
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox box = (TextBox)sender;
            this.SetValue(TextContentProperty, box.Text);
        }
    }
}