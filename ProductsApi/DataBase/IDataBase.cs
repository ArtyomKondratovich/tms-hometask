using ProductsApi.Models;

namespace ProductsApi.DataBase
{
    public interface IDataBase
    {
        public List<Storage> Read();
        public void Write(List<Storage> storages);
    }
}
