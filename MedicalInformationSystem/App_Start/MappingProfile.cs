using AutoMapper;
using MedicalInformationSystem.Models;

namespace MedicalInformationSystem.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Doctor, Doctor>()
                .ForMember(m => m.Id, opt => opt.Ignore())
                .ForMember(m => m.IsApproved, opt => opt.Ignore());

            Mapper.CreateMap<Hospital,Hospital>()
                .ForMember(m => m.Id, opt => opt.Ignore())
                .ForMember(m => m.IsApproved, opt => opt.Ignore());

            Mapper.CreateMap<Ambulance,Ambulance>()
                .ForMember(m => m.Id, opt => opt.Ignore())
                .ForMember(m => m.IsApproved, opt => opt.Ignore());

            Mapper.CreateMap<Pharmacy,Pharmacy>()
                .ForMember(m => m.Id, opt => opt.Ignore())
                .ForMember(m => m.IsApproved, opt => opt.Ignore());

            Mapper.CreateMap<BloodBank, BloodBank>()
                .ForMember(m => m.Id, opt => opt.Ignore())
                .ForMember(m => m.IsApproved, opt => opt.Ignore());
        }

    }
}