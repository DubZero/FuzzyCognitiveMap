using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCM
{
    public static class Settings
    {
        // Вид функции
        public static int Function { get; set; }
        // Вид аргумента функции
        public static int ArgFunc { get; set; }
        // Сохранение в XLS
        public static bool SaveToXLS { get; set; }
        // Расширенный отчет
        public static bool AdvancedReport { get; set; }
        // Коэфиценты при 1-ом виде аргумента
        public static decimal k1 { get; set; }
        public static decimal k2 { get; set; }
        public static decimal feedback { get; set; }
    }
}
