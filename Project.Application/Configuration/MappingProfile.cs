using AutoMapper;
using Project.Application.Common.Models;
using Project.Domain.Entities;

namespace Project.Application.Configuration;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserViewModel>()
            .ForMember(d => d.UserId, o =>
                o.MapFrom(s => s.Id))
            .ForMember(d => d.Age, o =>
                o.MapFrom(s => UserAgeResolve(s.DateOfBirth)))
            .ForMember(d => d.Street, o =>
                o.MapFrom(s => s.Address.Street))
            .ForMember(d => d.HouseNumber, o =>
                o.MapFrom(s => s.Address.HouseNumber))
            .ForMember(d => d.ApartmentNumber, o =>
                o.MapFrom(s => s.Address.ApartmentNumber))
            .ForMember(d => d.Town, o =>
                o.MapFrom(s => s.Address.Town))
            .ForMember(d => d.PostalCode, o =>
                o.MapFrom(s => s.Address.PostalCode))
            .ReverseMap()
            .ForPath(d => d.Address.Street, o =>
                o.MapFrom(s => s.Street))
            .ForPath(d => d.Address.HouseNumber, o =>
                o.MapFrom(s => s.HouseNumber))
            .ForPath(d => d.Address.ApartmentNumber, o =>
                o.MapFrom(s => s.ApartmentNumber))
            .ForPath(d => d.Address.Town, o =>
                o.MapFrom(s => s.Town))
            .ForPath(d => d.Address.PostalCode, o =>
                o.MapFrom(s => s.PostalCode));
    }

    private static int UserAgeResolve(DateOnly dateOfBirth)
    {
        var today = DateOnly.FromDateTime(DateTime.Today.Date);
        var age = today.Year - dateOfBirth.Year;
        
        if (dateOfBirth > today.AddYears(-age))
        {
            age--;
        }

        return age;
    }
}