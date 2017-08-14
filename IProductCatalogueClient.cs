using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ShoppingCart
{
    public interface IProductCatalogueClient
    {
       Task<IEnumerable<ShoppingCartItem>>
      GetShoppingCartItems(int[] productCatalogueIds);
    }
}