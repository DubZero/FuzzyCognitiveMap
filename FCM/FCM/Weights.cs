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
                // Заполняем названия концептов горизонтально
                for(int i = 0; i < CSV_Struct._VertexName.Count; i++)
                    dataGridViewWeights.Columns.Add(CSV_Struct._VertexName[i], CSV_Struct._VertexName[i]); 

                //Заполняем dataGridViewVertex 
                for (int i = 0; i < CSV_Struct._VertexName.Count - 1; i++)
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

        }
    }
}
