using System;
using System.Threading.Tasks;
using Man_RaduLab11.Models;

namespace Man_RaduLab11.Data
{
    public interface IRestService
    {
        Task<List<ShopList>> RefreshDataAsync();
        Task SaveShopListAsync(ShopList item, bool isNewItem);
        Task DeleteShopListAsync(int id);
    }
}

