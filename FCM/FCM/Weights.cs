using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

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
        // Рег. выражение для проверки значений связей
        Regex RE = new Regex(@"(^-?(0)(,\d{0,})?$|^-?1(,(0))?$|^NegativeVeryStrong$|^NegativeStrong$|^NegativeMedium$|^NegativeWeak$|^Zero$|^PositiveWeak$|^PositiveMedium$|^PositiveStrong$|^PositiveVeryStrong$)");
        // Считывание данных через файл
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
                if (CSV_Struct._VertexName.Count() == VertexName.Count())
                {
                    for(int i=0;i<VertexName.Count();i++)
                    {
                        if(CSV_Struct._VertexName[i] != VertexName[i].Name)
                        {
                            MessageBox.Show("Неверный входной файл!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    dataGridViewWeights.Columns.Clear();
                    dataGridViewWeights.Rows.Clear();
                    dataGridViewWeights.Columns.Add("name", "Имя");
                    // Заполняем названия концептов горизонтально
                    for (int i = 0; i < CSV_Struct._VertexName.Count; i++)
                        dataGridViewWeights.Columns.Add(CSV_Struct._VertexName[i], CSV_Struct._VertexName[i]);

                    //Заполняем dataGridViewVertex 
                    for (int i = 0; i < CSV_Struct._VertexName.Count; i++)
                    {
                        dataGridViewWeights.Rows.Add();
                        dataGridViewWeights.Rows[i].Cells[0].Value = CSV_Struct._VertexName[i]; // заполнение имен концептов вертикально
                        for (int j = 1; j <= CSV_Struct._VertexName.Count; j++)
                            dataGridViewWeights.Rows[i].Cells[j].Value = CSV_Struct._Matrix[i, j - 1];
                    }
                }
                else
                {
                    MessageBox.Show("Неверный входной файл!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки данных!\n"+ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Сохраниение данных в экземпляре
        private void btnSaveInput_Click(object sender, EventArgs e)
        {
            string[,] _Matrix = new string[dataGridViewWeights.Rows.Count, dataGridViewWeights.Rows.Count];
            try
            {
                for (int i = 1; i <= dataGridViewWeights.Rows.Count; i++)
                {
                    //замена точек на запятые
                for (int j = 0; j < dataGridViewWeights.Rows.Count; j++)
                {
                    dataGridViewWeights[i, j].Value = dataGridViewWeights[i, j].Value.ToString().Replace('.', ',');
                }
                }


                for (int i = 0; i < dataGridViewWeights.Rows.Count; i++)
                {
                    for (int j = 1; j <= dataGridViewWeights.Rows.Count; j++)
                    {
                        //заполнение матрицы веосв из таблицы
                        Match Obj = RE.Match(dataGridViewWeights.Rows[i].Cells[j].Value.ToString());
                        if(Obj.Success)
                        _Matrix[i, j - 1] = dataGridViewWeights.Rows[i].Cells[j].Value.ToString();
                        else
                        {
                            MessageBox.Show("Неверные данные!\nСтрока " + i.ToString()+" Столбец "+j.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка загрузки данных!\n"+ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            };
            Matr = new WeightMatrix(dataGridViewWeights.Rows.Count, dataGridViewWeights.Rows.Count);
            Matr._Matrix = _Matrix;
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
            //заполнение таблицы весов
            if (Matr != null)
            {
                for (int i = 0; i < Matr.N; i++)
                {
                    for (int j = 1; j <= Matr.N; j++)
                    {
                        dataGridViewWeights.Rows[i].Cells[j].Value = Matr._Matrix[i, j - 1];
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //сохранение восов в файл
            SaveFileDialog o = new SaveFileDialog();
            o.Filter = "*.csv|*.csv";
            o.RestoreDirectory = true;
            if (o.ShowDialog(this) == DialogResult.OK)
            {
                FileStream f = new FileStream(o.FileName, FileMode.Create, FileAccess.Write);
                StreamWriter stm = new StreamWriter(f, System.Text.Encoding.GetEncoding(1251));
                //запись имен концептов
                for(int i=0;i<dataGridViewWeights.ColumnCount;i++)
                {
                    stm.Write(dataGridViewWeights.Columns[i].HeaderText);
                    if(i != dataGridViewWeights.ColumnCount-1) stm.Write(";");
                }
                stm.Write('\n');
                //запись весов
                for (int j = 0; j < dataGridViewWeights.Rows.Count; j++)
                {
                    for (int i = 0; i < dataGridViewWeights.ColumnCount; i++)
                    {
                        stm.Write(dataGridViewWeights.Rows[j].Cells[i].Value);
                        if (i != dataGridViewWeights.ColumnCount - 1) stm.Write(";");
                    }
                    stm.Write('\n');
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
