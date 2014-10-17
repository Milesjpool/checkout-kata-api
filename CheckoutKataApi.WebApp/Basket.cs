namespace CheckoutKataApi.WebApp
{
    public class Basket
    {
        public string Items { get; set; }
        public int Price { get; set; }

        public Basket(string items)
        {
            Items = items;
        }
    }
}