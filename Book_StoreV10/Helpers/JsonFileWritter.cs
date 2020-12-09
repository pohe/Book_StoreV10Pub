using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Book_StoreV10.Models;
using Newtonsoft.Json;

namespace Book_StoreV10
{
    public class JsonFileWritter
    {
        public static void WriteToJsonBook(List<Book> books, string JsonFileName)
        {
            string output = JsonConvert.SerializeObject(books, Formatting.Indented);
            File.WriteAllText(JsonFileName, output);
        }

        internal static void WriteToJsonOrder(List<Order> orders, string filePath)
        {
            string output = JsonConvert.SerializeObject(orders, Formatting.Indented);
            File.WriteAllText(filePath, output);
        }
    }
}
