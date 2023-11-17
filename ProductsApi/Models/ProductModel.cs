namespace ProductsApi.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public float Weight { get; set; }

        public int Count { get; set; }

        public StorageModel Storage { get; set; }

        public override string ToString()
        {
            return $"[Name = {Name}, Description = {Description}, Weight = {Weight}, Count = {Count}]";
        }
    }
}
