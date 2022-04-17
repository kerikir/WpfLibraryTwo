using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathMatrix
{
    /// <summary>
    /// Класс описывающий матрицу
    /// </summary>
    /// <typeparam name="T">Тип данных</typeparam>
    public class MyMatrix<T> 
    {
        private T[,] dataArray;
        private int rows;
        private int cols;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="rows">Количество строк</param>
        /// <param name="cols">Количество столбцов</param>
        public MyMatrix(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            dataArray = new T[this.rows, this.cols];
        }

        /// <summary>
        /// Конструктор копирования
        /// </summary>
        /// <param name="matrix">Объект класса</param>
        public MyMatrix(MyMatrix<T> matrix)
        {
            this.rows = matrix.rows;
            this.cols = matrix.cols;
            dataArray = new T[matrix.rows, matrix.cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    this.dataArray[i, j] = matrix.dataArray[i, j];
                }
            }
        }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="array">Массив значений</param>
        public MyMatrix(T[,] array)
        {
            rows = array.GetLength(0);
            cols = array.GetLength(1);
            dataArray = array;
        }

        /// <summary>
        /// Перегрузка индексатора
        /// </summary>
        /// <param name="row">Номер строки</param>
        /// <param name="column">Номер столбца</param>
        /// <returns>Значения в матрице по индексу</returns>
        public T this[int row, int column]
        {
            get
            {
                return dataArray[row, column];
            }
            set
            {
                dataArray[row, column] = value;
            }
        }

        /// <summary>
        /// Заполнение значений матрицы
        /// </summary>
        /// <param name="func">Функция заполнения значения матрицы</param>
        public void GenerateMatrix(Func<int,int,T> func)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    dataArray[i, j] = func(i, j);
                }
            }
        }

        /// <summary>
        /// Перегрузка оператора сложения
        /// </summary>
        /// <param name="myMatrix1">Объект класса</param>
        /// <param name="myMatrix2">Объект класса</param>
        /// <returns>Полученный результирующий объект</returns>
        public static MyMatrix<T> operator+(MyMatrix<T> myMatrix1, MyMatrix<T> myMatrix2)
        {
            //проверка размерности
            if ((myMatrix1.rows != myMatrix2.rows) || (myMatrix1.cols != myMatrix2.cols)) 
            {
                throw new Exception("Dimension mismatch of matrices!");
            }

            MyMatrix<T> resultMatrix = new MyMatrix<T>(myMatrix1);
            
            //сложение матриц
            for (int i = 0; i < resultMatrix.rows; i++)
            {
                for (int j = 0; j < resultMatrix.cols; j++)
                {
                    resultMatrix.dataArray[i, j] += (dynamic)myMatrix2.dataArray[i, j];
                }
            }

            return resultMatrix;
        }

        /// <summary>
        /// Перегрузка оператора умножения
        /// </summary>
        /// <param name="myMatrix1">Объект класса</param>
        /// <param name="myMatrix2">Объект класса</param>
        /// <returns>Полученный результирующий объект</returns>
        /// <exception cref="Exception">Ошибка размерности</exception>
        public static MyMatrix<T> operator*(MyMatrix<T> myMatrix1, MyMatrix<T> myMatrix2)
        {
            //проверка размерности
            if (myMatrix1.cols != myMatrix2.rows)
            {
                throw new Exception("Dimension mismatch of matrices!");
            }

            MyMatrix<T> resultMatrix = new MyMatrix<T>(myMatrix1.rows, myMatrix2.cols);

            //умножение матриц
            for (int i = 0; i < resultMatrix.rows; i++)
            {
                for (int j = 0; j < resultMatrix.cols; j++)
                {
                    for (int k = 0; k < myMatrix1.cols; k++)
                    {
                        resultMatrix.dataArray[i, j] += (dynamic)myMatrix1.dataArray[i, k] * (dynamic)myMatrix2.dataArray[k, j];
                    }
                }
            }

            return resultMatrix;
        }

        /// <summary>
        /// Заполнение матрицы случайным образом
        /// </summary>
        public void FillMatrixRandom()
        {
            Random random = new Random();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    dataArray[i, j] = (dynamic)random.Next(1, 100);
                }
            }
        }
    }

    
}
