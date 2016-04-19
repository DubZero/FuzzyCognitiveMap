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
using ZedGraph;
using System.Threading;

namespace FCM
{
    public partial class Report : Form
    {
        public Vertex[] Vertexes { get; set; }
        public Report()
        {
            InitializeComponent();
        }
        // Заполнение таблицы отчета
        private void Report_Load(object sender, EventArgs e)
        {
            reportTable.Rows.Clear();
            for (int i = 0; i < Vertexes.Count(); i++)
            {
                reportTable.Columns.Add(Vertexes[i].Name, Vertexes[i].Name);
                
            }
            for(int j = 0; j < Vertexes[0].Values.Count(); j++)
            if(Vertexes[0].Values.Count() > reportTable.RowCount)
                reportTable.Rows.Add();
            for(int i=0;i<Vertexes.Count();i++)
            {
                for (int j = 0; j < Vertexes[0].Values.Count(); j++)
                {
                    reportTable[0, j].Value = j;
                    reportTable[i + 1, j].Value = Math.Round(Vertexes[i].Values[j],3);
                }
            }
            DrawGraph();
            
        }
        // Отрисовка графика
        public void DrawGraph()
        {
            GraphPane pane = zedGraph.GraphPane;
            pane.Title = "Analysis Chart";
            pane.CurveList.Clear();

            pane.XAxis.Title = "Time";
            pane.YAxis.Title = "Nodes value";
            PointPairList list = new PointPairList();
            for (int j = 1; j < reportTable.ColumnCount; j++)
            {
                for (int i = 0; i < reportTable.RowCount; i++)
                {

                    double x = Convert.ToDouble(reportTable[0, i].Value);
                    double y = Convert.ToDouble(reportTable[j, i].Value);
                    list.Add(x, y);
                }
                // Слип для генерации новых чисел P.S.(сид генерации берется из времени)
                Random randomGen = new Random();
                int RedComponent = randomGen.Next(255);
                Thread.Sleep(4);
                int GreenComponent = randomGen.Next(255);
                Thread.Sleep(4);
                int BlueComponent = randomGen.Next(255);
                Thread.Sleep(4);
                Color randomColor = Color.FromArgb(RedComponent, GreenComponent, BlueComponent);
                LineItem myCurve = pane.AddCurve(Vertexes[j-1].Name, list, randomColor, SymbolType.None);
                myCurve.Line.Width = 2.0f;
                list.Clear();
                
            }
            
            zedGraph.AxisChange();
            zedGraph.Invalidate();
        }
        // Сохранение графика в файл
        public void SaveButton_Click(object sender, EventArgs e)
        {
            // ДИалог выбора имени файла создаем вручную
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "*.png|*.png|*.jpg; *.jpeg|*.jpg;*.jpeg|*.bmp|*.bmp|Все файлы|*.*";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                // Получием панель по ее индексу
                GraphPane pane = zedGraph.GraphPane;

                // Получаем картинку, соответствующую панели
                Bitmap bmp = pane.Image;

                // Сохраняем картинку средствами класса Bitmap
                // Формат картинки выбирается исходя из имени выбранного файла
                if (dlg.FileName.EndsWith(".png"))
                {
                    bmp.Save(dlg.FileName, ImageFormat.Png);
                }
                else if (dlg.FileName.EndsWith(".jpg") || dlg.FileName.EndsWith(".jpeg"))
                {
                    bmp.Save(dlg.FileName, ImageFormat.Jpeg);
                }
                else if (dlg.FileName.EndsWith(".bmp"))
                {
                    bmp.Save(dlg.FileName, ImageFormat.Bmp);
                }
                else
                {
                    bmp.Save(dlg.FileName);
                }
            }
        }
    }
}
