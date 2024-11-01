using AutoMapper;
using BicycleRent.Domain;
using BicycleRent.Server.Dto;

namespace BicycleRent.Server;

/// <summary>
/// Configures mappings between domain models and DTOs
/// </summary>
public class Mapping : Profile
{
    /// <summary>
    /// Constructor that creates mappings between of class DTO and Entity
    /// </summary>
    public Mapping()
    {
        CreateMap<Bicycle, BicycleDto>().ReverseMap();
        CreateMap<BicycleType, BicycleTypeDto>().ReverseMap();
        CreateMap<Customer, CustomerDto>().ReverseMap();
        CreateMap<Rental, RentalDto>().ReverseMap();
    }
}