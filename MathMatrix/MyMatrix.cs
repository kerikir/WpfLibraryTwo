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

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="rows">Количество строк</param>
        /// <param name="cols">Количество столбцов</param>
        public MyMatrix(int rows, int cols)
        {
            dataArray = new T[rows, cols];
        }

        /// <summary>
        /// Конструктор копирования
        /// </summary>
        /// <param name="matrix">Объект класса</param>
        public MyMatrix(MyMatrix<T> matrix)
        {
            dataArray = new T[matrix.dataArray.GetLength(0), matrix.dataArray.GetLength(1)];
            for (int i = 0; i < matrix.dataArray.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.dataArray.GetLength(1); j++)
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
            for (int i = 0; i < dataArray.GetLength(0); i++)
            {
                for (int j = 0; j < dataArray.GetLength(1); j++)
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
            if((myMatrix1.dataArray.GetLength(0)!= myMatrix2.dataArray.GetLength(0))
                ||(myMatrix1.dataArray.GetLength(1)!= myMatrix2.dataArray.GetLength(1)))
            {
                throw new Exception("Dimension mismatch of matrices!");
            }

            MyMatrix<T> resultMatrix = new MyMatrix<T>(myMatrix1);
            
            //сложение матриц
            for (int i = 0; i < resultMatrix.dataArray.GetLength(0); i++)
            {
                for (int j = 0; j < resultMatrix.dataArray.GetLength(1); j++)
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
            if (myMatrix1.dataArray.GetLength(1) != myMatrix2.dataArray.GetLength(0))
            {
                throw new Exception("Dimension mismatch of matrices!");
            }

            MyMatrix<T> resultMatrix = new MyMatrix<T>(myMatrix1.dataArray.GetLength(0), myMatrix2.dataArray.GetLength(1));

            //умножение матриц
            for (int i = 0; i < resultMatrix.dataArray.GetLength(0); i++)
            {
                for (int j = 0; j < resultMatrix.dataArray.GetLength(1); j++)
                {
                    for (int k = 0; k < myMatrix1.dataArray.GetLength(1); k++)
                    {
                        resultMatrix.dataArray[i, j] += (dynamic)myMatrix1.dataArray[i, k] * (dynamic)myMatrix2.dataArray[k, j];
                    }
                }
            }

            return resultMatrix;
        }
    }

    
}
