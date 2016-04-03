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
// dataGridViewVertex - таблица вершин
// VertexNumber - количество вершин
namespace FCM
{
    public partial class Main : Form
    {
        public Main()
        {            
            InitializeComponent();            
        }

        public WeightMatrix Weights;       
        Regex RE = new Regex(@"(^\d{1,}(.|,)?\d{0,}$|^z&|^vvl$|^vl$|^l$|^m$|^h$|^vh$|^vvh$|^o$)");  
        
       
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
                VertexNum.Value= CSV_Struct.Count;
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
        private bool fileCheck(string filename)
        {
            using (StreamReader sr = new StreamReader(filename))
            {
                string line = sr.ReadLine();
                string[] parts = line.Split(';');
                if(parts.Count()==2)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Неверный формат входного файла!","Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
        private void btnToWeights_Click(object sender, EventArgs e)
        {
            // Создание объектов Вершина из таблицы dataGridViewVertex
            if(dataGridViewVertex.Rows.Count==0)
            {
                MessageBox.Show("Не задано ни одной вершины!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Vertex[] ArrVertex = new Vertex[dataGridViewVertex.Rows.Count];
            for (int i = 0; i< dataGridViewVertex.Rows.Count;i++)
            {
                ArrVertex[i] = new Vertex();
                try {
                    ArrVertex[i].Name = Convert.ToString(dataGridViewVertex.Rows[i].Cells[0].Value);
                    if(ArrVertex[i].Name=="")
                    {
                        MessageBox.Show("Не задано имя вершины!\nСтрока " + (i+1).ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    Match MatchObj = RE.Match(dataGridViewVertex.Rows[i].Cells[1].Value.ToString());
                    if (MatchObj.Success)
                        ArrVertex[i].StartValue = dataGridViewVertex.Rows[i].Cells[1].Value.ToString();
                    else
                    {
                        MessageBox.Show("Неверные данные!\nСтрока " + (i+1).ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,"Ошибка!", MessageBoxButtons.OK);
                    return;
                }
            }

            //открытие окна весов
            using (Weights weights_win = new Weights())
            {
                weights_win.VertexName = ArrVertex;//передача списка вершин
                weights_win.FormClosed += (closedSender, closedE) =>
                {
                    Weights = weights_win.Matr;//возвращение матрицы весов
                };
                weights_win.ShowDialog();

            }
        }

        public void DefaultSettings()
        {
            Settings.Function = 1;
            Settings.ArgFunc = 1;
            Settings.SaveToXLS = false;
            Settings.AdvancedReport = false;
            Settings.k1 = 0.5M;
            Settings.k2 = 0.5M;
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            using (Set set = new Set())
            {
                set.ShowDialog();
            }
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            using (Report report = new Report())
            {

                report.ShowDialog();
            }
        }
        // Создание и удаление вершин
        private void VertexNum_ValueChanged(object sender, EventArgs e)
        {
            if(dataGridViewVertex.RowCount < VertexNum.Value)// Добавление строк
            {
                while(dataGridViewVertex.RowCount < VertexNum.Value)
                dataGridViewVertex.Rows.Add(new DataGridViewRow());
            }
            else if(dataGridViewVertex.RowCount == 0) // Исключение при нуле
            {

            }
            else // Удаление строк
            {
                while (dataGridViewVertex.RowCount > VertexNum.Value)
                    dataGridViewVertex.Rows.Remove(dataGridViewVertex.Rows[dataGridViewVertex.Rows.Count - 1]);
            }            
        }

        private void Main_Load(object sender, EventArgs e)
        {
            DefaultSettings();
        }
    }
}
