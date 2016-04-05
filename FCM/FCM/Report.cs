using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

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

        private void DrawGraph()
        {
            GraphPane pane = zedGraph.GraphPane;
            
            pane.CurveList.Clear();


            PointPairList list = new PointPairList();
            for (int j = 1; j < reportTable.ColumnCount; j++)
            {
                for (int i = 0; i < reportTable.RowCount; i++)
                {

                    double x = Convert.ToDouble(reportTable[0, i].Value);
                    double y = Convert.ToDouble(reportTable[j, i].Value);
                    list.Add(x, y);
                }

                LineItem myCurve = pane.AddCurve("1", list, Color.Red, SymbolType.Plus);
                myCurve.Line.Width = 3.0f;
                list.Clear();
            }
            
            zedGraph.AxisChange();
            zedGraph.Invalidate();
        }
        
    }
}
