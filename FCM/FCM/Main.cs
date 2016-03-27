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



        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                List<Vertex> CSV_Struct = new List<Vertex>();
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    // чтение из файла
                    CSV_Struct = Vertex.ReadFile(openFileDialog1.FileName);
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

        private void btnToWeights_Click(object sender, EventArgs e)
        {
            // Создание объектов Вершина из таблицы dataGridViewVertex
            Vertex[] ArrVertex = new Vertex[dataGridViewVertex.Rows.Count];
            for (int i = 0; i< dataGridViewVertex.Rows.Count;i++)
            {
                ArrVertex[i] = new Vertex();
                try
                {
                    ArrVertex[i].Name = Convert.ToString(dataGridViewVertex.Rows[i].Cells[0].Value);
                    ArrVertex[i].StartValue = Convert.ToDouble(dataGridViewVertex.Rows[i].Cells[1].Value);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }


            using (Weights weights = new Weights())
            {
                weights.VertexName = ArrVertex;
                weights.ShowDialog();
            }
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
        
    }
}
