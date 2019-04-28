namespace OtherPerspectivesWebApp.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public string CartId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}