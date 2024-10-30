using AutoMapper;
using BicycleRent.Domain;
using BicycleRent.Server.Dto;

namespace BicycleRent.Server;

public class Mapping : Profile
{
    public Mapping()
    {
        CreateMap<Bicycle, BicycleDto>().ReverseMap();
        CreateMap<BicycleType, BicycleTypeDto>().ReverseMap();
        CreateMap<Customer, CustomerDto>().ReverseMap();
        CreateMap<Rental, RentalDto>().ReverseMap();
    }
}