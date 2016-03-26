using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        }

        private void btnToWeights_Click(object sender, EventArgs e)
        {
            using (Weights weights = new Weights())
            {                

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
                dataGridViewVertex.Rows.Add(new DataGridViewRow());
            }
            else if(dataGridViewVertex.RowCount == 0) // Исключение при нуле
            {

            }
            else // Удаление строк
            {
                dataGridViewVertex.Rows.Remove(dataGridViewVertex.Rows[dataGridViewVertex.Rows.Count - 1]);
            }            
        }
    }
}
