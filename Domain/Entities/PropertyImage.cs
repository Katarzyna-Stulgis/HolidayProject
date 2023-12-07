namespace Domain.Entities
{
    public class PropertyImage
    {
        public int PropertyImageId { get; set; }
        public Property Property { get; set; }
        public string ImageUrl { get; set; }
    }
}
