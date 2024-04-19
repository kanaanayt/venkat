using AutoMapper;
using EMS.Core;

namespace EMS.Api.Profiles;

public class CompanyProfile : Profile
{
    public CompanyProfile()
    {
        CreateMap<eDepartment, rDepartment>();
        CreateMap<eEmployee, rEmployee>();
        CreateMap<cDepartment, eDepartment>();
        CreateMap<cEmployee, eEmployee>();
    }
}