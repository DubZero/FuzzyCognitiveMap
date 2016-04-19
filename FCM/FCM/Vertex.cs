using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace FCM
{
    public class Vertex
    {
        //Поля
        
        public String Name { get; set; }        
        public String StartValue{ get; set; }
        public List<double> Values { get { return values; } set { values = value; } }        
        public List<double> values = new List<double>();

        // Методы
        // Разделитель колонок из файла CSV
        public void SplitCSV(string line)
        {          
            string[] parts = line.Split(';');  //Разделитель в CSV файле.
            Name = parts[0];
            StartValue = parts[1];
        }
        // Очистка листа для очистки таблицы
        public void Clr()
        {
            values.Clear();
        }

        // Считывание с файа CSV
        public static List<Vertex> ReadFile(string filename)
        {
            List<Vertex> result = new List<Vertex>();
            using (StreamReader sr = new StreamReader(filename))
            {
                string line = sr.ReadLine();
                while ((line = sr.ReadLine()) != null)
                {
                    Vertex p = new Vertex();
                    p.SplitCSV(line);
                    result.Add(p);
                }
            }
            return result;
        }
    }
}
