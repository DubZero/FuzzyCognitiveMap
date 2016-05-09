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
        Bitmap bitmap,graph;
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
            Pen OutputPen = new Pen(Color.Red);
            Pen pen2 = new Pen(Color.Black);
            pen2.StartCap =System.Drawing.Drawing2D.LineCap.Triangle;
            Brush br=Brushes.Black;
            pen.Width = 5;
            OutputPen.Width = 5;
            pen2.Width = 1.5f;
            bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            graph=new Bitmap(pictureBox.Image);
            Graphics g = Graphics.FromImage(graph);
            calcVert(radius);
            Brush wh = Brushes.White;
            createEdges();
            for(int i=0;i<Edges.Count();i++)
            {
                g.DrawLine(pen2, (float)(Edges[i].v1.x + VertRad), (float)(Edges[i].v1.y + VertRad), (float)(Edges[i].v2.x + VertRad), (float)(Edges[i].v2.y + VertRad));
            }

            for (int i=0;i<GraphV.Count();i++)
            {
                //рисуем круги
                if(ArrVertex[i].isOutput)
                    g.DrawEllipse(OutputPen, (float)GraphV[i].x, (float)GraphV[i].y, (float)VertRad * 2, (float)VertRad * 2);
                else
                    g.DrawEllipse(pen,(float)GraphV[i].x,(float)GraphV[i].y,(float)VertRad*2,(float)VertRad*2);
                g.FillEllipse(wh, (float)GraphV[i].x, (float)GraphV[i].y, (float)VertRad * 2, (float)VertRad * 2);
                g.DrawString("C"+(i+1).ToString(), new Font("Microsoft Sans Serif", 8.5F, FontStyle.Regular),br, (float)(GraphV[i].x+VertRad/4), (float)(GraphV[i].y+VertRad/4));
            }                     
            pictureBox.Image = graph;
        }
        private bool isBackEdge(GraphVertex v1,GraphVertex v2)
        {
            for (int i = 0; i < Edges.Count(); i++)
            {
                if (Edges[i].v1.x == v2.x&& Edges[i].v1.y == v2.y && Edges[i].v2.x == v1.x&& Edges[i].v2.y == v1.y)
                    return true;
            }
            return false;
        }
        //создание граней графа
        private void createEdges()
        {
            for (int i = 0; i < Matr.N; i++)
            {
                for (int j = 0; j < Matr.M; j++)
                {
                    if (Matr._MatrixVal[i, j] != 0)
                    {
                        if (isBackEdge(GraphV[i], GraphV[j]))
                            Edges.Add(new Edge(GraphV[i].x+7, GraphV[i].y + 7, GraphV[j].x + 7, GraphV[j].y + 7, Matr._MatrixVal[i, j]));
                        else Edges.Add(new Edge(GraphV[i], GraphV[j], Matr._MatrixVal[i, j]));
                    }
                }
            }
        }
        //определение попадания в грань
        private Edge lineDetection(int x,int y)
        {
            for(int i=0;i<Edges.Count();i++)
            {
                double x1 = (Edges[i].v1.x+VertRad);
                double x2 = (Edges[i].v2.x+VertRad);
                double y1 = (Edges[i].v1.y+VertRad);
                double y2 = (Edges[i].v2.y+VertRad);
                if(Math.Abs(x1-x2)<2)
                {
                    x1 += 1;
                    x2 -= 1;
                }
                if (Math.Abs(y1 - y2) < 2)
                {
                    y1 += 1;
                    y2 -= 1;
                }
                //double k = ((y1 - y2) / (x1 - x2));
                if ((Math.Abs((y1-y2)*x+(x2-x1)*y+(x1*y2-y1*x2))<1500)&&((x <= x1&&x>= x2)|| (x >= x1 && x <= x2))&&((y >= y1 && y <= y2) || (y <= y1 && y >= y2)))
                {
                    return Edges[i];
                }
            }
            return null;
        }


        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Help help = new Help())
            {

                help.ShowDialog();
            }
        }

        private void сохранитьВpngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ДИалог выбора имени файла создаем вручную
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "*.png|*.png|*.jpg; *.jpeg|*.jpg;*.jpeg|*.bmp|*.bmp|Все файлы|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                // Формат картинки выбирается исходя из имени выбранного файла
                if (dlg.FileName.EndsWith(".png"))
                {
                    pictureBox.Image.Save(dlg.FileName, System.Drawing.Imaging.ImageFormat.Png);
                }
                else if (dlg.FileName.EndsWith(".jpg") || dlg.FileName.EndsWith(".jpeg"))
                {
                    pictureBox.Image.Save(dlg.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                else if (dlg.FileName.EndsWith(".bmp"))
                {
                    pictureBox.Image.Save(dlg.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                }
            }
        }

        //обработка клика по рисунку
        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            Edge ed = lineDetection(e.X,e.Y);

            bitmap = new Bitmap(graph);
            Graphics g = Graphics.FromImage(bitmap);
            Pen pen = new Pen(Color.Red,5f);
            pen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            pen.StartCap = System.Drawing.Drawing2D.LineCap.RoundAnchor;
            //выделение линии
            Brush br = Brushes.Green;
            if (ed != null)
            {                                
                g.DrawLine(pen, (float)(ed.v1.x+VertRad), (float)(ed.v1.y+VertRad), (float)(ed.v2.x+VertRad), (float)(ed.v2.y+VertRad));
                g.DrawString(ed.w.ToString(), new Font("Microsoft Sans Serif", 16F, FontStyle.Regular), br,e.X,e.Y);              
            }
            pictureBox.Image = bitmap;
        }
    }
}
