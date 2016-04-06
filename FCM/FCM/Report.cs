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

        private void Report_Load(object sender, EventArgs e)
        {
            reportTable.Rows.Clear();
            for (int i = 0; i < Vertexes.Count(); i++)
            {
                reportTable.Columns.Add(Vertexes[i].Name, Vertexes[i].Name);
                
            }
            for(int j = 0; j < Vertexes[0].Values.Count(); j++)
            if(Vertexes.Length > reportTable.RowCount)
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

        public void SaveButton_Click(object sender, EventArgs e)
        {
            
        }
    }
}
