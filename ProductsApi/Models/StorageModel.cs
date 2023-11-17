namespace ProductsApi.Models
{
    public class StorageModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ProductModel> Products { get; set; }

    }
}
