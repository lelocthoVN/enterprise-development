using BicycleRent.Domain;

namespace BicycleRent.Tests;
public class BicycleRentData
{
    public List<Customer> Customers { get; set; }
    public List<BicycleType> Types { get; set; }
    public List<Bicycle> Bicycles { get; set; }
    public List<Rental> Rentals { get; set; }

    // Constructor to initialize data
    public BicycleRentData()
    {
        Bicycles = new List<Bicycle>()
        {
            new Bicycle { SerialNumber = "B00", Color = "Orange", Model = "TXJ01", TypeId = 0 },
            new Bicycle { SerialNumber = "B01", Color = "Red", Model = "ETO90", TypeId = 1 },
            new Bicycle { SerialNumber = "B02", Color = "Blue", Model = "SAM878", TypeId = 2 },
            new Bicycle { SerialNumber = "B03", Color = "Gray", Model = "PIO102", TypeId = 0 },
            new Bicycle { SerialNumber = "B04", Color = "Violet", Model = "HKT541", TypeId = 1 },
            new Bicycle { SerialNumber = "B05", Color = "Green", Model = "WMR117", TypeId = 0 },
            new Bicycle { SerialNumber = "B06", Color = "Black", Model = "LPI635", TypeId = 0 },
            new Bicycle { SerialNumber = "B07", Color = "Yellow", Model = "YUI475", TypeId = 2 }
        };

        Customers = new List<Customer>()
        {
            new Customer { Id = 0, FullName = "Varro Buckley", BirthDate = new DateTime(1970, 7, 20), PhoneNumber = "+7 908 312 58 50" },
            new Customer { Id = 1, FullName = "Poetelius Parkinson", BirthDate = new DateTime(1984, 11, 14), PhoneNumber = "+7 908 216 48 93" },
            new Customer { Id = 2, FullName = "Orthaeus Winchester", BirthDate = new DateTime(2001, 3, 30), PhoneNumber = "+7 907 511 63 89" },
            new Customer { Id = 3, FullName = "Marcella Penning", BirthDate = new DateTime(2005, 5, 17), PhoneNumber = "+7 908 333 65 32" },
            new Customer { Id = 4, FullName = "Cuniovenda Hencky", BirthDate = new DateTime(1993, 1, 1), PhoneNumber = "+7 908 156 38 26" },
            new Customer { Id = 5, FullName = "Agamedes Rouche", BirthDate = new DateTime(1999, 12, 21), PhoneNumber = "+7 905 041 32 61" },
            new Customer { Id = 6, FullName = "Ianessa Luders", BirthDate = new DateTime(1975, 9, 18), PhoneNumber = "+7 962 602 41 83" },
            new Customer { Id = 7, FullName = "Sophokles Mach", BirthDate = new DateTime(1986, 10, 16), PhoneNumber = "+7 908 216 18 97" }
        };

        Types = new List<BicycleType>()
        {
            new BicycleType { Id = 0, RentalPrice = 500, TypeName = "Sport" },
            new BicycleType { Id = 1, RentalPrice = 650, TypeName = "Mountain" },
            new BicycleType { Id = 2, RentalPrice = 450, TypeName = "Walking" }
        };

        Rentals = new List<Rental>()
        {
            new Rental { Customer = Customers[7], Bicycle = Bicycles[4], Begin = new DateTime(2023, 9, 20, 18, 31, 0), End = new DateTime(2023, 9, 20, 20, 0, 0) },
            new Rental { Customer = Customers[7], Bicycle = Bicycles[3], Begin = new DateTime(2023, 9, 27, 17, 30, 0), End = new DateTime(2023, 9, 27, 19, 0, 0) },
            new Rental { Customer = Customers[0], Bicycle = Bicycles[3], Begin = new DateTime(2023, 9, 13, 17, 24, 0), End = new DateTime(2023, 9, 13, 19, 30, 0) },
            new Rental { Customer = Customers[0], Bicycle = Bicycles[3], Begin = new DateTime(2023, 9, 6, 18, 5, 0), End = new DateTime(2023, 9, 6, 19, 30, 0) },
            new Rental { Customer = Customers[0], Bicycle = Bicycles[4], Begin = new DateTime(2023, 9, 14, 18, 13, 0), End = new DateTime(2023, 9, 14, 19, 40, 0) },
            new Rental { Customer = Customers[0], Bicycle = Bicycles[2], Begin = new DateTime(2023, 9, 7, 17, 49, 0), End = new DateTime(2023, 9, 7, 19, 0, 0) },
            new Rental { Customer = Customers[0], Bicycle = Bicycles[7], Begin = new DateTime(2023, 9, 1, 18, 0, 0), End = new DateTime(2023, 9, 1, 20, 0, 0) },
            new Rental { Customer = Customers[1], Bicycle = Bicycles[2], Begin = new DateTime(2023, 9, 8, 16, 55, 0), End = new DateTime(2023, 9, 8, 20, 0, 0) },
            new Rental { Customer = Customers[0], Bicycle = Bicycles[4], Begin = new DateTime(2023, 9, 3, 18, 31, 0), End = new DateTime(2023, 9, 3, 20, 0, 0) },
            new Rental { Customer = Customers[1], Bicycle = Bicycles[1], Begin = new DateTime(2023, 9, 16, 14, 0, 0), End = new DateTime(2023, 9, 16, 16, 30, 0) },
            new Rental { Customer = Customers[7], Bicycle = Bicycles[1], Begin = new DateTime(2023, 9, 22, 15, 30, 0), End = new DateTime(2023, 9, 22, 16, 0, 0) },
            new Rental { Customer = Customers[1], Bicycle = Bicycles[1], Begin = new DateTime(2023, 9, 6, 18, 33, 0), End = new DateTime(2023, 9, 6, 20, 10, 0) },
            new Rental { Customer = Customers[2], Bicycle = Bicycles[4], Begin = new DateTime(2023, 9, 11, 18, 20, 0), End = new DateTime(2023, 9, 11, 20, 15, 0) },
            new Rental { Customer = Customers[2], Bicycle = Bicycles[5], Begin = new DateTime(2023, 9, 23, 13, 40, 0), End = new DateTime(2023, 9, 23, 15, 20, 0) },
            new Rental { Customer = Customers[3], Bicycle = Bicycles[7], Begin = new DateTime(2023, 9, 5, 14, 35, 0), End = new DateTime(2023, 9, 5, 15, 30, 0) },
            new Rental { Customer = Customers[7], Bicycle = Bicycles[5], Begin = new DateTime(2023, 9, 5, 19, 0, 0), End = new DateTime(2023, 9, 5, 21, 20, 0) },
            new Rental { Customer = Customers[3], Bicycle = Bicycles[4], Begin = new DateTime(2023, 9, 6, 9, 0, 0), End = new DateTime(2023, 9, 6, 11, 0, 0) },
            new Rental { Customer = Customers[3], Bicycle = Bicycles[6], Begin = new DateTime(2023, 9, 8, 8, 40, 0), End = new DateTime(2023, 9, 8, 10, 20, 0) },
            new Rental { Customer = Customers[4], Bicycle = Bicycles[7], Begin = new DateTime(2023, 9, 11, 11, 31, 0), End = new DateTime(2023, 9, 11, 13, 0, 0) },
            new Rental { Customer = Customers[4], Bicycle = Bicycles[6], Begin = new DateTime(2023, 9, 14, 10, 0, 0), End = new DateTime(2023, 9, 14, 12, 30, 0) },
            new Rental { Customer = Customers[5], Bicycle = Bicycles[4], Begin = new DateTime(2023, 9, 13, 13, 50, 0), End = new DateTime(2023, 9, 13, 16, 0, 0) },
            new Rental { Customer = Customers[4], Bicycle = Bicycles[0], Begin = new DateTime(2023, 9, 30, 15, 13, 0), End = new DateTime(2023, 9, 30, 18, 0, 0) },
            new Rental { Customer = Customers[5], Bicycle = Bicycles[0], Begin = new DateTime(2023, 9, 5, 16, 44, 0), End = new DateTime(2023, 9, 5, 18, 0, 0) },
            new Rental { Customer = Customers[6], Bicycle = Bicycles[0], Begin = new DateTime(2023, 9, 23, 12, 1, 0), End = new DateTime(2023, 9, 23, 14, 14, 0) },
            new Rental { Customer = Customers[5], Bicycle = Bicycles[4], Begin = new DateTime(2023, 9, 21, 15, 31, 0), End = new DateTime(2023, 9, 21, 16, 0, 0) },
            new Rental { Customer = Customers[6], Bicycle = Bicycles[3], Begin = new DateTime(2023, 9, 22, 13, 31, 0), End = new DateTime(2023, 9, 22, 15, 0, 0) },
            new Rental { Customer = Customers[5], Bicycle = Bicycles[7], Begin = new DateTime(2023, 9, 1, 12, 31, 0), End = new DateTime(2023, 9, 1, 13, 0, 0) }
        };
    }
};
