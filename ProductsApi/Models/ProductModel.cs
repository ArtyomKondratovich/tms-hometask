namespace ProductsApi.Models
{
    public class ProductModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Weight { get; set; }
        public int Count { get; set; }
        public ProductModel(string? name, string? description, int count, float weight)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (string.IsNullOrWhiteSpace(description)) 
            {
                throw new ArgumentNullException(nameof(description));
            }

            if (weight <= 0f)
            {
                throw new ArgumentOutOfRangeException(nameof(weight));
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            Id = Guid.NewGuid().ToString();
            Name = name;
            Description = description;
            Weight = weight;
            Count = count;
        }
        public override string ToString()
        {
            return $"[Name = {Name}, Description = {Description}, Weight = {Weight}, Count = {Count}]";
        }
    }
}
