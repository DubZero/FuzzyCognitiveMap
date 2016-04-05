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
    public partial class Report : Form
    {
        public Vertex[] Vertexes { get; set; }
        public Report()
        {
            InitializeComponent();
        }

        private void Report_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < Vertexes.Count(); i++)
            {
                reportTable.Columns.Add(Vertexes[i].Name, Vertexes[i].Name);
                
            }
            for(int j = 0; j < Vertexes[0].Values.Count(); j++)
            reportTable.Rows.Add();
            for(int i=0;i<Vertexes.Count();i++)
            {
                for (int j = 0; j < Vertexes[0].Values.Count(); j++)
                {
                    reportTable[0, j].Value = j;
                    reportTable[i + 1, j].Value = Math.Round(Vertexes[i].Values[j],3);
                }
            }
            
        }
    }
}
