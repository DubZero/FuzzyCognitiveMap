using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCM
{
    public class Settings
    {
        // Вид функции
        public int Function { get; set; }
        // Вид аргумента функции
        public int ArtFunc { get; set; }
        // Сохранение в XLS
        public bool SaveToXLS { get; set; }
        // Расширенный отчет
        public bool AndvancedReport { get; set; }        
    }
}
