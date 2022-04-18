using MathMatrix;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
        private TextBox[,] matrixC;
        private int rowsMatrixA;
        private int rowsMatrixB;
        private int colsMatrixA;
        private int colsMatrixB;
        private MyMatrix<int> matrA;
        private MyMatrix<int> matrB;
        private MyMatrix<int> matrC;

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Считывание из матрицы данных в таблицу
        /// </summary>
        /// <param name="textBox">Массив куда запишутся данные</param>
        /// <param name="matrix">Матрица откуда будут считаны данные</param>
        private void FillTextBoxFromMatrix(TextBox[,] textBox, MyMatrix<int> matrix)
        {
            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Cols; j++)
                {  
                    textBox[i, j].Text = matrix[i, j].ToString();
                }
            }
        }

        /// <summary>
        /// Считывание из таблицы данных в матрицу
        /// </summary>
        /// <param name="textBox">Массив данных откуда будут считаны данные</param>
        /// <param name="matrix">Матрица куда запишутся данные</param>
        private void FillMatrixFromTextBox(TextBox[,] textBox, MyMatrix<int> matrix)
        {
            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Cols; j++)
                {
                    matrix[i, j] = Convert.ToInt32(textBox[i, j].Text);
                }
            }
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
            matrA = new MyMatrix<int>(rowsMatrixA, colsMatrixA);
            matrixA = ShowMatrix(ugMatrixA, rowsMatrixA, colsMatrixA);
        }

        /// <summary>
        /// Обработчкик кнопки создания матрицы B
        /// </summary>
        private void buttonClick_CreateMatrixB(object sender, RoutedEventArgs e)
        {
            rowsMatrixB = Convert.ToInt32(tbRowsMatrixB.Text);
            colsMatrixB = Convert.ToInt32(tbColsMatrixB.Text);
            matrB = new MyMatrix<int>(rowsMatrixB, colsMatrixB);
            matrixB = ShowMatrix(ugMatrixB, rowsMatrixB, colsMatrixB);
        }

        /// <summary>
        /// Обработчкик кнопки случайного заполнения матрицы A
        /// </summary>
        private void buttonClick_RandomFillMatrixA(object sender, RoutedEventArgs e)
        {
            buttonClick_CreateMatrixA(sender, e);
            matrA.FillMatrixRandom();
            FillTextBoxFromMatrix(matrixA, matrA);
        }

        /// <summary>
        /// Обработчкик кнопки случайного заполнения матрицы B
        /// </summary>
        private void buttonClick_RandomFillMatrixB(object sender, RoutedEventArgs e)
        {
            buttonClick_CreateMatrixB(sender, e);
            matrB.FillMatrixRandom();
            FillTextBoxFromMatrix(matrixB, matrB);
        }

        /// <summary>
        /// Обработчик нажатия кнопки заполнения матрицы формулой
        /// </summary>
        private void buttonClick_FillFuncMatrixB(object sender, RoutedEventArgs e)
        {
            buttonClick_CreateMatrixB(sender, e);

            Func<int, int, int> func;
            func = (i, j) => i + j;

            matrB.GenerateMatrix(func);
            FillTextBoxFromMatrix(matrixB, matrB);
        }

        /// <summary>
        /// Обработка нажатие кнопки - выполнение арифметических действий с матрицами
        /// </summary>
        private void buttonClick_CalculateMatrixC(object sender, RoutedEventArgs e)
        {
            if ((matrA == null) || (matrB == null))
            {
                MessageBox.Show("Пожалуйста сгенерируйте матрицу!");
            }
            else
            {
                double time;
                DoCalculateMatrix(out time);
                tbTime.Text = time.ToString() + " мс";
            }
        }

        /// <summary>
        /// Обработка нажатие кнопки - сохранение полученной матрицы в файл
        /// </summary>
        private void buttonClick_SaveFileMatrixC(object sender, RoutedEventArgs e)
        {
            string pathFile = "matrixC.csv";
            SaveCsvFile(pathFile);
        }

        /// <summary>
        /// Выполнение расчетов
        /// </summary>
        private void DoCalculateMatrix(out double time)
        {
            Stopwatch stopwatch = new Stopwatch();
            TimeSpan timeSpan;

            stopwatch.Start();
            if (cbxOperation.SelectedIndex==0)
            {
                matrC = matrA + matrB;
            }
            else
            {
                matrC = matrA * matrB;
            }
            stopwatch.Stop();

            if ((matrixC == null)||(ugMatrixC.Rows!=matrC.Rows) || (ugMatrixC.Columns != matrC.Cols))
            {
                matrixC = ShowMatrix(ugMatrixC, matrC.Rows, matrC.Cols);
            }
            FillTextBoxFromMatrix(matrixC, matrC);

            timeSpan = stopwatch.Elapsed;
            time = timeSpan.TotalMilliseconds;
        }

        /// <summary>
        /// Сохранение матрицы в файл
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        private void SaveCsvFile(string path)
        {
            var csv = new StringBuilder();
            string matrixString = "";

            for (int i = 0; i < matrC.Rows; i++)
            {
                for (int j = 0; j < matrC.Cols; j++)
                {
                    matrixString += matrC[i, j].ToString() + "\t";
                }
                csv.AppendLine(matrixString);
                matrixString = "";
            }

            File.WriteAllText(path, csv.ToString());
        }
    }
}