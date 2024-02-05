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

    public async Task<ProductStatistics> GetProductStatisticsByEANAsync(string EAN)
    {
        string apiUrl = $"https://localhost:7204/ProductStatistics/{EAN}";
        try
        {
            var response = await _client.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var product = JsonConvert.DeserializeObject<ProductStatistics>(content);
                return product;
            }
            else
            {
                return null;
            }
        }
        catch (Exception ex)
        {
            throw new ApplicationException($"Error fetching data from API: {ex.Message}", ex);
        }
    }

    public async Task AddProductToWarehouseAsync(Warehouse warehouseDto)
    {
        try
        {
            string apiUrl = "https://localhost:7204/Warehouse/AddWarehouseItem";
            var json = JsonConvert.SerializeObject(warehouseDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(apiUrl, content);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Product added to warehouse successfully");
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new ApplicationException($"Error adding product to warehouse: {errorContent}");
            }
        }
        catch (Exception ex)
        {
            throw new ApplicationException($"Error adding product to warehouse: {ex.Message}", ex);
        } 
    }
    public async Task<IEnumerable<WarehouseProduct>> GetAllWarehouseProductsAsync()
    {
        string apiUrl = $"https://localhost:7204/Warehouse/GetAllWarehouseItems";
        try
        {
            var response = await _client.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var products = JsonConvert.DeserializeObject<IEnumerable<WarehouseProduct>>(content);
                return products;
            }
            else
            {
                return Enumerable.Empty<WarehouseProduct>();
            }
        }
        catch (Exception ex)
        {
            throw new ApplicationException($"Error fetching data from API: {ex.Message}", ex);
        }
    }
    public async Task<bool> UpdateWarehouseNumberAsync(int warehouseId, string newWarehouseNumber)
    {
        var apiUrl = $"https://localhost:7204/Warehouse/UpdateWarehouseNumber/{warehouseId}";
        try
        {
            var updateObject = new
            {
                WarehouseId = warehouseId,
                NewWarehouseNumber = newWarehouseNumber
            };

            var json = JsonConvert.SerializeObject(updateObject);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PutAsync(apiUrl, content);

            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            throw new ApplicationException($"Error sending data to API: {ex.Message}", ex);
        }
    }
}
