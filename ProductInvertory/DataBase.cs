using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace ProductInvertory
{
    internal class DataBase
    {
        private string _path;

        private readonly JsonSerializerOptions options = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
            WriteIndented = true
        };

    public DataBase(string? path)
        {
            if (!File.Exists(path))
            {
                throw new InvalidOperationException();
            }

            _path = path;
        }

        public List<Product> LoadProducts()
        {
            List<Product>? products;

            using (StreamReader r = new(_path))
            {
                string json = r.ReadToEnd();
                products = JsonSerializer.Deserialize<List<Product>>(json, options);
            }

            if (products == null) 
            {
                return new List<Product>();
            }

            return products;
        }

        public void SaveProducts(List<Product> products)
        {
            File.WriteAllText(_path, string.Empty);

            string jsonString = JsonSerializer.Serialize(products, options);

            using StreamWriter outputFile = new(_path);

            outputFile.WriteLine(jsonString);
        }
    }
}
