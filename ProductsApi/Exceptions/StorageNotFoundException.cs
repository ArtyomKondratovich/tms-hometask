namespace ProductsApi.Exceptions
{
    public class StorageNotFoundException : Exception
    {
        public StorageNotFoundException(string storageName) : base($"Storage {storageName} not found!") {}
    }
}
