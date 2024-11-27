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
        Bicycles =
        [
            new Bicycle { SerialNumber = "B00", Color = "Orange", Model = "TXJ01", TypeId = 0 },
            new Bicycle { SerialNumber = "B01", Color = "Red", Model = "ETO90", TypeId = 1 },
            new Bicycle { SerialNumber = "B02", Color = "Blue", Model = "SAM878", TypeId = 2 },
            new Bicycle { SerialNumber = "B03", Color = "Gray", Model = "PIO102", TypeId = 0 },
            new Bicycle { SerialNumber = "B04", Color = "Violet", Model = "HKT541", TypeId = 1 },
            new Bicycle { SerialNumber = "B05", Color = "Green", Model = "WMR117", TypeId = 0 },
            new Bicycle { SerialNumber = "B06", Color = "Black", Model = "LPI635", TypeId = 0 },
            new Bicycle { SerialNumber = "B07", Color = "Yellow", Model = "YUI475", TypeId = 2 }
        ];

        Customers =
        [
            new Customer { Id = 0, FullName = "Varro Buckley", BirthDate = new DateTime(1970, 7, 20), PhoneNumber = "+7 908 312 58 50" },
            new Customer { Id = 1, FullName = "Poetelius Parkinson", BirthDate = new DateTime(1984, 11, 14), PhoneNumber = "+7 908 216 48 93" },
            new Customer { Id = 2, FullName = "Orthaeus Winchester", BirthDate = new DateTime(2001, 3, 30), PhoneNumber = "+7 907 511 63 89" },
            new Customer { Id = 3, FullName = "Marcella Penning", BirthDate = new DateTime(2005, 5, 17), PhoneNumber = "+7 908 333 65 32" },
            new Customer { Id = 4, FullName = "Cuniovenda Hencky", BirthDate = new DateTime(1993, 1, 1), PhoneNumber = "+7 908 156 38 26" },
            new Customer { Id = 5, FullName = "Agamedes Rouche", BirthDate = new DateTime(1999, 12, 21), PhoneNumber = "+7 905 041 32 61" },
            new Customer { Id = 6, FullName = "Ianessa Luders", BirthDate = new DateTime(1975, 9, 18), PhoneNumber = "+7 962 602 41 83" },
            new Customer { Id = 7, FullName = "Sophokles Mach", BirthDate = new DateTime(1986, 10, 16), PhoneNumber = "+7 908 216 18 97" }
        ];

        Types =
        [
            new BicycleType { Id = 0, RentalPrice = 500, TypeName = "Sport" },
            new BicycleType { Id = 1, RentalPrice = 650, TypeName = "Mountain" },
            new BicycleType { Id = 2, RentalPrice = 450, TypeName = "Walking" }
        ];

        Rentals =
        [
            new Rental {Id = 0, CustomerId = Customers[7].Id, BicycleSerialNumber = Bicycles[4].SerialNumber, Begin = new DateTime(2023, 9, 20, 18, 31, 0), End = new DateTime(2023, 9, 20, 20, 0, 0)},
            new Rental {Id = 1, CustomerId = Customers[7].Id, BicycleSerialNumber = Bicycles[3].SerialNumber, Begin = new DateTime(2023, 9, 27, 17, 30, 0), End = new DateTime(2023, 9, 27, 19, 0, 0)},
            new Rental {Id = 2, CustomerId = Customers[0].Id, BicycleSerialNumber = Bicycles[3].SerialNumber, Begin = new DateTime(2023, 9, 13, 17, 24, 0), End = new DateTime(2023, 9, 13, 19, 30, 0)},
            new Rental {Id = 3, CustomerId = Customers[0].Id, BicycleSerialNumber = Bicycles[3].SerialNumber, Begin = new DateTime(2023, 9, 6, 18, 5, 0), End = new DateTime(2023, 9, 6, 19, 30, 0)},
            new Rental {Id = 4, CustomerId = Customers[0].Id, BicycleSerialNumber = Bicycles[4].SerialNumber, Begin = new DateTime(2023, 9, 14, 18, 13, 0), End = new DateTime(2023, 9, 14, 19, 40, 0)},
            new Rental {Id = 5, CustomerId = Customers[0].Id, BicycleSerialNumber = Bicycles[2].SerialNumber, Begin = new DateTime(2023, 9, 7, 17, 49, 0), End = new DateTime(2023, 9, 7, 19, 0, 0)},
            new Rental {Id = 6, CustomerId = Customers[0].Id, BicycleSerialNumber = Bicycles[7].SerialNumber, Begin = new DateTime(2023, 9, 1, 18, 0, 0), End = new DateTime(2023, 9, 1, 20, 0, 0)},
            new Rental {Id = 7, CustomerId = Customers[1].Id, BicycleSerialNumber = Bicycles[2].SerialNumber, Begin = new DateTime(2023, 9, 8, 16, 55, 0), End = new DateTime(2023, 9, 8, 20, 0, 0)},
            new Rental {Id = 8, CustomerId = Customers[0].Id, BicycleSerialNumber = Bicycles[4].SerialNumber, Begin = new DateTime(2023, 9, 3, 18, 31, 0), End = new DateTime(2023, 9, 3, 20, 0, 0)},
            new Rental {Id = 9, CustomerId = Customers[1].Id, BicycleSerialNumber = Bicycles[1].SerialNumber, Begin = new DateTime(2023, 9, 16, 14, 0, 0), End = new DateTime(2023, 9, 16, 16, 30, 0)},
            new Rental {Id = 10, CustomerId = Customers[7].Id, BicycleSerialNumber = Bicycles[1].SerialNumber, Begin = new DateTime(2023, 9, 22, 15, 30, 0), End = new DateTime(2023, 9, 22, 16, 0, 0)},
            new Rental {Id = 11, CustomerId = Customers[1].Id, BicycleSerialNumber = Bicycles[1].SerialNumber, Begin = new DateTime(2023, 9, 6, 18, 33, 0), End = new DateTime(2023, 9, 6, 20, 10, 0)},
            new Rental {Id = 12, CustomerId = Customers[2].Id, BicycleSerialNumber = Bicycles[4].SerialNumber, Begin = new DateTime(2023, 9, 11, 18, 20, 0), End = new DateTime(2023, 9, 11, 20, 15, 0)},
            new Rental {Id = 13, CustomerId = Customers[2].Id, BicycleSerialNumber = Bicycles[5].SerialNumber, Begin = new DateTime(2023, 9, 23, 13, 40, 0), End = new DateTime(2023, 9, 23, 15, 20, 0)},
            new Rental {Id = 14, CustomerId = Customers[3].Id, BicycleSerialNumber = Bicycles[7].SerialNumber, Begin = new DateTime(2023, 9, 5, 14, 35, 0), End = new DateTime(2023, 9, 5, 15, 30, 0)},
            new Rental {Id = 15, CustomerId = Customers[6].Id, BicycleSerialNumber = Bicycles[1].SerialNumber, Begin = new DateTime(2023, 9, 5, 19, 0, 0), End = new DateTime(2023, 9, 5, 21, 20, 0)},
            new Rental {Id = 16, CustomerId = Customers[2].Id, BicycleSerialNumber = Bicycles[4].SerialNumber, Begin = new DateTime(2023, 9, 6, 9, 0, 0), End = new DateTime(2023, 9, 6, 11, 0, 0)},
            new Rental {Id = 17, CustomerId = Customers[3].Id, BicycleSerialNumber = Bicycles[6].SerialNumber, Begin = new DateTime(2023, 9, 8, 8, 40, 0), End = new DateTime(2023, 9, 8, 10, 20, 0)},
            new Rental {Id = 18, CustomerId = Customers[4].Id, BicycleSerialNumber = Bicycles[7].SerialNumber, Begin = new DateTime(2023, 9, 11, 11, 31, 0), End = new DateTime(2023, 9, 11, 13, 0, 0)},
            new Rental {Id = 19, CustomerId = Customers[4].Id, BicycleSerialNumber = Bicycles[6].SerialNumber, Begin = new DateTime(2023, 9, 14, 10, 0, 0), End = new DateTime(2023, 9, 14, 12, 30, 0)},
            new Rental {Id = 20, CustomerId = Customers[5].Id, BicycleSerialNumber = Bicycles[4].SerialNumber, Begin = new DateTime(2023, 9, 13, 13, 50, 0), End = new DateTime(2023, 9, 13, 16, 0, 0)},
            new Rental {Id = 21, CustomerId = Customers[4].Id, BicycleSerialNumber = Bicycles[0].SerialNumber, Begin = new DateTime(2023, 9, 30, 15, 13, 0), End = new DateTime(2023, 9, 30, 18, 0, 0)},
            new Rental {Id = 22, CustomerId = Customers[5].Id, BicycleSerialNumber = Bicycles[0].SerialNumber, Begin = new DateTime(2023, 9, 5, 16, 44, 0), End = new DateTime(2023, 9, 5, 18, 0, 0)},
            new Rental {Id = 23, CustomerId = Customers[6].Id, BicycleSerialNumber = Bicycles[0].SerialNumber, Begin = new DateTime(2023, 9, 23, 12, 1, 0), End = new DateTime(2023, 9, 23, 14, 14, 0)},
            new Rental {Id = 24, CustomerId = Customers[5].Id, BicycleSerialNumber = Bicycles[4].SerialNumber, Begin = new DateTime(2023, 9, 21, 15, 31, 0), End = new DateTime(2023, 9, 21, 16, 0, 0)},
            new Rental {Id = 25, CustomerId = Customers[6].Id, BicycleSerialNumber = Bicycles[3].SerialNumber, Begin = new DateTime(2023, 9, 22, 13, 31, 0), End = new DateTime(2023, 9, 22, 15, 0, 0)},
            new Rental {Id = 26, CustomerId = Customers[5].Id, BicycleSerialNumber = Bicycles[7].SerialNumber, Begin = new DateTime(2023, 9, 1, 12, 31, 0), End = new DateTime(2023, 9, 1, 13, 0, 0)},
            new Rental {Id = 27, CustomerId = Customers[5].Id, BicycleSerialNumber = Bicycles[2].SerialNumber, Begin = new DateTime(2023, 12, 1, 15, 31, 0), End = new DateTime(2023, 12, 1, 17, 0, 0)},
            new Rental {Id = 28, CustomerId = Customers[3].Id, BicycleSerialNumber = Bicycles[1].SerialNumber, Begin = new DateTime(2023, 10, 2, 17, 20, 0), End = new DateTime(2023, 10, 2, 19, 0, 0)},
            new Rental {Id = 29, CustomerId = Customers[6].Id, BicycleSerialNumber = Bicycles[0].SerialNumber, Begin = new DateTime(2023, 10, 19, 20, 20, 0), End = new DateTime(2023, 10, 19, 22, 30, 0)}
        ];
    }
};