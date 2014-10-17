using System.Collections.Generic;

namespace CheckoutKataApi.WebApp
{
    public static class BasketStore
    {
        private static IDictionary<string, Basket> StoredBaskets { get; set; }

        static BasketStore()
        {
            StoredBaskets = new Dictionary<string, Basket>();
        }

        public static string Add(Basket basket)
        {
            var basketId = basket.GetHashCode().ToString();
            StoredBaskets.Add(basketId, basket);
            return basketId;
        }

        public static Basket Fetch(string basketId)
        {
            return StoredBaskets[basketId];
        }
    }
}