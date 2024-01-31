using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Windows;
using WPF_App_For_Shop.Model;

namespace WPF_App_For_Shop;
public class ApiService
{
    private HttpClient _client;

    public ApiService()
    {
        _client = new HttpClient();
    }

    public async Task<IEnumerable<ProductInformation>> GetAllProductsAsync()
    {
        string apiUrl = $"https://localhost:7204/Price/GetAllProducts";
        try
        {
            var response = await _client.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var products = JsonConvert.DeserializeObject<IEnumerable<ProductInformation>>(content);
                return products;
            }
            else
            {
                return Enumerable.Empty<ProductInformation>();
            }
        }
        catch (Exception ex)
        {
            throw new ApplicationException($"Error fetching data from API: {ex.Message}", ex);
        }
    }

    public async Task AddProductAsync(ProductInformation product)
    {
        string apiUrl = "https://localhost:7204/Price/AddProduct";
        try
        {
            var json = JsonConvert.SerializeObject(product);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(apiUrl, content);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Product added successfully");
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new ApplicationException($"Error adding product: {errorContent}");
            }
        }
        catch (Exception ex)
        {
            throw new ApplicationException($"Error adding product: {ex.Message}", ex);
        }
    }

    public async Task ChangeProductPriceAsync(ProductNewPrice productNewPrice)
    {
        try
        {
            string apiUrl = "https://localhost:7204/Price/ChangeProductPrice";
            var json = JsonConvert.SerializeObject(productNewPrice);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(apiUrl, content);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Price changed successfully");
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new ApplicationException($"Error changing price: {errorContent}");
            }
        }
        catch (Exception ex)
        {
            throw new ApplicationException($"Error changing price: {ex.Message}", ex);
        }
    }

    public ProductStatistics GetProductStatisticsByEAN(string EAN)
    {
        //TODO: Implement
        throw new NotImplementedException();
    }
}
