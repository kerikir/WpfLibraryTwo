using System;
using Xunit;
using MathMatrix;
using System.Collections;

namespace MathMatrixTest
{
    public class MyMatrixTest
    {
        [Fact]
        public void GenerateMatrixInt_RowPlusCol_Correctly()
        {
            //Arrange
            MyMatrix<int> myMatrix = new MyMatrix<int>(5,5);
            int[,] arrayMatrix = new int[5, 5];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    arrayMatrix[i, j] = i + j;
                }
            }
            int[,] arrayMyMatrix = new int[5, 5];

            //Acl
            myMatrix.GenerateMatrix((i, j) => i + j);
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    arrayMyMatrix[i, j] = myMatrix[i, j];
                }
            }
            

            //Assert
            Assert.Equal(arrayMatrix,arrayMyMatrix);
        }

        [Fact]
        public void GenerateMatrixFloat_RowPlusColPlusHalf_Correctly()
        {
            //Arrange
            MyMatrix<float> myMatrix = new MyMatrix<float>(5, 5);
            float[,] arrayMatrix = new float[5, 5];
            float[,] arrayMyMatrix = new float[5, 5];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    arrayMatrix[i, j] = i + j + 0.5f;
                }
            }

            //Acl
            myMatrix.GenerateMatrix((i, j) => i + j + 0.5f);
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    arrayMyMatrix[i, j] = myMatrix[i, j];
                }
            }


            //Assert
            Assert.Equal(arrayMatrix, arrayMyMatrix);
        }

        [Fact]
        public void GenerateMatrixDouble_RowPlusColPlusHalf_Correctly()
        {
            //Arrange
            MyMatrix<double> myMatrix = new MyMatrix<double>(5, 5);
            double[,] arrayMatrix = new double[5, 5];
            double[,] arrayMyMatrix = new double[5, 5];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    arrayMatrix[i, j] = i + j + 0.5;
                }
            }

            //Acl
            myMatrix.GenerateMatrix((i, j) => i + j + 0.5);
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    arrayMyMatrix[i, j] = myMatrix[i, j];
                }
            }


            //Assert
            Assert.Equal(arrayMatrix, arrayMyMatrix);
        }

        [Fact]
        public void OperatorPlus_SumDoubleMatrix_Correctly()
        {
            //Arrange
            MyMatrix<double> myMatrixA = new MyMatrix<double>(5, 5);
            myMatrixA.GenerateMatrix((i, j) => i + j + 0.5);
            MyMatrix<double> myMatrixB = new MyMatrix<double>(5, 5);
            myMatrixB.GenerateMatrix((i, j) => i + j + 1.0);
            MyMatrix<double> myMatrixC;
            double[,] arrayMatrix = new double[5, 5];
            double[,] arrayResultMatrix = new double[5, 5];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    arrayMatrix[i, j] = 2 * i + 2 * j + 1.5;
                }
            }

            //Acl
            myMatrixC = myMatrixA + myMatrixB;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    arrayResultMatrix[i, j] = myMatrixC[i, j];
                }
            }

            //Assert
            Assert.Equal(arrayMatrix, arrayResultMatrix);
        }

        [Fact]
        public void OperatorPlus_SumFloatMatrix_Correctly()
        {
            //Arrange
            MyMatrix<float> myMatrixA = new MyMatrix<float>(5, 5);
            myMatrixA.GenerateMatrix((i, j) => i + j + 0.5f);
            MyMatrix<float> myMatrixB = new MyMatrix<float>(5, 5);
            myMatrixB.GenerateMatrix((i, j) => i + j + 1.0f);
            MyMatrix<float> myMatrixC;
            float [,] arrayMatrix = new float[5, 5];
            float[,] arrayResultMatrix = new float[5, 5];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    arrayMatrix[i, j] = 2 * i + 2 * j + 1.5f;
                }
            }

            //Acl
            myMatrixC = myMatrixA + myMatrixB;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    arrayResultMatrix[i, j] = myMatrixC[i, j];
                }
            }

            //Assert
            Assert.Equal(arrayMatrix, arrayResultMatrix);
        }

        [Fact]
        public void OperatorPlus_SumIntMatrix_Correctly()
        {
            //Arrange
            MyMatrix<int> myMatrixA = new MyMatrix<int>(5, 5);
            myMatrixA.GenerateMatrix((i, j) => i + j);
            MyMatrix<int> myMatrixB = new MyMatrix<int>(5, 5);
            myMatrixB.GenerateMatrix((i, j) => i + j + 1);
            MyMatrix<int> myMatrixC;
            int[,] arrayMatrix = new int[5, 5];
            int[,] arrayResultMatrix = new int[5, 5];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    arrayMatrix[i, j] = 2 * i + 2 * j + 1;
                }
            }

            //Acl
            myMatrixC = myMatrixA + myMatrixB;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    arrayResultMatrix[i, j] = myMatrixC[i, j];
                }
            }

            //Assert
            Assert.Equal(arrayMatrix, arrayResultMatrix);
        }

        [Fact]
        public void OperatorMultiply_MultiplicationIntMatrix_Correctly()
        {
            //Arrange
            MyMatrix<int> myMatrixA = new MyMatrix<int>(4, 4);
            myMatrixA.GenerateMatrix((i, j) => i + j);
            MyMatrix<int> myMatrixB = new MyMatrix<int>(4, 4);
            myMatrixB.GenerateMatrix((i, j) => i + j);
            MyMatrix<int> myMatrixC;
            int[,] arrayA = new int[4, 4];
            int[,] arrayB = new int[4, 4];
            int[,] arrayC = new int[4, 4];
            int[,] arrayResultMatrix = new int[4, 4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    arrayA[i, j] = i+j;
                    arrayB[i, j] = i + j;
                }
            }

            //Acl
            myMatrixC = myMatrixA * myMatrixB;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    for (int k = 0; k < 4; k++)
                    {
                        arrayC[i, j] += arrayA[i, k] * arrayB[k, j];
                    }
                }
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    arrayResultMatrix[i, j] = myMatrixC[i, j];
                }
            }

            //Assert
            Assert.Equal(arrayC, arrayResultMatrix);
        }

        [Fact]
        public void OperatorMultiply_MultiplicationFloatMatrix_Correctly()
        {
            //Arrange
            MyMatrix<float> myMatrixA = new MyMatrix<float>(4, 4);
            myMatrixA.GenerateMatrix((i, j) => i + j + 0.5f);
            MyMatrix<float> myMatrixB = new MyMatrix<float>(4, 4);
            myMatrixB.GenerateMatrix((i, j) => i + j + 1.0f);
            MyMatrix<float> myMatrixC;
            float[,] arrayA = new float[4, 4];
            float[,] arrayB = new float[4, 4];
            float[,] arrayC = new float[4, 4];
            float[,] arrayResultMatrix = new float[4, 4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    arrayA[i, j] = i + j + 0.5f;
                    arrayB[i, j] = i + j + 1.0f;
                }
            }

            //Acl
            myMatrixC = myMatrixA * myMatrixB;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    for (int k = 0; k < 4; k++)
                    {
                        arrayC[i, j] += arrayA[i, k] * arrayB[k, j];
                    }
                }
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    arrayResultMatrix[i, j] = myMatrixC[i, j];
                }
            }

            //Assert
            Assert.Equal(arrayC, arrayResultMatrix);
        }

        [Fact]
        public void OperatorMultiply_MultiplicationDoubleMatrix_Correctly()
        {
            //Arrange
            MyMatrix<double> myMatrixA = new MyMatrix<double>(4, 4);
            myMatrixA.GenerateMatrix((i, j) => i + j + 0.5);
            MyMatrix<double> myMatrixB = new MyMatrix<double>(4, 4);
            myMatrixB.GenerateMatrix((i, j) => i + j + 1.0);
            MyMatrix<double> myMatrixC;
            double[,] arrayA = new double[4, 4];
            double[,] arrayB = new double[4, 4];
            double[,] arrayC = new double[4, 4];
            double[,] arrayResultMatrix = new double[4, 4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    arrayA[i, j] = i + j + 0.5;
                    arrayB[i, j] = i + j + 1.0;
                }
            }

            //Acl
            myMatrixC = myMatrixA * myMatrixB;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    for (int k = 0; k < 4; k++)
                    {
                        arrayC[i, j] += arrayA[i, k] * arrayB[k, j];
                    }
                }
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    arrayResultMatrix[i, j] = myMatrixC[i, j];
                }
            }

            //Assert
            Assert.Equal(arrayC, arrayResultMatrix);
        }

        [Fact]
        public void OperatorMultiply_IncorrectSize_Exception()
        {
            //Arrange
            MyMatrix<double> myMatrixA = new MyMatrix<double>(4, 4);
            myMatrixA.GenerateMatrix((i, j) => i + j + 0.5);
            MyMatrix<double> myMatrixB = new MyMatrix<double>(5, 5);
            myMatrixB.GenerateMatrix((i, j) => i + j + 1.0);

            //Acl

            //Assert
            Assert.Throws<Exception>(() => myMatrixA * myMatrixB);
        }

        [Fact]
        public void OperatorPlus_IncorrectSize_Exception()
        {
            //Arrange
            MyMatrix<double> myMatrixA = new MyMatrix<double>(4, 4);
            myMatrixA.GenerateMatrix((i, j) => i + j + 0.5);
            MyMatrix<double> myMatrixB = new MyMatrix<double>(5, 5);
            myMatrixB.GenerateMatrix((i, j) => i + j + 1.0);

            //Acl

            //Assert
            Assert.Throws<Exception>(() => myMatrixA + myMatrixB);
        }

        [Fact]
        public void FillMatrixRandom_FillRandomNumber_NotEqualZero()
        {
            //Arrange
            MyMatrix<int> myMatrix = new MyMatrix<int>(5, 5);
            int[,] array = new int[5, 5];
            int[,] matrixArray = new int[5, 5];

            //Acl
            myMatrix.FillMatrixRandom();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    matrixArray[i, j] = myMatrix[i,j];
                }
            }

            //Assert
            Assert.NotEqual(array, matrixArray);
        }
    }
}
