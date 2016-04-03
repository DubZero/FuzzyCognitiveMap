using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FCM
{
    public partial class Weights : Form
    {
        public Vertex[] VertexName { get; set; }
        public WeightMatrix Matr { get; set; }
        public Weights()
        {
            InitializeComponent();
        }

        

        private void открытьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                WeightMatrix CSV_Struct = new WeightMatrix();
                if (openFileDialog2.ShowDialog() == DialogResult.OK)
                {
                    // чтение из файла                    
                    CSV_Struct = WeightMatrix.ReadFile(openFileDialog2.FileName);
                }
                dataGridViewWeights.Columns.Clear();
                dataGridViewWeights.Rows.Clear();
                dataGridViewWeights.Columns.Add("name","Имя");
                // Заполняем названия концептов горизонтально
                for (int i = 0; i < CSV_Struct._VertexName.Count; i++)
                   dataGridViewWeights.Columns.Add(CSV_Struct._VertexName[i], CSV_Struct._VertexName[i]); 

                //Заполняем dataGridViewVertex 
                for (int i = 0; i < CSV_Struct._VertexName.Count; i++)
                {
                    dataGridViewWeights.Rows.Add();
                    dataGridViewWeights.Rows[i].Cells[0].Value = CSV_Struct._VertexName[i]; // заполнение имен концептов вертикально
                    for (int j = 1; j <= CSV_Struct._VertexName.Count;j++)
                        dataGridViewWeights.Rows[i].Cells[j].Value = CSV_Struct._Matrix[i,j-1];                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки данных!\n"+ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveInput_Click(object sender, EventArgs e)
        {
            Matr = new WeightMatrix(dataGridViewWeights.Rows.Count, dataGridViewWeights.Rows.Count);
            try {
                for (int i = 0; i < dataGridViewWeights.Rows.Count; i++)
                {
                    for (int j = 1; j <= dataGridViewWeights.Rows.Count; j++)
                        Matr._Matrix[i, j - 1] = dataGridViewWeights.Rows[i].Cells[j].Value.ToString();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка загрузки данных!\n"+ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);   
            };
            this.Close();
        }

        private void Weights_Load(object sender, EventArgs e)
        {
            // Заполняем названия концептов горизонтально
            for (int i = 0; i < VertexName.Count(); i++)
                dataGridViewWeights.Columns.Add(VertexName[i].Name, VertexName[i].Name);
            //Заполняем dataGridViewVertex 
            for (int i = 0; i < VertexName.Count(); i++)
            {
                dataGridViewWeights.Rows.Add();
                dataGridViewWeights.Rows[i].Cells[0].Value = VertexName[i].Name; // заполнение имен концептов вертикально
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
