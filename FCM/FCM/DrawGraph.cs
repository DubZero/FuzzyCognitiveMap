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
    public class GraphVertex
    {
        public double x, y;

        public GraphVertex(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
    }

    class Edge
    {
        public GraphVertex v1, v2;

        public Edge(GraphVertex v1, GraphVertex v2)
        {
            this.v1 = v1;
            this.v2 = v2;
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
