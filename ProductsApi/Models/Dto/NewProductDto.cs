namespace ProductsApi.Models.Dto
{
    public class NewProductDto
    {
        public string StorageName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Weight { get; set; }
        public int Count { get; set; }
    }
}
