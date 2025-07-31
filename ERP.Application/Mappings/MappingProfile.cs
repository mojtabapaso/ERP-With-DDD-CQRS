using AutoMapper;
using ERP.Application.DTOs.EmployeeDTOs;
using ERP.Domain.Entities;


namespace ERP.Application.Mappings;

/// <summary>
/// AutoMapper profile for configuring object-to-object mappings.
/// </summary>
public class MappingProfile : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MappingProfile"/> class.
    /// Define your mappings between domain models, DTOs, and requests here.
    /// </summary>
    public MappingProfile()
    {
        // Define mappings here using CreateMap<Source, Destination>();
        // Example: CreateMap<User, UserDto>();
        CreateMap<Employee, EmployeeDto>();
    }
}
