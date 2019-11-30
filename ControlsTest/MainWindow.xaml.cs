using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace tank_test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TestVM tvm;
        public MainWindow()
        {
            InitializeComponent();
            TestVM tvm = new TestVM();
            this.DataContext = tvm;
          
        }

        private void changevalue(double d)
        {
            tvm = (TestVM)(DataContext);
            tvm.CurrentValue = d;
            while (true)
            {
                Thread.Sleep(100);
                tvm.CurrentValue += .00001;

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tvm = (TestVM)(DataContext);
            tvm.CurrentValue = Convert.ToDouble(ValueTextBox.Text); 
        }

       
    }
}
