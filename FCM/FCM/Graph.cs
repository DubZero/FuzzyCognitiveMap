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
        //радиус вершины
        double VertRad=40;
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
                x1 = rad * Math.Sin(360 / ArrVertex.Count()) + pictureBox.Width / 2;
                y1 = rad * Math.Cos(360 / ArrVertex.Count()) + pictureBox.Height / 2;
                x2 = rad * Math.Sin(2 * 360 / ArrVertex.Count()) + pictureBox.Width / 2;
                y2 = rad * Math.Cos(2 * 360 / ArrVertex.Count()) + pictureBox.Height / 2;
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
                GraphV[i]=new GraphVertex((rad * Math.Sin(i*360 / ArrVertex.Count()) + pictureBox.Width / 2)-VertRad,(rad * Math.Cos(i*360 / ArrVertex.Count()) + pictureBox.Height / 2)-VertRad);
            }
        }

        private void Graph_Load(object sender, EventArgs e)
        {
            //рисование графа
            GraphV = new GraphVertex[ArrVertex.Count()];
            double radius=calcRad();
            Pen pen = new Pen(Color.Black);
            pen.Width = 2;
            Bitmap bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            Graphics g = Graphics.FromImage(bitmap);
            calcVert(radius);
            for (int i=0;i<GraphV.Count();i++)
            {
                //рисуем круги
                g.DrawEllipse(pen,(float)GraphV[i].x,(float)GraphV[i].y,(float)VertRad,(float)VertRad);
            }
            pictureBox.Image = bitmap;
        }
    }
}
