using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
        private TextBox[,] matrixA;
        private TextBox[,] matrixB;
        private int rowsMatrixA;
        private int rowsMatrixB;
        private int colsMatrixA;
        private int colsMatrixB;

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Отображение матрицы (uniformgrid)
        /// </summary>
        /// <param name="uniformGrid">Таблица</param>
        /// <param name="rows">Количество строк</param>
        /// <param name="cols">Количество столбцов</param>
        /// <returns>Полученную матрицу</returns>
        private TextBox[,] ShowMatrix(UniformGrid uniformGrid, int rows, int cols)
        {
            TextBox[,] tempTextBox = new TextBox[rows, cols];

            uniformGrid.Rows = rows;
            uniformGrid.Columns = cols;
            uniformGrid.Children.Clear();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    tempTextBox[i, j] = new TextBox();
                    tempTextBox[i, j].Text = "0";
                    tempTextBox[i, j].HorizontalContentAlignment = HorizontalAlignment.Center;
                    tempTextBox[i, j].VerticalContentAlignment = VerticalAlignment.Center;
                    uniformGrid.Children.Add(tempTextBox[i, j]);
                }
            }

            return tempTextBox;
        }

        /// <summary>
        /// Обработчкик кнопки создания матрицы A
        /// </summary>
        private void buttonClick_CreateMatrixA(object sender, RoutedEventArgs e)
        {
            rowsMatrixA = Convert.ToInt32(tbRowsMatrixA.Text);
            colsMatrixA = Convert.ToInt32(tbColsMatrixA.Text);
            matrixA = ShowMatrix(ugMatrixA, rowsMatrixA, colsMatrixA);
        }

        /// <summary>
        /// Обработчкик кнопки создания матрицы B
        /// </summary>
        private void buttonClick_CreateMatrixB(object sender, RoutedEventArgs e)
        {
            rowsMatrixB = Convert.ToInt32(tbRowsMatrixB.Text);
            colsMatrixB = Convert.ToInt32(tbColsMatrixB.Text);
            matrixB = ShowMatrix(ugMatrixB, rowsMatrixB, colsMatrixB);
        }
    }
}
