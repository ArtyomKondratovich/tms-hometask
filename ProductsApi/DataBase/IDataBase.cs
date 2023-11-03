using ProductsApi.Models;

namespace ProductsApi.DataBase
{
    public interface IDataBase
    {
        public List<StorageModel> Read();
        public void Write(List<StorageModel> storages);
    }
}
