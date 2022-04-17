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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonClick_CreateMatrixA(object sender, RoutedEventArgs e)
        {
            //int rows = Convert.ToInt32(tbRowsMatrixA.Text);
            //int cols = Convert.ToInt32(tbColsMatrixA.Text);

            //ugMatrixA.Height = rows;
            //ugMatrixA.Width = cols;

            //int[,] array = new int[rows, cols];
            //TextBlock textBlock = new TextBlock();

            //ugMatrixA.Children.Add(textBlock);
        }
    }
}
