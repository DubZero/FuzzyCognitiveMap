using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCM
{
    class Vertex
    {
        //Поля
        private String _name; // Название вершины
        public String _Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private double _startValue;
        public double _StartValue
        {
            get { return _startValue; }
            set { _startValue = value; }
        }
        private List<double> _values;
        public List<double> _Values
        {
            get { return _values; }
        }
        //конструкторы
        public Vertex(string Name, double StartValue)
        {
            _name = Name;
            _startValue = StartValue;
        }
    }
}
