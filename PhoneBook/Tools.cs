using CsvHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace PhoneBook
{
    internal class Tools
    {
        public static class CSVHelper
        {
            public static void CSVWriter(ItemCollection Persons)
            {
                string fileName = "report_" + DateTime.Now.ToString("yyyy-mm-dd HH:mm:ss").Replace(":", "_") + ".csv";
                using (var writer = new StreamWriter(fileName))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(Persons);
                    MessageBox.Show("Файл " + fileName + " сформирован.", "Результат", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
    }
}
