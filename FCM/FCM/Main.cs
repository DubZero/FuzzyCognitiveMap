using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
namespace FCM
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        public WeightMatrix Weights;  // Связи     
        Regex RE = new Regex(@"(^0(,\d{0,})?$|^1(,(0))?$|^z&|^vvl$|^vl$|^l$|^m$|^h$|^vh$|^vvh$|^o$)"); // Регулярное выражение для перевода лингв. значений
        Vertex[] ArrVertex; // Массив вершин

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                List<Vertex> CSV_Struct = new List<Vertex>();
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    // чтение из файла
                    if (fileCheck(openFileDialog1.FileName))
                        CSV_Struct = Vertex.ReadFile(openFileDialog1.FileName);
                    else return;
                }
                //Заполняем dataGridViewVertex 
                VertexNum.Value = CSV_Struct.Count;
                for (int i = 0; i <= CSV_Struct.Count - 1; i++)
                {
                    dataGridViewVertex.Rows[i].Cells[0].Value = CSV_Struct[i].Name;
                    dataGridViewVertex.Rows[i].Cells[1].Value = CSV_Struct[i].StartValue;
                }
            }
            catch
            {
                MessageBox.Show("Ошибка загрузки данных!\n", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Проверка файла с вершинами
        private bool fileCheck(string filename)
        {
            using (StreamReader sr = new StreamReader(filename))
            {
                //сверяем количество концептов
                string line = sr.ReadLine();
                string[] parts = line.Split(';');
                if (parts.Count() == 1) parts = line.Split('\t');
                if (parts.Count() == 2)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Неверный формат входного файла!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        // Переход на окно "Веса"
        private void btnToWeights_Click(object sender, EventArgs e)
        {
            // Создание объектов Вершина из таблицы dataGridViewVertex
            if (dataGridViewVertex.Rows.Count == 0)
            {
                MessageBox.Show("Не задано ни одной вершины!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bool checkSuccess = false;
            if (!CheckMatch())
            {
                ArrVertex = new Vertex[dataGridViewVertex.Rows.Count];
                for (int i = 0; i < dataGridViewVertex.Rows.Count; i++)
                {
                    ArrVertex[i] = new Vertex();
                    try
                    {
                        ArrVertex[i].Name = Convert.ToString(dataGridViewVertex.Rows[i].Cells[0].Value);
                        if (ArrVertex[i].Name == "")
                        {
                            MessageBox.Show("Не задано имя вершины!\nСтрока " + (i + 1).ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK);
                        return;
                    }
                }
            }
            else checkSuccess = true;

            //открытие окна весов
            using (Weights weights_win = new Weights())
            {
                weights_win.VertexName = ArrVertex;//передача списка вершин
                if (checkSuccess) weights_win.Matr = Weights;
                weights_win.FormClosed += (closedSender, closedE) =>
                {
                    Weights = weights_win.Matr;//возвращение матрицы весов
                };
                weights_win.ShowDialog();

            }
        }

        // Перевод лингвистических значений в численные
        public void FromLingToValue()
        {
            // Создание и заполнение Hash(словарей) значений в таблицах
            Dictionary<string, double> Hash = new Dictionary<string, double>();
            String[] LingVal1 = { "z", "vvl", "vl", "l", "m", "h", "vh", "vvh", "o" };
            double[] Value1 = { 0.0, 0.1, 0.2, 0.35, 0.5, 0.65, 0.8, 0.9, 1.0 };
            for (int i = 0; i < LingVal1.Length; i++)
                Hash.Add(LingVal1[i], Value1[i]);
            String[] LingVal2 = { "NegativeVeryStrong", "NegativeStrong", "NegativeMedium", "NegativeWeak", "Zero", "PositiveWeak", "PositiveMedium", "PositiveStrong", "PositiveVeryStrong" };
            double[] Value2 = { -1.0, -0.75, -0.5, -0.25, 0, 0.25, 0.5, 0.75, 1.0 };
            for (int i = 0; i < LingVal2.Length; i++)
                Hash.Add(LingVal2[i], Value2[i]);
            //преобразование весов из строк в double
            for (int i = 0; i < ArrVertex.Count(); i++)
            {
                if (Hash.ContainsKey(ArrVertex[i].StartValue))
                {
                    ArrVertex[i].Values.Add(Hash[ArrVertex[i].StartValue]);
                }
                else
                {
                    ArrVertex[i].Values.Add(double.Parse(ArrVertex[i].StartValue));
                }
                for (int j = 0; j < ArrVertex.Count(); j++)
                {
                    if (Hash.ContainsKey(Weights._Matrix[i, j]))
                    {
                        Weights._MatrixVal[i, j] = Hash[Weights._Matrix[i, j]];
                    }
                    else
                    {
                        Weights._MatrixVal[i, j] = double.Parse(Weights._Matrix[i, j]);
                    }
                }
            }
        }

        // Настройки для расчетов по умолчанию
        public void DefaultSettings()
        {
            Settings.Function = 0;//сигмоида
            Settings.ArgFunc = 1;//первый тип агрумента
            Settings.SaveToXLS = false;
            Settings.AdvancedReport = false;
            Settings.k1 = 0.5M;
            Settings.k2 = 0.5M;
            Settings.feedback = 0.5M;
        }

        // Переход на окно настроек
        private void btnSettings_Click(object sender, EventArgs e)
        {
            using (Set set = new Set())
            {
                set.ShowDialog();
            }
        }

        //проверка соответствия содержимого матрицы весов и списка концептов
        bool CheckMatch()
        {
            if (ArrVertex == null) return false;
            if (ArrVertex.Count() == dataGridViewVertex.Rows.Count)
            {
                for (int i = 0; i < ArrVertex.Count(); i++)
                    if (ArrVertex[i].Name != dataGridViewVertex.Rows[i].Cells[0].Value.ToString())
                        return false;
                return true;
            }
            return false;
        }

        // Аргументы функции для расчета
        private double argument(int i, int t)
        {
            double sum = 0;
            //расчет значения для первого аргумента
            if (Settings.ArgFunc == 1)
            {
                for (int j = 0; j < ArrVertex.Count(); j++)
                {
                    if (i != j)
                        sum += ArrVertex[j].Values[t - 1] * Weights._MatrixVal[j, i];
                }
                return (double)(Settings.k1) * sum + (double)Settings.k2 * (ArrVertex[i].Values[t - 1]);
            }
            //расчет значения для аргумента второго типа
            else
            {
                for (int j = 0; j < ArrVertex.Count(); j++)
                {
                    if (i != j)
                        sum += ArrVertex[j].Values[t - 1] * Weights._MatrixVal[j, i];
                }
                return sum + (double)Settings.feedback * (ArrVertex[i].Values[t - 1]);
            }
            // return 0;
        }

        // Варианты функций для расчета
        private double func(double x)
        {
            if (Settings.Function == 0)// Сигмоидальная функция
            {
                return 1 / (1 + Math.Exp(-x));
            }
            else if (Settings.Function == 1)//гауссова функция
            {
                return Math.Exp(-(x * x) / 2);
            }
            else return 0;
        }

        // Переход к окну Анализ
        private void btnCalc_Click(object sender, EventArgs e)
        {
            double x;
            bool check = false;
            try
            {
                //замена точек на запятые 
                for (int i = 0; i < dataGridViewVertex.Columns.Count - 1; i++)
                {
                    for (int j = 0; j < dataGridViewVertex.Rows.Count; j++)
                    {
                        dataGridViewVertex[i, j].Value = dataGridViewVertex[i, j].Value.ToString().Replace('.', ',');
                    }
                }
                //проверка ввода
                if (dataGridViewVertex.Rows.Count == 0)
                {
                    MessageBox.Show("Не задано ни одной вершины!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (Weights == null)
                {
                    MessageBox.Show("Не заданы веса!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (Weights._Matrix == null)
                    {
                        MessageBox.Show("Не заданы веса!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                //проеврка введения весов
                if (!CheckMatch())
                {
                    MessageBox.Show("Данные о вершинах изменились!\nНеобходимо задать веса заново", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                for (int i = 0; i < ArrVertex.Count(); i++)
                {
                    ArrVertex[i].Values.Clear();
                }
                for (int i = 0; i < dataGridViewVertex.Rows.Count; i++)
                {
                    Match MatchObj = RE.Match(dataGridViewVertex.Rows[i].Cells[1].Value.ToString());
                    if (MatchObj.Success)
                        ArrVertex[i].StartValue = dataGridViewVertex.Rows[i].Cells[1].Value.ToString();
                    else
                    {
                        MessageBox.Show("Неверные данные!\nСтрока " + (i + 1).ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка чтения данных из формы!\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //преобразование весов в числа
            FromLingToValue();
            for (int j = 1; !check; j++)
            {
                check = true;
                for (int i = 0; i < ArrVertex.Count(); i++)
                {//вычисление значений функции
                    x = argument(i, j);
                    ArrVertex[i].Values.Add(func(x));
                    if (Math.Abs(ArrVertex[i].Values[j] - ArrVertex[i].Values[j - 1]) > 0.001)
                        check = false;
                }
            }
            //выделение как выходной
            for (int i = 0; i < ArrVertex.Count(); i++)
            {
                ArrVertex[i].isOutput = Convert.ToBoolean(dataGridViewVertex[2, i].Value);
            }
            //сохранение в файл
            if (Settings.SaveToXLS)
            {
                SaveReport(ArrVertex);
            }
            using (Report report = new Report())
            {
                //передача управления окну отчета
                report.Vertexes = ArrVertex;
                report.Matr = Weights;
                report.FormClosed += (closedSender, closedE) =>
                {
                    foreach (Vertex vert in ArrVertex)
                        vert.Clr();//возвращение матрицы весов
                };
                report.ShowDialog();
            }
        }

        // Фунция для сохранения отчета
        void SaveReport(Vertex[] ArrVertex)
        {
            SaveFileDialog o = new SaveFileDialog();
            o.Filter = "*.csv|*.csv";
            o.RestoreDirectory = true;
            if (o.ShowDialog(this) == DialogResult.OK)
            {
                FileStream f = new FileStream(o.FileName, FileMode.Create, FileAccess.Write);
                StreamWriter stm = new StreamWriter(f, System.Text.Encoding.GetEncoding(1251));
                for (int n = 0; n < ArrVertex.Count(); n++)
                    stm.Write(ArrVertex[n].Name + ";");
                stm.Write("\n");
                if (Settings.AdvancedReport)

                    for (int j = 0; j < ArrVertex[0].Values.Count(); j++)
                    {
                        //запись в файл    
                        for (int i = 0; i < ArrVertex.Count(); i++)
                        {
                            stm.Write(ArrVertex[i].Values[j] + ";");
                        }
                        stm.Write("\n");
                    }
                else
                    for (int i = 0; i < ArrVertex.Count(); i++)
                        stm.Write(ArrVertex[i].Values[ArrVertex[0].Values.Count() - 1] + ";");
                stm.Close();
            }
        }

        // Создание и удаление вершин
        private void VertexNum_ValueChanged(object sender, EventArgs e)
        {
            if (dataGridViewVertex.RowCount < VertexNum.Value)// Добавление строк
            {
                while (dataGridViewVertex.RowCount < VertexNum.Value)
                    dataGridViewVertex.Rows.Add(new DataGridViewRow());
            }
            else if (dataGridViewVertex.RowCount == 0) // Исключение при нуле
            {

            }
            else // Удаление строк
            {
                while (dataGridViewVertex.RowCount > VertexNum.Value)
                    dataGridViewVertex.Rows.Remove(dataGridViewVertex.Rows[dataGridViewVertex.Rows.Count - 1]);
            }
        }

        // Заполнение настроек расчета по умолчанию
        private void Main_Load(object sender, EventArgs e)
        {
            DefaultSettings();
        }

        // Сохранить заполненую таблицу вершин в файл CSV
        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog o = new SaveFileDialog();
            o.Filter = "*.csv|*.csv";
            o.RestoreDirectory = true;
            if (o.ShowDialog(this) == DialogResult.OK)
            {
                FileStream f = new FileStream(o.FileName, FileMode.Create, FileAccess.Write);
                StreamWriter stm = new StreamWriter(f, System.Text.Encoding.GetEncoding(1251));
                stm.Write("name" + ";" + "value" + "\n");
                for (int j = 0; j < dataGridViewVertex.Rows.Count; j++)
                {
                    stm.Write(dataGridViewVertex.Rows[j].Cells[0].Value + ";" + dataGridViewVertex.Rows[j].Cells[1].Value + "\n");

                }
                stm.Close();
            }
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Help help = new Help())
            {

                help.ShowDialog();
            }
        }
    }
}
