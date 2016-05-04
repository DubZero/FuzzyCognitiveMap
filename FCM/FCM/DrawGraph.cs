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
    //класс вершины графа
    public class GraphVertex
    {
        public double x, y;

        public GraphVertex(double x, double y)
        {
            //координаты
            this.x = x;
            this.y = y;
        }
    }

    //класс ребер графа
    public class Edge
    {
        public GraphVertex v1, v2;
        public double w;
        public Edge(GraphVertex v1, GraphVertex v2,double weight)
        {
            //координаты и вес
            this.v1 = v1;
            this.v2 = v2;
            this.w = weight;
        }
        public Edge(double x1,double y1,double x2,double y2, double weight)
        {
            this.v1=new GraphVertex(x1, y1);
            this.v2=new GraphVertex(x2, y2);
            this.w = weight;
        }
    }
    class DrawGraph
    {
        Bitmap bitmap;

        public Bitmap GetBitmap()
        {
            return bitmap;
        }
    }
}
