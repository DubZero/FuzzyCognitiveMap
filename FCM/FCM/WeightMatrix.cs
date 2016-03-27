using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FCM
{
    class WeightMatrix
    {
        //Поля
        private double[,] _matrix;
        public double[,] _Matrix
        {
            get { return _matrix; }
            set { _matrix = value; }
        }

        private int n;//количество строк матрицы
        public int N
        {
            get { return n; }

        }

        private int m;//количество столбцов матрицы
        public int M
        {
            get { return m; }

        }
        public static string[] VertexName { get; set; }
        
        //конструкторы
        public WeightMatrix(double[,] matrix)
        {
            _matrix = matrix;
            n = matrix.GetLength(0);
            m = matrix.GetLength(1);
        }
        public WeightMatrix(WeightMatrix matrix)
        {
            _matrix = matrix._matrix;
            n = matrix.n;
            m = matrix.m;
        }
        public WeightMatrix(int N, int M)
        {
            _matrix = new double[N, M];
            n = N;
            m = M;
        }
        public WeightMatrix()
        {
            _matrix = new double[0, 0];
            n = 0;
            m = 0;
        }

        //умножение матриц
        public static WeightMatrix operator *(WeightMatrix mat1, WeightMatrix mat2)
        {
            if (mat1.m != mat2.n) throw new Exception("Матрицы нельзя перемножить");
            WeightMatrix result = new WeightMatrix(mat1.n, mat2.m);

            for (int i = 0; i < mat1.n; i++)
            {
                for (int j = 0; j < mat2.m; j++)
                {
                    for (int k = 0; k < mat2.n; k++)
                    {
                        result._matrix[i, j] += mat1._matrix[i, k] * mat2._matrix[k, j];
                    }
                }
            }
            return result;
        }

        // Методы

        // разделитель колонок из файла CSV
        public void SplitWeightCSV(string line, int i)
        {
            string[] parts = line.Split(';');  //Разделитель в CSV файле.
            for (int j = 1; i<parts.Length;i++)            {
                
                _matrix[i,j] = Convert.ToDouble(parts[1]);
            }
        }
        // Считывает первую строчку с названиями концептов
        public void ReadVertexNames(string line)
        {
            string[] parts = line.Split(';');  //Разделитель в CSV файле.
            for(int i = 1; i < parts.Length; i++)
            {
                VertexName[i] = parts[i];
            }
        }

        public static WeightMatrix ReadFile(string filename)
        {            
            using (StreamReader sr = new StreamReader(filename))
            {
                string line = sr.ReadLine();
                if(line!= null)
                {

                }
                WeightMatrix matrix = new WeightMatrix(VertexName.Length,VertexName.Length);
                while ((line = sr.ReadLine()) != null)
                {
                    int i = 1;                    
                    matrix.SplitWeightCSV(line,i);                    
                    i++;
                }
                return matrix;
            }
            
        }

    }
}
