using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart
{
    public class ShoppingCart
    {
        private readonly HashSet<ShoppingCartItem> items = new HashSet<ShoppingCartItem>();

        public int UserId { get; }
        public IEnumerable<ShoppingCartItem> Items => items;

        public ShoppingCart(int userId)
        {
            UserId = userId;
        }

        public void AddItems(
            IEnumerable<ShoppingCartItem> shoppingCartItems,
            IEventStore eventStore)
        {
            foreach (var item in shoppingCartItems)
                if (items.Add(item))
                    eventStore.Raise(
                        "ShoppingCartItemAdded",
                        new {UserId, item});
        }

        public void RemoveItems(
            int[] productCatalogueIds,
            IEventStore eventStore)
        {
            items.RemoveWhere(i => productCatalogueIds.Contains(i.ProductCatalogueId));
            eventStore.Raise("ShoppingCartItemRemoved",null);
        }
    }
}
