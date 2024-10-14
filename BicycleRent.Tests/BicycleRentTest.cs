namespace BicycleRent.Tests;

public class BicycleRentTest(BicycleRentData fixture) : IClassFixture<BicycleRentData>
{
    private readonly BicycleRentData _fixture = fixture;

    /// <summary>
    /// Info about all sport bicycles
    /// </summary>
    [Fact]
    public void TestSelectSportBicycles()
    {
        var sportBicycle =
            (from type in _fixture.Types
             where type.TypeName == "Sport"
             join bike in _fixture.Bicycles on type.Id equals bike.TypeId
             select bike).ToList();

        Assert.Equal(4, sportBicycle.Count); // Adjust the expected count according to your data
    }

    /// <summary>
    /// Info about all customers who have ever rented mountain bicycles, ordered by full name
    /// </summary>
    [Fact]
    public void TestMountainBicycleCustomers()
    {
        var mountainCustomers =
            (from type in _fixture.Types
             where type.TypeName == "Mountain"
             join bike in _fixture.Bicycles on type.Id equals bike.TypeId
             join rent in _fixture.Rentals on bike equals rent.Bicycle
             join client in _fixture.Customers on rent.Customer equals client
             orderby client.FullName
             select client).Distinct().ToList();

        Assert.Equal(6, mountainCustomers.Count); // Adjust the expected count according to your data
        Assert.Equal("Agamedes Rouche", mountainCustomers.First().FullName); // Adjust the expected first name
    }

    /// <summary>
    /// Summed rental time for all bicycle types
    /// </summary>
    [Fact]
    public void TestBicycleTimeRents()
    {
        var typeRentTime =
            (from type in _fixture.Types
             join bike in _fixture.Bicycles on type.Id equals bike.TypeId
             join rent in _fixture.Rentals on bike equals rent.Bicycle
             group rent by type.TypeName into grouped
             select new
             {
                 TypeName = grouped.Key,
                 TotalTime = grouped.Sum(r => (r.End - r.Begin).TotalSeconds)
             }).ToList();

        Assert.NotEmpty(typeRentTime);
        Assert.Equal(75360, typeRentTime.First().TotalTime, tolerance: 10); // Adjust the expected value
    }

    /// <summary>
    /// Info about customers who rented bicycles the most times
    /// </summary>
    [Fact]
    public void TestCustomerMaxRents()
    {
        var rentCountedCustomers =
            (from rent in _fixture.Rentals
             group rent by rent.Customer into grouped
             select new
             {
                 Customer = grouped.Key,
                 RentCount = grouped.Count()
             }).ToList();

        var mostRentClients =
            (from client in rentCountedCustomers
             where client.RentCount == rentCountedCustomers.Max(c => c.RentCount)
             select client.Customer).ToList();

        Assert.NotEmpty(mostRentClients);
    }

    /// <summary>
    /// Info about five most rented bicycles
    /// </summary>
    [Fact]
    public void TestTopFiveBicycles()
    {
        var bicycleRent =
            (from rent in _fixture.Rentals
             group rent by rent.Bicycle into grouped
             orderby grouped.Count() descending
             select new
             {
                 Bicycle = grouped.Key,
                 RentCount = grouped.Count(),
             }).Take(5).ToList();

        Assert.Equal(5, bicycleRent.Count);
    }

    /// <summary>
    /// Info about max, min, and average rental time
    /// </summary>
    [Fact]
    public void TestRentalTime()
    {
        var max = _fixture.Rentals.Max(r => (r.End - r.Begin).TotalSeconds);
        var min = _fixture.Rentals.Min(r => (r.End - r.Begin).TotalSeconds);
        var avg = _fixture.Rentals.Average(r => (r.End - r.Begin).TotalSeconds);

        Assert.Equal(11100, max, tolerance: 1); // Adjust the expected value
        Assert.Equal(1740, min, tolerance: 1); // Adjust the expected value
        Assert.Equal(6091, avg, tolerance: 1); // Adjust the expected value
    }
}