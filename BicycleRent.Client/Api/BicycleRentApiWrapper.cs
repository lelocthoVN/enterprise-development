namespace BicycleRent.Client.Api;

public class BicycleRentApiWrapper(IConfiguration configuration) : IBicycleRentApiWrapper
{
    private readonly BicycleRentApi _client = new(configuration["OpenApi:ServerUrl"], new HttpClient());

    public async Task<ICollection<BicycleDto>> GetAllBicycles() => await _client.BicycleAllAsync();
    public async Task<ICollection<TopBicycleDto>> GetTopFiveBicycles() => await _client.TopFiveBicyclesAsync();
    public async Task<CustomerDto> PostCustomer(CustomerDto customer) => await _client.CustomerPOSTAsync(customer);
    public async Task<CustomerDto> GetCustomerById(int id) => await _client.CustomerGETAsync(id);
    public async Task<ICollection<TopCustomerDto>> GetTopCustomers() => await _client.TopCustomersAsync();
    public async Task<ICollection<BicycleTypeDto>> GetAllBicycleTypes() => await _client.BicycleTypeAllAsync();
    public async Task<string> DeleteRental(int id) => await _client.RentalDELETEAsync(id);
    public async Task<ICollection<RentalDto>> GetAllRentals() => await _client.RentalAllAsync();
    public async Task<ICollection<BicycleWithTypeNameDto>> GetAvailableBicycles() => await _client.AvailableBicyclesAsync(); 
    public async Task<ICollection<BicycleWithTypeNameDto>> GetBicyclesByType(int bicycleTypeId) => await _client.BicyclesByTypeAsync(bicycleTypeId);
}
