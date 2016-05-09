using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;


namespace FCM
{
 
    public partial class Report : Form
    {
        public Vertex[] Vertexes { get; set; }
        public WeightMatrix Matr { get; set; }
        public bool isOutputFlag = false;
        public Report()
        {
            InitializeComponent();
            chart.Series.Clear();
        }
        // Заполнение таблицы отчета
        private void Report_Load(object sender, EventArgs e)
        {
            reportTable.Rows.Clear();
            //добавление строк и столбцов
            for (int i = 0; i < Vertexes.Count(); i++)
            {
                reportTable.Columns.Add(Vertexes[i].Name, Vertexes[i].Name);

            }
            for (int j = 0; j < Vertexes[0].Values.Count(); j++)
                if (Vertexes[0].Values.Count() > reportTable.RowCount)
                    reportTable.Rows.Add();

            //вывод значений концептов
            for (int i = 0; i < Vertexes.Count(); i++)
            {
                for (int j = 0; j < Vertexes[0].Values.Count(); j++)
                {
                    reportTable[0, j].Value = j;
                    reportTable[i + 1, j].Value = Math.Round(Vertexes[i].Values[j], 3);
                }
            }


            DrawChartGraph();
        }
        //рисование графика
        void DrawChartGraph()
        {
            List<Series> lstSeries = new List<Series>();
            //добавление элементов
            for (int j = 0; j < reportTable.ColumnCount - 1; j++)
            {
                lstSeries.Add(new Series(Vertexes[j].Name));
                lstSeries[j].ChartType = SeriesChartType.Line;


                for (int i = 0; i < reportTable.RowCount; i++)
                {
                    //задание точек 
                    double x = Convert.ToDouble(reportTable[0, i].Value);
                    double y = Convert.ToDouble(reportTable[j + 1, i].Value);
                    lstSeries[j].Points.AddXY(x, y);
                }
            }
            foreach (Series series in lstSeries)
            {
                //добавление графика
                chart.Series.Add(series);
            }
            for (int i = 0; i < lstSeries.Count(); i++)
            {
                chart.Series[i].BorderWidth = 3;

            }

        }



        // Убрать\Показать линии НЕ выходных значений
        private void chbOutput_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < Vertexes.Count(); i++)
            {
                if (!isOutputFlag)
                {
                    if (!Vertexes[i].isOutput)
                    {
                        chart.Series[i].BorderWidth = 0;
                    }
                }
                else
                {
                    if (!Vertexes[i].isOutput)
                    {
                        chart.Series[i].BorderWidth = 3;
                    }
                }
            }
            isOutputFlag = chbOutput.Checked;
        }
        void RFileSave(Vertex[] ArrVertex)
        {
            SaveFileDialog o = new SaveFileDialog();
            o.Filter = "*.csv|*.csv";
            o.RestoreDirectory = true;
            if (o.ShowDialog(this) == DialogResult.OK)
            {
                FileStream f = new FileStream(o.FileName, FileMode.Create, FileAccess.Write);
                StreamWriter stm = new StreamWriter(f, System.Text.Encoding.GetEncoding(1251));
                stm.Write(ArrVertex[0].Name);
                for (int n = 1; n < ArrVertex.Count(); n++)
                    stm.Write("," + ArrVertex[n].Name);
                stm.Write("\n");

                for (int j = 0; j < ArrVertex[0].Values.Count(); j++)
                {
                    stm.Write(Math.Round(ArrVertex[0].Values[j], 4).ToString().Replace(',', '.'));
                    //запись в файл    
                    for (int i = 1; i < ArrVertex.Count(); i++)
                    {
                        stm.Write("," + Math.Round(ArrVertex[i].Values[j],4).ToString().Replace(',', '.'));
                    }
                    stm.Write("\n");
                }
                stm.Close();
            }
        }
        // Создание dat. файла (текстовый набор данных) для R-studio
        private void toDatFile_Click(object sender, EventArgs e)
        {
            RFileSave(Vertexes);
        }

        private void построитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Graph gr = new Graph())
            {
                gr.ArrVertex = Vertexes;
                gr.Matr = Matr;
                gr.ShowDialog();
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void вФайлДляRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RFileSave(Vertexes);
        }

        private void графикВPngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Диалог выбора имени файла создаем вручную
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "*.png|*.png|*.jpg; *.jpeg|*.jpg;*.jpeg|*.bmp|*.bmp|Все файлы|*.*";



            if (dlg.ShowDialog() == DialogResult.OK)
            {
                // Формат картинки выбирается исходя из имени выбранного файла
                if (dlg.FileName.EndsWith(".png"))
                {
                    chart.SaveImage(dlg.FileName, System.Drawing.Imaging.ImageFormat.Png);
                }
                else if (dlg.FileName.EndsWith(".jpg") || dlg.FileName.EndsWith(".jpeg"))
                {
                    chart.SaveImage(dlg.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                else if (dlg.FileName.EndsWith(".bmp"))
                {
                    chart.SaveImage(dlg.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                }
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
