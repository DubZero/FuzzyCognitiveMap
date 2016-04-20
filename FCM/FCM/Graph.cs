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
    public partial class Graph : Form
    {
        public Graph()
        {
            InitializeComponent();
        }

        public Vertex[] ArrVertex { get; set; }

        public GraphVertex[] GraphV;
        public List<Edge> Edges = new List<Edge>();
        public WeightMatrix Matr { get; set; }
        //радиус вершины
        double VertRad=20;
    //вычисление адиуса большой окружности
        double calcRad()
        {
            double rad = 20;
            double VertDiag;
            VertDiag= Math.Sqrt(VertRad * VertRad + VertRad * VertRad);
            double x1, y1,x2,y2,y,x,k=0;
            //проверка каого-то правила с полудиагональю 
            while (k < VertDiag*4)
            {
                rad *= 1.2;
                //нахождение оптимального радиуса
                x1 = rad * Math.Sin(2 * Math.PI / ArrVertex.Count()) + pictureBox.Width / 2;
                y1 = rad * Math.Cos(2 * Math.PI / ArrVertex.Count()) + pictureBox.Height / 2;
                x2 = rad * Math.Sin(2 * 2 * Math.PI / ArrVertex.Count()) + pictureBox.Width / 2;
                y2 = rad * Math.Cos(2 * 2 * Math.PI / ArrVertex.Count()) + pictureBox.Height / 2;
                x = Math.Abs(x1) - Math.Abs(x2);
                y = Math.Abs(y1) - Math.Abs(y2);
                k = Math.Sqrt(x * x + y * y);
            }
            return rad;
        }
        //вычисление вершин окружностей
        void calcVert(double rad)
        {
            for(int i=0;i<ArrVertex.Count();i++)
            {
                GraphV[i]=new GraphVertex((rad * Math.Sin(i*2*Math.PI / ArrVertex.Count()) + pictureBox.Width / 2)-VertRad,(rad * Math.Cos(i*2*Math.PI / ArrVertex.Count()) + pictureBox.Height / 2)-VertRad);
            }
        }

        private void Graph_Load(object sender, EventArgs e)
        {
            //рисование графа
            GraphV = new GraphVertex[ArrVertex.Count()];
            double radius=calcRad();
            Pen pen = new Pen(Color.Black);
            Pen pen2 = new Pen(Color.Black);
            pen2.StartCap =System.Drawing.Drawing2D.LineCap.Triangle;
            Brush br=Brushes.Black;
            pen.Width = 3;
            pen2.Width = 1;
            Bitmap bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            Graphics g = Graphics.FromImage(bitmap);
            calcVert(radius);
            Brush wh = Brushes.White;
            for(int i = 0;i < Matr.N;i++)
            {
                for (int j=0;j<Matr.M;j++)
                {
                    if (Matr._MatrixVal[i, j] != 0)
                    {
                        Edges.Add(new Edge(GraphV[i],GraphV[j]));
                        g.DrawLine(pen2, (float)(GraphV[i].x + VertRad), (float)(GraphV[i].y + VertRad), (float)(GraphV[j].x + VertRad), (float)(GraphV[j].y + VertRad));
                    }
                }
            }
            for (int i=0;i<GraphV.Count();i++)
            {
                //рисуем круги
                g.DrawEllipse(pen,(float)GraphV[i].x,(float)GraphV[i].y,(float)VertRad*2,(float)VertRad*2);
                g.FillEllipse(wh, (float)GraphV[i].x, (float)GraphV[i].y, (float)VertRad * 2, (float)VertRad * 2);
                g.DrawString("C"+(i+1).ToString(), new Font("Microsoft Sans Serif", 9F, FontStyle.Regular),br, (float)(GraphV[i].x+VertRad/2), (float)(GraphV[i].y+VertRad/2));
            }
            pictureBox.Image = bitmap;
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {

        }
    }
}
