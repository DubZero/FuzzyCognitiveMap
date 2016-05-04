using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FCM
{
    //матрица весов
    public class WeightMatrix
    {
        //Поля
        private String[,] _matrix; // матрицы значений связей концептов
        public String[,] _Matrix
        {
            get { return _matrix; }
            set { _matrix = value; }
        }
        private double[,] _matrixVal;
        public double[,] _MatrixVal
        {
            get { return _matrixVal; }
            set { _matrixVal = value; }
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
        private List<string> _vertexName=new List<string>();
        public List<string> _VertexName { get { return _vertexName; } set { _vertexName = value; } }
        
        // Конструкторы
        public WeightMatrix(String[,] matrix)
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
            _matrix = new String[N, M];
            _matrixVal = new double[N,M];
            n = N;
            m = M;
        }
        public WeightMatrix()
        {
            _matrix = new String[0, 0];
            n = 0;
            m = 0;
        }
        // Методы

        // разделитель колонок из файла CSV
        public void SplitWeightCSV(string line, int i)
        {
            string[] parts = line.Split(';');  //Разделитель в CSV файле.
            for (int j = 1; j<parts.Length;j++)            {
                
                _matrix[i-1,j-1] = parts[j];
            }
        }
        // Считывает первую строчку с названиями концептов
        private void ReadVertexNames(string line)
        {
            string[] parts = line.Split(';');  //Разделитель в CSV файле.
            for(int i = 1; i < parts.Length; i++)
            {                
                _vertexName.Add(parts[i]);
            }
        }
        // Считывание значений связей из файла CSV
        public static WeightMatrix ReadFile(string filename)
        {            
            using (StreamReader sr = new StreamReader(filename))
            {                
                string line = sr.ReadLine();

                WeightMatrix temp = new WeightMatrix();
                if (line!= null)
                {
                    temp.ReadVertexNames(line);
                }
                WeightMatrix matrix = new WeightMatrix(temp._vertexName.Count,temp._vertexName.Count);
                matrix._vertexName = temp._vertexName;
                for (int i = 1; (line = sr.ReadLine()) != null; i++)                                                       
                    matrix.SplitWeightCSV(line,i);                              
                return matrix;
            }
            
        }

    }
}
