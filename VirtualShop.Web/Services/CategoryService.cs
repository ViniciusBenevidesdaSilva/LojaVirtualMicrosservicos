using System.Text.Json;
using VirtualShop.Web.Models;
using VirtualShop.Web.Services.Contracts;

namespace VirtualShop.Web.Services;

public class CategoryService : ICategoryService
{
    private readonly IHttpClientFactory _clienteFactory;
    private readonly JsonSerializerOptions _options;
    private const string apiEndpoint = "/api/categories";

    public CategoryService(IHttpClientFactory clienteFactory)
    {
        _clienteFactory = clienteFactory;
        _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }


    public async Task<IEnumerable<CategoryViewModel>> GetAllCategories()
    {
        var client = _clienteFactory.CreateClient("ProductApi");

        IEnumerable<CategoryViewModel> categories;

        using (var response = await client.GetAsync(apiEndpoint))
        {
            if (!response.IsSuccessStatusCode)
                return null;

            var apiResponse = await response.Content.ReadAsStreamAsync();
            categories = await JsonSerializer.DeserializeAsync<IEnumerable<CategoryViewModel>>(apiResponse, _options);
        }

        return categories;
    }
}
