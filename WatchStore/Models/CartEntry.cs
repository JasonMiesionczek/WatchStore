namespace WatchStore.Models
{
    public class CartEntry
    {
        public int Id { get; set; }
        public string ProductID { get; set; }
        public int Quantity { get; set; }
        public int TotalCost { get; set; }
    }
}
