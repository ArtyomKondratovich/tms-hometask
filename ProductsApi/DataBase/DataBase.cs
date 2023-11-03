using System.Text.Json;
using ProductsApi.Models;

namespace ProductsApi.DataBase
{
    public class DataBase : IDataBase
    {
        private readonly string _source;

        private readonly ILogger<DataBase> _logger;

        public DataBase(string source, ILogger<DataBase> logger)
        {
            if (!File.Exists(source))
            {
                throw new ArgumentException(null, nameof(source));
            }

            _source = source;
            _logger = logger;
        }

        public List<StorageModel> Read()
        {
            return LoadFromJson();
        }

        public void Write(List<StorageModel> storages)
        {
            var json = JsonSerializer.Serialize(storages);

            File.WriteAllText(_source, json);

            _logger.LogInformation($"Save changes to {_source}");
        }

        private List<StorageModel> LoadFromJson()
        {
            var json = File.ReadAllText(_source);

            var storages = JsonSerializer.Deserialize<List<StorageModel>>(json);

            return storages ?? new List<StorageModel>();
        }
    }
}
