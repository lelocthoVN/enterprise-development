using BicycleRent.Domain;

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

        Assert.Equal(4, sportBicycle.Count); 
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
         join rent in _fixture.Rentals on bike.SerialNumber equals rent.BicycleSerialNumber  
         join client in _fixture.Customers on rent.CustomerId equals client.Id  
         orderby client.FullName
         select client).Distinct().ToList();

        Assert.Equal(7, mountainCustomers.Count);
        Assert.Equal("Agamedes Rouche", mountainCustomers.First().FullName);
    }

    /// <summary>
    /// Summed rental time for all bicycle types
    /// </summary>
    [Fact]
    public void TestBicycleTimeRents()
    {
        var typeRentTime = _fixture.Rentals
                .Join(_fixture.Bicycles, r => r.BicycleSerialNumber, b => b.SerialNumber, (r, b) => new { r, b.TypeId })
                .Join(_fixture.Types, rb => rb.TypeId, t => t.Id, (rb, t) => new { t.TypeName, RentTime = (rb.r.End - rb.r.Begin).TotalMinutes })
                .GroupBy(x => x.TypeName)
                .Select(g => new { TypeName = g.Key, TotalTime = g.Sum(x => x.RentTime) })
                .ToList();

        Assert.NotEmpty(typeRentTime);
        Assert.Equal(1176, typeRentTime.First().TotalTime, tolerance: 10);
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
         group rent by rent.BicycleSerialNumber into grouped  
         orderby grouped.Count() descending
         select new
         {
             BicycleSerialNumber = grouped.Key,
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

        Assert.Equal(11100, max, tolerance: 1); 
        Assert.Equal(1740, min, tolerance: 1); 
        Assert.Equal(6120, avg, tolerance: 1); 
    }
}